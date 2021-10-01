using Bogus;
using Bogus.Extensions.Brazil;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MongoDB.Collections;
using MongoDB.Repository;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MongoDB.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NotaFiscalController : ControllerBase
    {
        private readonly NotaFiscalRepository notaFiscalRepository;

        public NotaFiscalController()
        {
            notaFiscalRepository = new NotaFiscalRepository();
        }

        [HttpPost]
        public void SalvarNotasFiscaisFaker()
        {
            var faker = new Faker<NotaFiscal>()
                .RuleFor(x => x.Numero, x => x.Random.Int(100000, 999999))
                .RuleFor(x => x.CriadoPor, x => x.Person.FirstName)
                .RuleFor(x => x.Cnpj, x => x.Company.Cnpj())
                .RuleFor(x => x.DataEmissao, x => x.Date.Between(new DateTime(2020,01,01), new DateTime(2020, 01, 31)));

            var notasFiscais = faker.Generate(50);

            notaFiscalRepository.Salvar(notasFiscais);
        }

        [HttpGet]
        [Route("Count")]
        public long GetContagem()
        {
            return notaFiscalRepository.Quantidade();
        }

        [HttpGet]
        public async Task<IEnumerable<NotaFiscal>> GetAll()
        {
            return await notaFiscalRepository.ListarTodas();
        }

        [HttpGet]
        [Route("PorId")]
        public NotaFiscal GetPorId(Guid id)
        {
            return notaFiscalRepository.ObterPorId(id);
        }

        [HttpGet]
        [Route("PorNumeros")]
        public IEnumerable<NotaFiscal> GetPorNumeros([FromQuery] int[] numeros)
        {
            return notaFiscalRepository.ListarPorNumeros(numeros);
        }

        [HttpGet]
        [Route("PorChave")]
        public NotaFiscal GetPorChave(int numero, string cnpj)
        {
            return notaFiscalRepository.ObterPorChave(numero, cnpj);
        }

        [HttpDelete]
        public bool Delete(Guid id)
        {
            return notaFiscalRepository.Deletar(id);
        }
    }
}
