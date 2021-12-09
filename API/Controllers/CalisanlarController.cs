using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence;
using MediatR;
using Application.Calisans;

namespace API.Controllers
{
    public class CalisanlarController : BaseApiController
    {


        [HttpGet]
        public async Task<ActionResult<List<Calisanlar>>> GetCalisanlar()
        {
            var result = await Mediator.Send(new List.Query());
            return HandleResult(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCalisan(int id)
        {
            var result = await Mediator.Send(new Details.Query { CalisanID = id });
            return HandleResult(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCalisan(Calisanlar calisan)
        {
           var result = await Mediator.Send(new Create.Command { Calisan = calisan });
           return HandleResult(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCalisan(int id, Calisanlar calisan)
        {
            calisan.CalisanID = id;
            return HandleResult(await Mediator.Send(new Edit.Command { Calisan = calisan }));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCalisan(int id)
        {

            return HandleResult(await Mediator.Send(new Delete.Command { CalisanID = id }));
        }
    }
}