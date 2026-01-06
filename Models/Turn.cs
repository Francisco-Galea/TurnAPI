namespace TurnApi.Models
{
    public sealed class Turn
    {
        public int turnId { get; set; }
        public int agendaId { get; set; }
        public int accountClientId { get; set; }
        public int accountEmployeeId { get; set; }
        public DateTime turnStart { get; set; }
        public DateTime turnEnd { get; set; }
        public string status { get; set; }
        public string notes { get; set; }
    }
}
