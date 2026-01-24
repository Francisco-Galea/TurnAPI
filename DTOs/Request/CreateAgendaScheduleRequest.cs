namespace TurnApi.DTOs.Request
{
    public class CreateAgendaScheduleRequest
    {
        public int agendaId { get; set; }
        public string workableDay { get; set; }
        public TimeOnly appointmentInit { get; set; }
        public TimeOnly appointmentEnd { get; set; }
        public int appointmentDurationInMinutes { get; set; }

    }
}
