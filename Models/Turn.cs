using TurnApi.Models.Enums;

namespace TurnApi.Models
{
    public sealed class Turn
    {
        public int turnId { get; set; }
        public int agendaId { get; set; }
        public int accountClientId { get; set; }
        public DateOnly turnDate {  get; set; }
        public TimeOnly turnInit { get; set; }
        public TimeOnly turnEnd { get; set; }
        public string notes { get; set; }
    }
}
