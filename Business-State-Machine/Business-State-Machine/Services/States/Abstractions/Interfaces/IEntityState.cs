using Business_State_Machine.Services.States.Enums;

namespace Business_State_Machine.Services.States.Abstractions.Interfaces
{
    public class IEntityState
    {
        private int StateId { get; set; }
        public string StateName { get; set; }
        public StateStatus State { get; set; }
    }
}
