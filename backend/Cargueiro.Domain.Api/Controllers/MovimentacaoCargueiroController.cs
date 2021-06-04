using AutoMapper;
using Cargueiro.Domain.Api.Application.Commands;
using Cargueiro.Domain.Api.Application.Handlers;
using Cargueiro.Domain.Repositorios;
using Cargueiro.Domain.Entidades;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Cargueiro.Domain.Api.Application.Queries;

namespace Cargueiro.Domain.Api.Controllers
{
    [ApiController]
    [Route("v1/cargueiro/movimentacao")]
    public class MovimentacaoCargueiroController : ControllerBase
    {
        private readonly MovimentacaoCargueiroHandler _handler;
        private readonly IMovimentacaoCargueiroRepositorio _repositorio;
        private readonly MovimentacaoCargueiroQueries _queries;        

        public MovimentacaoCargueiroController(
            MovimentacaoCargueiroHandler handler,
            IMovimentacaoCargueiroRepositorio repositorio,
            MovimentacaoCargueiroQueries queries,
            IMapper mapper)
        {
            _handler = handler;
            _repositorio = repositorio;            
            _queries = queries;
        }

        [HttpGet]
        [Route("todas")]
        [ProducesResponseType(typeof(IEnumerable<MovimentacaoCargueiro>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.Forbidden)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> TodasMovimentacoes()
        {

            return Ok(await _repositorio.RetornaTodasMovimentacoes());
        }

        [HttpGet]
        [Route("teste")]
        [ProducesResponseType(typeof(IEnumerable<MovimentacaoCargueiroViewModel>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.Forbidden)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> Teste()
        {
            var movimentacoes = await _queries.RetornaMovimentacoesPorPeriodo(1, 1);
            return Ok(movimentacoes);
            //return Ok(await _repositorio.RetornaTodasMovimentacoes());
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