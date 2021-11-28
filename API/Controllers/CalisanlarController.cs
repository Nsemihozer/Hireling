using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace API.Controllers
{
    public class CalisanlarController : BaseApiController
    {
        private readonly DataContext context;
        public CalisanlarController(DataContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Calisanlar>>> GetCalisanlar()
        {
            return await context.Calisanlar.ToListAsync();
        }

          [HttpGet("{id}")]
        public async Task<ActionResult<Calisanlar>> GetCalisan(int id)
        {
            return await context.Calisanlar.FindAsync(id);
        }
    }
}