using Business_State_Machine.Services.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Business_State_Machine.Controllers.Abstracts
{
    public class BaseController<IService, T> : Controller where IService : ServiceBase<T> where T : class
    {
        public IService Service { get; set; }

        public BaseController(IService service) =>
            Service = service;

        [HttpGet("api/{id}")]
        public virtual async Task<IActionResult> Id(int id) =>
            Ok(await Service.FindById(id));

        [HttpGet("api")]
        public virtual async Task<IActionResult> GetAll(int? page) =>
            Ok(await Service.GetAll(page));
    }
}
