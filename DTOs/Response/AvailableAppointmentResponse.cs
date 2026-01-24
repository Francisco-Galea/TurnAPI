using TurnApi.Models.Enums;

namespace TurnApi.DTOs.Response
{
    public class AvailableAppointmentResponse
    {
        public TimeOnly appointmentInit {  get; set; }
        public TimeOnly appointmentEnd { get; set; }
        public ShiftStateEnum shiftState {  get; set; } 
    }
}
