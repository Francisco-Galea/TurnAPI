namespace TurnApi.Models
{
    public class AgendaSchedule
    {
        public int agendaScheduleId {  get; set; }
        public int agendaId { get; set; }
        public string workableDay { get; set; }
        public DateTime turnInit {  get; set; }
        public DateTime turnEnd { get; set; }
    }
}
