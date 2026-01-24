namespace TurnApi.DTOs.Request
{
    public class CreateAppointmentRequest
    {
        public int agendaId { get; set; }
        public int accountClientId { get; set; }
        public DateOnly appointmentDate {  get; set; }
        public TimeOnly appointmentInit { get; set; }
        public string notes { get; set; }
    }
}
