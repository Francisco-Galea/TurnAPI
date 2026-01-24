using TurnApi.Models.Enums;

namespace TurnApi.Models
{
    public sealed class Appointment
    {
        public int turnId { get; set; }
        public int agendaId { get; set; }
        public int accountClientId { get; set; }
        public DateOnly appointmentDate {  get; set; }
        public TimeOnly appointmentInit { get; set; }
        public TimeOnly appointmentEnd { get; set; }
        public AppointmentStateEnum appointmentState { get; set; }
        public string notes { get; set; }
    }
}
