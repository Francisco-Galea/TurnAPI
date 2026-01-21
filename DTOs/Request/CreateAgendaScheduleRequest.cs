namespace TurnApi.DTOs.Request
{
    public class CreateAgendaScheduleRequest
    {
        public int agendaId { get; set; }
        public string workableDay { get; set; }
        public TimeOnly turnInit { get; set; }
        public TimeOnly turnEnd { get; set; }
    }
}
