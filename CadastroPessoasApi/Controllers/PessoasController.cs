using CadastroPessoasApi.Service;
using CadastroPessoasApi.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

namespace CadastroPessoasApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PessoasController : ControllerBase
    {
        [HttpGet("GetAll")]
        public IEnumerable<PessoaViewModel> GetAll()
        {
            var Service = new ServicePessoa();
            return Service.GetAll();
        }
        [HttpGet("GetById/{PessoaId}")]
        public PessoaViewModel GetById(int PessoaId)
        {
            var service = new ServicePessoa();
            return service.GetById(PessoaId);
        }
        [HttpGet("GetByPrimeiroNome/{PrimeiroNome}")]
        public PessoaViewModel GetByPrimeiroNome(string PrimeiroNome)
        {
            var service = new ServicePessoa();
            return service.GetByPrimeiroNome(PrimeiroNome);
        }

        [HttpPut("Update/{pessoaId}/{primeiroNome}")]
        public void Update(int pessoaId, string primeiroNome)
        {
            var service = new ServicePessoa();
            service.Update(pessoaId, primeiroNome);
        }
        [HttpPost("Create")]
        public ActionResult Create(PessoaViewModel pessoa)
        {
            var service = new ServicePessoa();
            var resultado = service.Create(pessoa);

            var result = new
            {
                success = true,
                Data = resultado,
            };
             return Ok (result);
        }



    }

}


