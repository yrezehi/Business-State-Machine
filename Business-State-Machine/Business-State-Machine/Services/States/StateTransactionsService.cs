using Business_State_Machine.Models;
using Business_State_Machine.Repositories.Abstracts.Interfaces;
using Business_State_Machine.Services.Abstract;
using static System.Net.Mime.MediaTypeNames;

namespace Business_State_Machine.Services.States
{
    public class StateTransactionsService : ServiceBase<StateTransaction>
    {
        public StateTransactionsService(IUnitOfWork unitOfWork) : base(unitOfWork) { }
    }
}
