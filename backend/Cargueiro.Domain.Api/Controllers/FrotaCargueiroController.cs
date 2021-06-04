using Cargueiro.Domain.Application.Repositorios;
using Cargueiro.Domain.Entidades;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

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
        [Route("")]
        public IEnumerable<FrotaCargueiro> Todas()
        {
            return _frotaRepositorio.TodasFrotas();
        }
    }
}