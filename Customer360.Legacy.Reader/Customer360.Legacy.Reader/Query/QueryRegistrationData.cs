using System.Threading.Tasks;
using Api.Infraestrutura.Core.Dapper;
using Customer360.Legacy.Reader.Contract;

namespace Customer360.Legacy.Reader.Query
{
    public class QueryRegistrationData : IQuery<RegistrationData>
    {
        private readonly long _customerDocument;
        private readonly string _sqlInstruction = @"
                    SELECT 
                        p.NomePessoa customerName
                        , ISNULL(pj.Cnpj, pf.Cpf) customerDocument
                        , ISNULL(pj.DATAABERTURA, pf.DATANASCIMENTO) bornDate
                        , c.MatriculaId registrationId
                        , P.PessoaId ExternalId
            
                        , endereco.EnderecoId addressId, endereco.Logradouro streetAddress
                        , endereco.Numero homeNumber, endereco.Complemento addressComplement
                        , endereco.Cidade city, endereco.Uf State, endereco.Cep postalCode

                        , tel.telefoneId phoneId, tel.ddd, tel.NUMERO phoneNumber

                        , email.emailId emailId, email.enderecoEmail remoteAddress, email.TIPOEMAILID EmailType

                    FROM Cliente c
                        INNER JOIN pessoa p ON c.PESSOAID = p.PESSOAID
                        LEFT JOIN PessoaFisica pf ON pf.PessoaId = p.PessoaId
                        LEFT JOIN PessoaJuridica pj ON pj.PessoaId = p.PessoaId  
                        INNER JOIN Endereco endereco ON endereco.PessoaId = p.PessoaId  and endereco.Ativo = 1
                        INNER JOIN Telefone tel on tel.PESSOAID = p.PESSOAID and tel.Ativo = 1
                        INNER JOIN Email email on email.PESSOAID = p.PESSOAID AND email.Ativo = 1                   
                    WHERE ISNULL(pj.Cnpj, pf.Cpf) = @customerDocument";


        //
        public QueryRegistrationData(long customerDocument)
        {
            _customerDocument = customerDocument;
        }

        public async Task<RegistrationData> ExecuteAsync(IQueryExecutor query)
        {
            RegistrationData registrationData = null;

           await query.QueryAsync<RegistrationData>(
               new[]
               {
                   typeof(RegistrationData),
                   typeof(Address),
                   typeof(Phone),
                   typeof(Email)
               },
               objects =>
               {
                   var registration = objects[0] as RegistrationData;
                   var address = objects[1] as Address;
                   var phone = objects[2] as Phone;
                   var email = objects[3] as Email;

                   if (registrationData == null)
                       registrationData = registration;

                   registrationData.InsertAddress(address);
                   registrationData.InsertPhone(phone);
                   registrationData.InsertEmail(email);

                   return registrationData;

               },
               s =>
               {
                   s.WithCommandText(_sqlInstruction)
                       .WithParameters(new { customerDocument = _customerDocument });
               },
               splitOn: "AddressId, PhoneId, EmailId");


            return registrationData;

        }
    }
}
