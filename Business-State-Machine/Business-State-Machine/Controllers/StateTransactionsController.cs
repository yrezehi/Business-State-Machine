using Business_State_Machine.Controllers.Abstracts;
using Business_State_Machine.Models;
using Business_State_Machine.Services.States;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Business_State_Machine.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StateTransactionsController : BaseController<StateTransactionsService, StateTransaction>
    {
        public StateTransactionsController(StateTransactionsService Service) : base(Service) { }
    }
}