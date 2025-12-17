namespace TurnApi.Models
{
    public class Agenda
    {
        public int agendaId {  get; set; }
        public int companyId { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public int turnDurationInMinutes { get; set; }
        public bool isActive { get; set; }
    }
}
