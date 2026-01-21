using Dapper;
using Microsoft.Data.SqlClient;
using TurnApi.DTOs.Request;
using TurnApi.Models;
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
                using var connection = new SqlConnection(connectionString);
                var queryAccount = "INSERT INTO Accounts (Document, Password, Name, LastName, PhoneNumber) " +
                                   "VALUES (@Document, @Password, @Name, @LastName, @PhoneNumber)";
                connection.Query(queryAccount, new
                {
                    Document = accountRequest.document,
                    Password = accountRequest.password,
                    Name = accountRequest.name,
                    LastName = accountRequest.lastName,
                    PhoneNumber = accountRequest.phoneNumber,
                });
            }
            catch (SqlException)
            {
                throw new Exception("Ocurrio un error al crear el usuario, intente nuevamente más tarde");
            }
            catch(Exception) 
            {
                throw new Exception("Ocurrio un error inesperado al comunicarse con la base de datos");
            }
        }

        public void AccountAlreadyExist(int document)
        {
            try
            {
                using var connection = new SqlConnection(connectionString);
                var query = "SELECT 1 WHERE NOT EXISTS (SELECT 1 FROM Accounts WHERE Document = @Document)";
                connection.QueryFirst(query, new { Document = document });
            }
            catch (InvalidOperationException)
            { 
                throw new InvalidOperationException("Este documento ya se encuentra registrado");
            }
            catch (Exception)
            {
                throw new Exception("Ocurrio un error inesperado al comunicarse con la base de datos");
            }
        }

        public void CreateTurn(Turn turn)
        {
            try
            {
                using var connection = new SqlConnection(connectionString);
                var query = "INSERT INTO Turns (AgendaId, ClientId, TurnDate, TurnInit, TurnEnd) " +
                            "VALUES " +
                            "(@AgendaId, @ClientId, @TurnDate, @TurnInit, @TurnEnd);";
                connection.Query(query, new 
                    {
                        AgendaId = turn.agendaId, 
                        ClientId = turn.accountClientId,
                        TurnDate = turn.turnDate,
                        TurnInit = turn.turnInit,
                        TurnEnd = turn.turnEnd
                    });
            }
            catch
            {
                throw new NotImplementedException();
            }
        }

    }
}
