using TurnApi.Models.Enums;

namespace TurnApi.DTOs.Response
{
    public class AvailableTurnResponse
    {
        public TimeOnly turnInit {  get; set; }
        public TimeOnly turnEnd { get; set; }
    }
}
