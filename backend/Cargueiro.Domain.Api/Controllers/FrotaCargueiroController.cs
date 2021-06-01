using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Cargueiro.Domain.Entidades;
using Cargueiro.Domain.Repositorios;

namespace Cargueiro.Domain.Api.Controllers
{
    [ApiController]
    [Route("v1/cargueiro/frota")]
    public class FrotaCargueiroController : ControllerBase
    {
        private readonly IFrotaCargueiroRepositorio _frotaRepositorio;
        public FrotaCargueiroController(
            IFrotaCargueiroRepositorio frotaCargueiroRepositorio)
        {
            _frotaRepositorio = frotaCargueiroRepositorio;
        }

        [HttpGet]
        [Route("cargaInicial")]
        public void CargaInicial()
        {
            _frotaRepositorio.CargaInicialFrota();
        }
        [HttpGet]
        [Route("")]
        public IEnumerable<FrotaCargueiro> Todas()
        {
            return _frotaRepositorio.TodasFrotas();
        }
    }
}