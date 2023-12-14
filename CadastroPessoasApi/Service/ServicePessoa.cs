
using CadastroPessoasApi.Data;
using CadastroPessoasApi.ViewModel;
using Microsoft.AspNetCore.Http.Connections;
using System.Linq;

namespace CadastroPessoasApi.Service
{
    public class ServicePessoa
    {
        public object PessoaId { get; private set; }

        public IEnumerable<PessoaViewModel> GetAll()
        {
            var repository = new Repository();
            return repository.GetAll().ToList();

        }

        public  PessoaViewModel GetById(int PessoaId)
        {
            var Repository = new Repository();
            return Repository.GetById(PessoaId);
        }
        public PessoaViewModel GetByPrimeiroNome(string PrimeiroNome)
        {
            var Repository = new Repository();
            return Repository.GetByPrimeiroNome(PrimeiroNome);

        }

        public void Update(int PessoaId, string PrimeiroNome)
        {
            var Repository = new Repository();
            Repository.Update(PessoaId, PrimeiroNome);


        }
        public string Create(PessoaViewModel pessoa)
        {
            if (pessoa == null)
                return "Os dados são obrigatorios";
            if (pessoa != null && string.IsNullOrEmpty(pessoa.NomeMeio))
                return "O campo NomeMeio é obrigatorio";
            if (pessoa != null && string.IsNullOrEmpty(pessoa.UltimoNome))
                return "O campo UltimoNome é obrigatorio";
            if (pessoa != null && string.IsNullOrEmpty(pessoa.CPF))
                return "O campo CPF é obrigatorio";

            var repository = new Repository();
            return repository.Create(pessoa);
            

        }


    }
}
