namespace TurnApi.Models
{
    public sealed class Turn
    {
        public int turnId { get; set; }
        public int agendaId { get; set; }
        public int clientId { get; set; }
        public int employeeId { get; set; }
        public DateTime turnStart { get; set; }
        public DateTime turnEnd { get; set; }
        public string status { get; set; }
        public string notes { get; set; }
    }
}
