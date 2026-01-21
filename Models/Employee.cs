namespace TurnApi.Models
{
    internal sealed class Employee
    {
        public int employeeId { get; set; }
        public string positionInCompany {  get; set; }
        public string descriptionOfPosition {  get; set; }
        public int accountId {  get; set; }
        public int companyId { get; set; }
    }
}
