using Dapper;
using Microsoft.Data.SqlClient;
using TurnApi.DTOs.Request;
using TurnApi.DTOs.Response;
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
                connection.Query(query, new
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

        public void HireEmployee(HireOrFireEmployeeRequest hireOrFireEmployeeRequest)
        {
            try
            {
                using var connection = new SqlConnection(connectionString);
                var query = "INSERT INTO Employees " +
                            "(PositionInCompany, DescriptionOfPosition ,AccountId, CompanyId)" +
                            "VALUES " +
                            "(@PositionInCompany, @DescriptionOfPosition, @AccountId, @CompanyId)";
                connection.Query(query, new
                {
                    PositionInCompany = hireOrFireEmployeeRequest.positionInCompany,
                    DescriptionOfPosition = hireOrFireEmployeeRequest.descriptionOfPosition,
                    AccountId = hireOrFireEmployeeRequest.accountId,
                    CompanyId = hireOrFireEmployeeRequest.companyId,
                });
            }
            catch
            {
                throw new NotImplementedException();
            }
        }

        public void FireEmployee(int companyId, int accountId)
        {
            using var connection = new SqlConnection(connectionString);
            var query = "UPDATE Employees SET IsActive = 0 " +
                        "WHERE CompanyId = @CompanyId AND AccountId = @AccountId";
            connection.Query(query, new { CompanyId = companyId, AccountId = accountId });
        }

        public List<EmployeeResponse> GetAllHiredEmployees(int companyId)
        {
            try
            {
                using var connection = new SqlConnection(connectionString);
                var query = "SELECT Name, LastName, PhoneNumber FROM Accounts " +
                            "INNER JOIN Employees ON Accounts.AccountId = Employees.AccountId " +
                            "WHERE Employees.IsActive = 1"; 
                return connection.Query<EmployeeResponse>(query, new {CompanyId = companyId}).ToList();
            }
            catch
            {
                throw new NotImplementedException();
            }
        }

    }
}
