namespace TurnApi.Models
{
    public class Employee
    {
        public Account Account { get; set; }
        public Company Company { get; set; }
        public string name { get; set; }
        public string lastName { get; set; }
        public int documentation { get; set; }
        public string phoneNumber { get; set; }
        public string email { get; set; }
    }
}
