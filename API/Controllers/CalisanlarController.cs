using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence;
using MediatR;
using Application.Calisans;
using System.Text.Json.Nodes;
using System.Text.Json;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace API.Controllers
{
    [AllowAnonymous]
    public class CalisanlarController : BaseApiController
    {
        private readonly UserManager<Calisanlar> userManager;
        public CalisanlarController(UserManager<Calisanlar> userManager)
        {
            this.userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> GetCalisanlar()
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
        public async Task<IActionResult> CreateCalisan(JsonObject calisanJson)
        {
            var calisan = JsonSerializer.Deserialize<CalisanDto>(calisanJson["calisanData"]);
            var password = calisanJson["password"].ToString();
            if (await userManager.Users.AnyAsync(u => u.UserName == calisan.UserName))
            {
                ModelState.AddModelError("UserName", "Kullanıcı Adı Alınmış");
                return ValidationProblem(ModelState);

            }
            
            if (await userManager.Users.AnyAsync(u => u.Email == calisan.Email))
            {
                ModelState.AddModelError("Email", "Eposta  Alınmış");
                return ValidationProblem(ModelState);
            }
            var result = await Mediator.Send(new Create.Command { Calisan = calisan, password = password });
            return HandleResult(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCalisan(int id, CalisanDto calisan)
        {
            calisan.Id = id;
            var users = await userManager.Users.ToListAsync();
            if (users.Where(u => u.UserName == calisan.UserName && u.Id != id).ToList().Count > 0)
            {
                ModelState.AddModelError("UserName", "Kullanıcı Adı Alınmış");
                return ValidationProblem(ModelState);

            }
            if (users.Where(u => u.Email == calisan.Email && u.Id != id).ToList().Count > 0)
            {
                ModelState.AddModelError("Email", "Eposta  Alınmış");
                return ValidationProblem(ModelState);
            }
            return HandleResult(await Mediator.Send(new Edit.Command { Calisan = calisan }));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCalisan(int id)
        {

            return HandleResult(await Mediator.Send(new Delete.Command { CalisanID = id }));
        }
    }
}