namespace TurnApi.DTOs.Response
{
    public class AgendaResponse
    {
        //public string CompanyName { get; set; }
        //public int accountEmployeeId { get; set; }
        public int turnDurationInMinutes { get; set; }
        public TimeOnly turnInit { get; set; }
        public TimeOnly turnEnd { get; set; }
        public List<AvailableTurnResponse> availableTurns { get; set; }
    }
}
