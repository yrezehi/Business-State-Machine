using Business_State_Machine.Seriveces.States.Enums;

namespace Business_State_Machine.Seriveces.States.Abstractions.Interfaces
{
    public class IEntityState
    {
        private int StateId { get; set; }
        public string StateName { get; set; }
        public StateStatus State { get; set; }
    }
}
