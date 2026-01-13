namespace TurnApi.DTOs.Request
{
    public class HireOrFireEmployeeRequest
    {
        public string positionInCompany { get; set; }
        public string descriptionOfPosition { get; set; }
        public int accountId { get; set; }
        public int companyId { get; set; }
    }
}
