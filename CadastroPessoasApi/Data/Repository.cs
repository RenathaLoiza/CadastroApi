using CadastroPessoasApi.ViewModel;
using Dapper;
using System.Data.SqlClient;

namespace CadastroPessoasApi.Data
{
    public class Repository
    {
        string conexao = @"Server=(localdb)\mssqllocaldb;Database=CadastroPessoa;Trusted_Connection=True;MultipleActiveResultSets=True";

       

        //vamos fazer os insert aqui
        public IEnumerable<PessoaViewModel> GetAll()
        {
            string query = "select top 100 * FROM Pessoas";
            using (SqlConnection con = new SqlConnection(conexao))
            {
                return con.Query<PessoaViewModel>(query);
            }
        }
        public PessoaViewModel GetById(int PessoaId)
        {
            string query = "Select *FROM PESSOAS WHERE PessoaId=@PessoaId";
            using (SqlConnection con = new SqlConnection(conexao))
            {
                return con.QueryFirstOrDefault<PessoaViewModel>(query, new { PessoaId =PessoaId });
            }

        }
        public PessoaViewModel GetByPrimeiroNome(string PrimeiroNome)
        {
            string query = "select * from pessoas where primeiroNome =@PrimeiroNome";
            using (SqlConnection con = new SqlConnection(conexao))
            {
                return con.QueryFirstOrDefault<PessoaViewModel>(query, new { PrimeiroNome = PrimeiroNome });
            }
            
        }

        public void Update(int PessoaId, string PrimeiroNome)
        {
            string query = "Update Pessoas set PrimeiroNome = @PrimeiroNome where PessoaId = @PessoaId";

            using (SqlConnection con = new SqlConnection(conexao))
            {
                 con.Execute(query, new { PessoaId = PessoaId, PrimeiroNome = PrimeiroNome });
            }
        }
        public string Create(PessoaViewModel pessoas)
        {
            try
            {
                string query = @"INSERT INTO Pessoas (PrimeiroNome, NomeMeio, UltimoNome, CPF) VALUES (@primeiroNome, @nomeMeio,@ultimoNome, @cpf)";
                using (SqlConnection con = new SqlConnection(conexao))
                {
                    con.Execute(query, new
                    {
                        primeiroNome = pessoas.PrimeiroNome,
                        nomeMeio = pessoas.NomeMeio,
                        ultimoNome = pessoas.UltimoNome,
                        cpf = pessoas.CPF,
                    });


                }
                return null;
            }
            catch (Exception ex) 
            {
                throw ex;
            }
        }
}
}
