using System;
using Cargueiro.Domain.Entidades;
using Cargueiro.Domain.Commands;
using Cargueiro.Domain.Enums;
using Cargueiro.Domain.Repositorios;

namespace Cargueiro.Domain.Handlers
{
    public class MovimentacaoCargueiroHandler
    {
        private readonly IFrotaCargueiroRepositorio _frotaCargueiroRepositorio;
        private readonly IMovimentacaoCargueiroRepositorio _movimentacaoCargueiroRepositorio;
        public MovimentacaoCargueiroHandler(IFrotaCargueiroRepositorio frotaCargueiroRepositorio, IMovimentacaoCargueiroRepositorio movimentacaoCargueiroRepositorio)
        {
            _frotaCargueiroRepositorio = frotaCargueiroRepositorio;
            _movimentacaoCargueiroRepositorio = movimentacaoCargueiroRepositorio;
        }

        public RespostaPadrao Handle(SaidaCargueiroCommand saidaCargueiroCommand)
        {
            //valida - fail fast validation
            saidaCargueiroCommand.Validar();
            if (!saidaCargueiroCommand.IsValid)
                return new RespostaPadrao { Sucesso = false, Mensagem = "Requisicao Incorreta", Dados = saidaCargueiroCommand.Notifications };

            //verifica se ainda tem cargueiros disponiveis desse tipo para sair na frota
            var frotaCargueiro = _frotaCargueiroRepositorio.RetornaFrota(EClasseCargueiro.Classe_I);
            if (!frotaCargueiro.NaoExisteCargueiroDisponivel)
                return new RespostaPadrao { Sucesso = false, Mensagem = "Não há cargueiros dessa classe disponíveis para sair" };

            //cria o objeto MovimentacaoCargueiro
            var movimentacaoCargueiro = new MovimentacaoCargueiro();
            movimentacaoCargueiro.RegistraSaida(saidaCargueiroCommand.ClasseCargueiro, saidaCargueiroCommand.DataSaida);
            if (!movimentacaoCargueiro.IsValid)
                return new RespostaPadrao { Sucesso = false, Mensagem = "Requisicao Incorreta", Dados = movimentacaoCargueiro.Notifications };

            //persiste no bd informando a saida
            _movimentacaoCargueiroRepositorio.Salva(movimentacaoCargueiro);

            //persiste no bd informando a baixa na frota
            frotaCargueiro.RegistraBaixaFrota();
            _frotaCargueiroRepositorio.AtualizaFrota(frotaCargueiro);

            return new RespostaPadrao { Sucesso = true, Mensagem = "Saida registrada com sucesso", Dados = movimentacaoCargueiro };
        }

        public RespostaPadrao Handle(RetornoCargueiroCommand retornoCargueiroCommand)
        {
            //valida - fail fast validation
            retornoCargueiroCommand.Validar();
            if (!retornoCargueiroCommand.IsValid)
                return new RespostaPadrao { Sucesso = false, Mensagem = "Requisicao Incorreta", Dados = retornoCargueiroCommand.Notifications };

            //verifica se tem cargueiro desse tipo para retornar        
            var frotaCargueiro = _frotaCargueiroRepositorio.RetornaFrota(EClasseCargueiro.Classe_I);
            if (frotaCargueiro.NaoExisteCargueiroEmViagem)
                return new RespostaPadrao { Sucesso = false, Mensagem = "Não há cargueiros dessa classe em viagem" };

            //Busca o registro com a saída do cargueiro
            var movimentacaoCargueiro = _movimentacaoCargueiroRepositorio.RetornaMovimentacao();
            movimentacaoCargueiro.RegistraRetorno(
                retornoCargueiroCommand.DataRetorno,
                retornoCargueiroCommand.TipoMineralObtido,
                retornoCargueiroCommand.QtdMaterialObtidoEmQuilos);

            if (!movimentacaoCargueiro.IsValid)
                return new RespostaPadrao { Sucesso = false, Mensagem = "Requisicao Incorreta", Dados = movimentacaoCargueiro.Notifications };

            //persiste no bd informando o retorno
            _movimentacaoCargueiroRepositorio.Salva(movimentacaoCargueiro);

            //atualiza a quantidade na frota disponivel
            frotaCargueiro.RegistraRetornoFrota();
            _frotaCargueiroRepositorio.AtualizaFrota(frotaCargueiro);

            return new RespostaPadrao { Sucesso = true, Mensagem = "Retorno do cargueiro realizado com sucesso", Dados = movimentacaoCargueiro }; ;
        }

    }
}