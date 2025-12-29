using Dapper;
using Microsoft.Data.SqlClient;
using TurnApi.DTOs.Request;
using TurnApi.Repositories.Interface;

namespace TurnApi.Repositories
{
    internal sealed class AccountRepository : IAccountRepository
    {

        private IConfiguration configuration { get; }
        private string connectionString { get; }

        public AccountRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
            this.connectionString = this.configuration["ConnectionStrings:SQLSERVER"];
        }

        public void CreateAccount(AccountCreationRequest accountRequest)
        {
            try
            {
                var connection = new SqlConnection(connectionString);
                var queryAccount = "INSERT INTO Accounts (Email, Password) VALUES (@Email, @Password)";
                connection.Execute(queryAccount, accountRequest);
                
            }
            catch
            {

            }
            finally
            {

            }
        }

        public void AccountAlreadyExist(AccountCreationRequest accountRequest)
        {
            try
            {
                using var connection = new SqlConnection(connectionString);
                var query = "SELECT 1 WHERE NOT EXISTS (SELECT 1 FROM Accounts WHERE Email = @Email)";
                var accountFounded = connection.QueryFirst(query, new { Email = accountRequest.email });
            }
            catch(InvalidOperationException)
            { 
                throw new InvalidOperationException("El email ya se encuentra en uso!");
            }
        }

    }
}
