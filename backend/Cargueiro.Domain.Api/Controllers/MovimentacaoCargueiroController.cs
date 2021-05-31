using Microsoft.AspNetCore.Mvc;
using Cargueiro.Domain.Commands;
using Cargueiro.Domain.Handlers;
using System.Threading.Tasks;
using System.Collections.Generic;
using Cargueiro.Domain.Entidades;
using Cargueiro.Domain.Repositorios;
using AutoMapper;

namespace Cargueiro.Domain.Api.Controllers
{
    [ApiController]
    [Route("v1/cargueiro/movimentacao")]
    public class MovimentacaoCargueiroController : ControllerBase
    {
        private readonly MovimentacaoCargueiroHandler _handler;
        private readonly IMovimentacaoCargueiroRepositorio _repositorio;
        private readonly IFrotaCargueiroRepositorio _frotaRepositorio;
        private readonly IMapper _mapper;
        public MovimentacaoCargueiroController(
            MovimentacaoCargueiroHandler handler,
            IMovimentacaoCargueiroRepositorio repositorio,
            IFrotaCargueiroRepositorio frotaCargueiroRepositorio,
            IMapper mapper)
        {
            _handler = handler;
            _repositorio = repositorio;
            _mapper = mapper;
            _frotaRepositorio = frotaCargueiroRepositorio;
        }

        [HttpGet]
        [Route("CargaInicial")]
        public void CargaInicial()
        {
            _frotaRepositorio.CargaInicialFrota();
        }
        [HttpGet]
        [Route("Frotas")]
        public IEnumerable<FrotaCargueiro> Frotas()
        {
            return _frotaRepositorio.TodasFrotas();
        }

        [HttpGet]
        [Route("todas")]
        public async Task<IEnumerable<MovimentacaoCargueiro>> TodasMovimentacoes()
        {
            return await _repositorio.RetornaTodasMovimentacoes();
        }

        [HttpGet]
        [Route("paginado")]
        public IResultadoPaginado<MovimentacaoCargueiro> MovimentacoesPaginado(int ano, int mes, int numeroPagina = 1)
        {
            return _repositorio.RetornaMovimentacoesPaginado(numeroPagina, 10, ano, mes);
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