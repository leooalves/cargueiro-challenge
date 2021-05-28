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

        public RespostaPadrao Handle()
        {
            //cria o objeto saidaCargueiro
            //valida - fail fast validation
            var saidaCargueiro = new MovimentacaoCargueiro(EClasseCargueiro.Classe_I, DateTime.Now);
            if (!saidaCargueiro.IsValid)
                return new RespostaPadrao { Sucesso = false, Mensagem = "Requisicao Incorreta", Dados = saidaCargueiro.Notifications };

            //verifica se ainda tem cargueiros disponiveis desse tipo para sair na frota
            var frotaCargueiro = _frotaCargueiroRepositorio.RetornaFrota(EClasseCargueiro.Classe_I);
            if (!frotaCargueiro.NaoExisteCargueiroDisponivel)
                return new RespostaPadrao { Sucesso = false, Mensagem = "Não há cargueiros dessa classe disponíveis para sair" };

            //persiste no bd informando a saida
            _movimentacaoCargueiroRepositorio.Salva(saidaCargueiro);

            //persiste no bd informando a baixa na frota
            frotaCargueiro.RegistraBaixaFrota();
            _frotaCargueiroRepositorio.AtualizaFrota(frotaCargueiro);

            return new RespostaPadrao { Sucesso = true, Mensagem = "Saida registrada com sucesso", Dados = saidaCargueiro };
        }

        public RespostaPadrao Handle(object obj)
        {
            //cria o objeto de RetornoCargueiro
            //valida - fail fast validation
            // var retornoCargueiro = new MovimentacaoCargueiro(EClasseCargueiro.Classe_I, DateTime.Now, ETipoMineral.Tipo_A, 10);
            // if (!retornoCargueiro.IsValid)
            //     return new RespostaPadrao { Sucesso = false, Mensagem = "Requisicao Incorreta", Dados = retornoCargueiro.Notifications };


            // //verifica se tem cargueiro desse tipo para retornar        
            // var frotaCargueiro = _frotaCargueiroRepositorio.RetornaFrota(EClasseCargueiro.Classe_I);
            // if (frotaCargueiro.NaoExisteCargueiroEmViagem)
            //     return new RespostaPadrao { Sucesso = false, Mensagem = "Não há cargueiros dessa classe em viagem" };

            // //persiste no bd informando o retorno
            // _movimentacaoCargueiroRepositorio.Salva(retornoCargueiro);

            // //atualiza a quantidade na frota disponivel
            // frotaCargueiro.RegistraRetornoFrota();
            // _frotaCargueiroRepositorio.AtualizaFrota(frotaCargueiro);

            // return new RespostaPadrao { Sucesso = true, Mensagem = "Retorno do cargueiro realizado com sucesso", Dados = retornoCargueiro }; ;
            return null;
        }

    }
}