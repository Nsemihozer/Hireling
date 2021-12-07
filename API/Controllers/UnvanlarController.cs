using Application.Unvans;
using Domain;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class UnvanlarController:BaseApiController
    {
         [HttpGet]
        public async Task<ActionResult<List<Unvanlar>>> GetUnvanlar()
        {
            return await Mediator.Send(new List.Query());
        }
    }
}