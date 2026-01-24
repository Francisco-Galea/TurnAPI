namespace TurnApi.DTOs.Response
{
    public class AgendaResponse
    {
        //public string CompanyName { get; set; }
        //public int accountEmployeeId { get; set; }
        public int appointmentDurationInMinutes { get; set; }
        public TimeOnly appointmentInit { get; set; }
        public TimeOnly appointmentEnd { get; set; }
        public List<AvailableAppointmentResponse> availableappointment { get; set; }
    }
}
