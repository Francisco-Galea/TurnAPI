namespace TurnApi.DTOs.Request
{
    public class CreateAgendaScheduleRequest
    {
        public int agendaId { get; set; }
        public string workableDay { get; set; }
        public DateTime turnInit { get; set; }
        public DateTime turnEnd { get; set; }
    }
}
