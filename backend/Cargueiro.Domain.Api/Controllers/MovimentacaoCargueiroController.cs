using Microsoft.AspNetCore.Mvc;
using Cargueiro.Domain.Commands;
using Cargueiro.Domain.Handlers;
using System.Threading.Tasks;
using System.Collections.Generic;
using Cargueiro.Domain.Entidades;
using Cargueiro.Domain.Repositorios;
using Cargueiro.Domain.Infra.Repositorios;

namespace Cargueiro.Domain.Api.Controllers
{
    [ApiController]
    [Route("v1/cargueiro/movimentacao")]
    public class MovimentacaoCargueiroController : ControllerBase
    {
        private readonly MovimentacaoCargueiroHandler _handler;
        private readonly IMovimentacaoCargueiroRepositorio _repositorio;
        public MovimentacaoCargueiroController(MovimentacaoCargueiroHandler handler, IMovimentacaoCargueiroRepositorio repositorio)
        {
            _handler = handler;
            _repositorio = repositorio;
        }

        [HttpGet]
        [Route("")]
        public async Task<MovimentacaoCargueiro> Movimentacao()
        {
            return await _repositorio.RetornaMovimentacao();
        }

        [HttpGet]
        [Route("todas")]
        public async Task<IEnumerable<MovimentacaoCargueiro>> Movimentacoes([FromQuery] int ano)
        {
            return await _repositorio.RetornaMovimentacoes(2021, 05);
        }


        [HttpPost]
        [Route("saida/")]
        public async Task<IResposta> RegistraSaidaCargueiro(SaidaCargueiroCommand command)
        {
            return await _handler.Handle(command);
        }

        [HttpPost]
        [Route("retorno/")]
        public async Task<IResposta> RegistraRetornoCargueiro(RetornoCargueiroCommand command)
        {
            return await _handler.Handle(command);
        }
    }
}