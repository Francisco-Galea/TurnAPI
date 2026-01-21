namespace TurnApi.DTOs.Request
{
    public class CreateTurnRequest
    {
        public int agendaId { get; set; }
        public int accountClientId { get; set; }
        public DateOnly turnDate {  get; set; }
        public TimeOnly turnInit { get; set; }
        public string notes { get; set; }
    }
}
