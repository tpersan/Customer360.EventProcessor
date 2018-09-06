using System.Threading.Tasks;
using Api.Infraestrutura.Core.Dapper;
using Customer360.Legacy.Entities;

namespace Customer360.Legacy.Reader.Query
{
    public class QueryRegistrationData : IQuery<RegistrationData>
    {
        private readonly long _customerDocument;
        private readonly string _sqlInstruction = @"
                    SELECT
                    p.NomePessoa customerName,
                        ISNULL(pj.Cnpj, pf.Cpf) customerDocument,
                        ISNULL(pj.DATAABERTURA, pf.DATANASCIMENTO) bornDate,
                        c.MatriculaId,
                    P.PessoaId ExternalIdentifier

                    FROM Cliente c
                        INNER JOIN pessoa p ON c.PESSOAID = p.PESSOAID
                    LEFT JOIN PessoaFisica pf ON pf.PessoaId = p.PessoaId
                    LEFT JOIN PessoaJuridica pj ON pj.PessoaId = p.PessoaId
                    WHERE ISNULL(pj.Cnpj, pf.Cpf) = @customerDocument";


        public QueryRegistrationData(long customerDocument)
        {
            _customerDocument = customerDocument;
        }

        public async Task<RegistrationData> ExecuteAsync(IQueryExecutor query)
        {
            return (await query.QuerySingleAsync<RegistrationData>(s =>
            {
                s.WithCommandText(_sqlInstruction)
                 .WithParameters(_customerDocument);
            }));
        }
    }
}
