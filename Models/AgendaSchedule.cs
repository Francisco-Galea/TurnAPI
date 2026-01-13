namespace TurnApi.Models
{
    public class AgendaSchedule
    {
        public int agendaScheduleId {  get; set; }
        public int agendaId { get; set; }
        public string workableDay { get; set; }
        public TimeOnly turnInit {  get; set; }
        public TimeOnly turnEnd { get; set; }
    }
}
