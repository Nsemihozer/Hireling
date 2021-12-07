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
            return await Mediator.Send(new List.Query());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Calisanlar>> GetCalisan(int id)
        {
            return await Mediator.Send(new Details.Query{CalisanID=id});
        }

        [HttpPost]
        public async Task<IActionResult> CreateCalisan(Calisanlar calisan)
        {
            return Ok(await Mediator.Send(new Create.Command{Calisan=calisan}));
        }

         [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCalisan(int id, Calisanlar calisan)
        {
            calisan.CalisanID=id;
            return Ok(await Mediator.Send(new Edit.Command{Calisan=calisan}));
        }

         [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCalisan(int id)
        {
           
            return Ok(await Mediator.Send(new Delete.Command{CalisanID=id}));
        }
    }
}