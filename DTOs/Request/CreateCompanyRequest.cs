namespace TurnApi.DTOs.Request
{
    public sealed class CreateCompanyRequest
    {
        public int founderAccountId { get; set; }
        public string companyName { get; set; }
        public string socialReason { get; set; }
        public string cuit {  get; set; }
    }
}
