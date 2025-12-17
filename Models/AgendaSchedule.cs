namespace TurnApi.Models
{
    public class AgendaSchedule
    {
        public int agendaScheduleId {  get; set; }
        public int agendaId { get; set; }
        public List<string> workableDays { get; set; }
        public DateTime turnInit {  get; set; }
        public DateTime turnEnd { get; set; }
    }
}
