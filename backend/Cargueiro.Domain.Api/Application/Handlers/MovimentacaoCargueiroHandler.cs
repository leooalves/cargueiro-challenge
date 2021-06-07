using Cargueiro.Domain.Api.Application.Commands;
using Cargueiro.Domain.Repositorios;
using Cargueiro.Domain.Entidades;
using Cargueiro.Domain.Enums;
using System.Threading.Tasks;

namespace Cargueiro.Domain.Api.Application.Handlers
{
    public class MovimentacaoCargueiroHandler : IHandler<SaidaCargueiroCommand>, IHandler<RetornoCargueiroCommand>
    {
        private readonly IFrotaCargueiroRepositorio _frotaCargueiroRepositorio;
        private readonly IMovimentacaoCargueiroRepositorio _movimentacaoCargueiroRepositorio;
        private readonly IConfiguracaoCargueiroRepositorio _configuracaoCargueiroRepositorio;
        public MovimentacaoCargueiroHandler(
            IFrotaCargueiroRepositorio frotaCargueiroRepositorio,
            IMovimentacaoCargueiroRepositorio movimentacaoCargueiroRepositorio,
            IConfiguracaoCargueiroRepositorio configuracaoCargueiroRepositorio)
        {
            _frotaCargueiroRepositorio = frotaCargueiroRepositorio;
            _movimentacaoCargueiroRepositorio = movimentacaoCargueiroRepositorio;
            _configuracaoCargueiroRepositorio = configuracaoCargueiroRepositorio;
        }

        public async Task<IResposta> Handle(SaidaCargueiroCommand saidaCargueiroCommand)
        {
            //valida - fail fast validation
            saidaCargueiroCommand.Validar();
            if (!saidaCargueiroCommand.IsValid)
                return new RespostaPadrao { Sucesso = false, Mensagem = "Requisicao Incorreta", Dados = saidaCargueiroCommand.Notifications };

            //verifica se ainda tem cargueiros disponiveis desse tipo para sair na frota
            var frotaCargueiro = await _frotaCargueiroRepositorio.BuscaFrotaPorClasse(saidaCargueiroCommand.ClasseCargueiro);
            if (frotaCargueiro.NaoExisteCargueiroDisponivel)
                return new RespostaPadrao { Sucesso = false, Mensagem = "Não há cargueiros dessa classe disponíveis para sair" };

            //cria o objeto MovimentacaoCargueiro
            var movimentacaoCargueiro = new MovimentacaoCargueiro();
            movimentacaoCargueiro.RegistraSaida(saidaCargueiroCommand.ClasseCargueiro, saidaCargueiroCommand.DataSaida);
            if (!movimentacaoCargueiro.IsValid)
                return new RespostaPadrao { Sucesso = false, Mensagem = "Requisicao Incorreta", Dados = movimentacaoCargueiro.Notifications };

            //persiste no bd informando a saida
            _movimentacaoCargueiroRepositorio.Cria(movimentacaoCargueiro);

            //persiste no bd informando a baixa na frota
            frotaCargueiro.RegistraBaixaFrota();
            _frotaCargueiroRepositorio.AtualizaFrota(frotaCargueiro);

            await _frotaCargueiroRepositorio.UnitOfWork.SaveChangesAsync();

            return new RespostaPadrao { Sucesso = true, Mensagem = "Saida registrada com sucesso", Dados = movimentacaoCargueiro };
        }

        public async Task<IResposta> Handle(RetornoCargueiroCommand retornoCargueiroCommand)
        {
            //valida - fail fast validation
            retornoCargueiroCommand.Validar();
            if (!retornoCargueiroCommand.IsValid)
                return new RespostaPadrao { Sucesso = false, Mensagem = "Requisicao Incorreta", Dados = retornoCargueiroCommand.Notifications };

            //verifica se tem cargueiro desse tipo para retornar        
            var frotaCargueiro = await _frotaCargueiroRepositorio.BuscaFrotaPorClasse(retornoCargueiroCommand.ClasseCargueiro);
            if (frotaCargueiro.NaoExisteCargueiroEmViagem)
                return new RespostaPadrao { Sucesso = false, Mensagem = "Não há cargueiros dessa classe em viagem" };

            //Busca o registro com a saída do cargueiro
            var movimentacaoCargueiro = await _movimentacaoCargueiroRepositorio.RetornaMovimentacao(retornoCargueiroCommand.Id);
            movimentacaoCargueiro.RegistraRetorno(
                retornoCargueiroCommand.DataRetorno,
                retornoCargueiroCommand.TipoMineralObtido,
                retornoCargueiroCommand.QtdMaterialObtidoEmQuilos);

            if (!movimentacaoCargueiro.IsValid)
                return new RespostaPadrao { Sucesso = false, Mensagem = "Requisicao Incorreta", Dados = movimentacaoCargueiro.Notifications };

            //verifica as informações de retorno estão de acordo com o parametrizado para a classe daquele cargueiro
            var configuracaoCargueiro = await _configuracaoCargueiroRepositorio.RetornaCargueiroPorClasse(retornoCargueiroCommand.ClasseCargueiro);
            if(retornoCargueiroCommand.QtdMaterialObtidoEmQuilos > configuracaoCargueiro.CapacidadeEmQuilos )
                return new RespostaPadrao { Sucesso = false, Mensagem = "Cargueiro dessa classe não aguenta essa capacidade de materiais" };

            if(!configuracaoCargueiro.MineraisCompativeis.Contains(retornoCargueiroCommand.TipoMineralObtido))
                return new RespostaPadrao { Sucesso = false, Mensagem = "Cargueiro dessa classe não é compatível com esse mineral" };     

            //persiste no bd informando o retorno
            _movimentacaoCargueiroRepositorio.Atualiza(movimentacaoCargueiro);

            //atualiza a quantidade na frota disponivel
            frotaCargueiro.RegistraRetornoFrota();
            _frotaCargueiroRepositorio.AtualizaFrota(frotaCargueiro);

            await _frotaCargueiroRepositorio.UnitOfWork.SaveChangesAsync();

            return new RespostaPadrao { Sucesso = true, Mensagem = "Retorno do cargueiro realizado com sucesso", Dados = movimentacaoCargueiro }; ;
        }

    }
}