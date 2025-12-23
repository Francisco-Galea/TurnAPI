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

    }
}
