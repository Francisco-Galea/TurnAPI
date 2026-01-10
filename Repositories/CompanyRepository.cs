using Dapper;
using Microsoft.Data.SqlClient;
using TurnApi.DTOs.Request;
using TurnApi.Models;
using TurnApi.Repositories.Interface;

namespace TurnApi.Repositories
{
    public class CompanyRepository : ICompanyRepository
    {

        private IConfiguration configuration { get; }
        private string connectionString { get; }

        public CompanyRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
            this.connectionString = this.configuration["ConnectionStrings:SQLSERVER"];
        }

        public void CreateCompanyRequest(CreateCompanyRequest createCompanyRequest)
        {
            try
            {
                using var connection = new SqlConnection(connectionString);
                var query = "INSERT INTO Companies (CompanyName, FounderAccountId, Cuit, SocialName) VALUES" +
                            "(@CompanyName, @FounderAccountId, @Cuit, @SocialName)";
                connection.Execute(query, new
                {
                    CompanyName = createCompanyRequest.companyName,
                    FounderAccountId = createCompanyRequest.founderAccountId,
                    Cuit = createCompanyRequest.cuit,
                    SocialName = createCompanyRequest.socialReason
                });
            }
            catch(Exception) 
            {
                throw new NotImplementedException();
            }
        }

        public void VerifyCompanyAlreadyExist(string socialReason)
        {
            try
            {
                using var connection = new SqlConnection(connectionString);
                var query = "SELECT 1 WHERE NOT EXISTS " +
                            "(SELECT 1 FROM Companies WHERE SocialName = @SocialName)";
                connection.QueryFirst(query, new {SocialName = socialReason });
            }
            catch(InvalidOperationException) 
            {
                throw new InvalidOperationException("Esta empresa ya se encuentra registrada");
            }
            catch (Exception)
            {
                throw new Exception("Error al conectarse a la base de datos");
            }
        }

        public void HireEmployee(int companyId, int accountId)
        {
            try
            {
                using var connection = new SqlConnection(connectionString);
                var query = "INSERT INTO Employees (AccountId, CompanyId)" +
                            "VALUES (@AccountId, @CompanyId)";
                connection.Execute(query, new
                {
                    AccountId = accountId,
                    CompanyId = companyId,
                });
            }
            catch
            {
                throw new NotImplementedException();
            }
        }

        public void FireEmployee(int companyId, int accountId)
        {
            throw new NotImplementedException();
        }

        public List<Account> GetAllEmployees(int companyId)
        {
            try
            {
                using var connection = new SqlConnection(connectionString);
                var query = "SELECT Name, LastName, PhoneNumber FROM Accounts " +
                            "INNER JOIN Employees ON Accounts.AccountId = Employees.AccountId"; 
                return connection.Query<Account>(query, new {CompanyId = companyId}).ToList();
            }
            catch
            {
                throw new NotImplementedException();
            }
        }
    }
}
