namespace Business_State_Machine.Models
{
    public class StateTransaction
    {
        public int Id { get; set; }
        public string State { get; set; }
        public string PreviousState { get; set; }
        public DateTime Occurrence { get; set; }
    }
}
