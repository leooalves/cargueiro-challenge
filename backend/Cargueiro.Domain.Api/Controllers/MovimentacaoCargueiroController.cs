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
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Cargueiro.Domain.Api.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("v1/cargueiro/movimentacao")]
    public class MovimentacaoCargueiroController : ControllerBase
    {
        private readonly MovimentacaoCargueiroHandler _handler;
        private readonly IMovimentacaoCargueiroRepositorio _repositorio;
        private readonly MovimentacaoCargueiroQueries _queries;        

        public MovimentacaoCargueiroController(
            MovimentacaoCargueiroHandler handler,
            IMovimentacaoCargueiroRepositorio repositorio,
            MovimentacaoCargueiroQueries queries)
        {
            _handler = handler;
            _repositorio = repositorio;            
            _queries = queries;
        }

        [HttpGet]
        [Route("todas")]
        [ProducesResponseType(typeof(IEnumerable<MovimentacaoCargueiro>), (int)HttpStatusCode.OK)]        
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> TodasMovimentacoes()
        {

            return Ok(await _repositorio.RetornaTodasMovimentacoes());
        }

        [HttpGet]
        [Route("retorno")]
        [ProducesResponseType(typeof(ItensPaginados<MovimentacaoCargueiroViewModel>), (int)HttpStatusCode.OK)]        
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> MovimentacoesPorPeriodo([BindRequired] int ano, [BindRequired] int mes, int pagina = 1)
        {
            var movimentacoes = await _queries.MovimentacoesPorPeriodoPaginado(ano,mes,pagina);
            return Ok(movimentacoes);            
        }


        [HttpGet]
        [Route("retorno/minerio")]
        [ProducesResponseType(typeof(IEnumerable<CargasMinerioPorPeriodoViewModel>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> MovimentacoesPorPeriodoPorMinerio([BindRequired] int ano, [BindRequired] int mes)
        {
            var movimentacoes = await _queries.MovimentacoesPorMinerioPorPeriodo(ano, mes);
            return Ok(movimentacoes);
        }

        [HttpPost]
        [Route("saida")]
        [ProducesResponseType(typeof(RespostaPadrao),(int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(RespostaPadrao), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> RegistraSaidaCargueiro(SaidaCargueiroCommand command)
        {
            RespostaPadrao resposta = (RespostaPadrao)await _handler.Handle(command);
            if (resposta.Sucesso)
                return Ok(resposta);
            return BadRequest(resposta);            
        }

        [HttpPost]
        [Route("retorno")]
        [ProducesResponseType(typeof(RespostaPadrao), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(RespostaPadrao), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> RegistraRetornoCargueiro(RetornoCargueiroCommand command)
        {
            RespostaPadrao resposta = (RespostaPadrao)await _handler.Handle(command);
            if (resposta.Sucesso)
                return Ok(resposta);
            return BadRequest(resposta);
        }
    }
}