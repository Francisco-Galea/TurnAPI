namespace TurnApi.DTOs.Request
{
    public class CreateAgendaRequest
    {
        public int companyId {  get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public int turnDurationInMinutes { get; set; }
    }
}
