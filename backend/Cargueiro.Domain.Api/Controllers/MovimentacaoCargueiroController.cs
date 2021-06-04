using AutoMapper;
using Cargueiro.Domain.Application.Commands;
using Cargueiro.Domain.Application.Handlers;
using Cargueiro.Domain.Application.Repositorios;
using Cargueiro.Domain.Entidades;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace Cargueiro.Domain.Api.Controllers
{
    [ApiController]
    [Route("v1/cargueiro/movimentacao")]
    public class MovimentacaoCargueiroController : ControllerBase
    {
        private readonly MovimentacaoCargueiroHandler _handler;
        private readonly IMovimentacaoCargueiroRepositorio _repositorio;
        private readonly IMapper _mapper;
        public MovimentacaoCargueiroController(
            MovimentacaoCargueiroHandler handler,
            IMovimentacaoCargueiroRepositorio repositorio,
            IMapper mapper)
        {
            _handler = handler;
            _repositorio = repositorio;
            _mapper = mapper;
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