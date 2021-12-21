using Application.Unvans;
using Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [AllowAnonymous]
    public class UnvanlarController:BaseApiController
    {
         [HttpGet]
        public async Task<ActionResult> GetUnvanlar()
        {
            var result= await Mediator.Send(new List.Query());
             return HandleResult(result);
        }
    }
}