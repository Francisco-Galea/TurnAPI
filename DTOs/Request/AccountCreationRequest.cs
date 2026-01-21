namespace TurnApi.DTOs.Request
{
    public sealed class AccountCreationRequest
    {
        public int document {  get; set; }
        public string name { get; set; }
        public string lastName { get; set; }
        public string password { get; set; }
        public string phoneNumber { get; set; }
    }
}
