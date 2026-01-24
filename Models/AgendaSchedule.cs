namespace TurnApi.Models
{
    public class AgendaSchedule
    {
        public int agendaScheduleId {  get; set; }
        public int agendaId { get; set; }
        public string workableDay { get; set; }
        public TimeOnly appointmentInit {  get; set; }
        public TimeOnly appointmentEnd { get; set; }
        public int appointmentDurationInMinutes { get; set; }
    }
}
