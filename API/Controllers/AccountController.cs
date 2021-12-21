using System.Security.Claims;
using API.DTO;
using API.Services;
using Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [AllowAnonymous]
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly SignInManager<Calisanlar> signInManager;
        private readonly UserManager<Calisanlar> userManager;
        private readonly TokenService tokenService;
        public AccountController(UserManager<Calisanlar> userManager, SignInManager<Calisanlar> signInManager, TokenService tokenService)
        {
            this.tokenService = tokenService;
            this.userManager = userManager;
            this.signInManager = signInManager;
        }


        [HttpPost("login")]
        public async Task<ActionResult<UserDto>> Login(LoginDto loginDto)
        {
            var user = await userManager.FindByEmailAsync(loginDto.Email);

            if (user == null)
            {
                return Unauthorized();
            }
            var result = await signInManager.CheckPasswordSignInAsync(user, loginDto.Password, false);

            if (result.Succeeded)
            {
                return new UserDto
                {
                    DisplayName = user.Adi + " " + user.Soyadi,
                    Image = null,
                    Token = tokenService.CreateToken(user),
                    UserName = user.UserName,
                    Email=user.Email
                };
            }
            return Unauthorized();
        }

        [HttpGet]
        public async Task<ActionResult<UserDto>> GetCurrentUser()
        {
            var user = await userManager.FindByNameAsync(User.FindFirstValue(ClaimTypes.Name));
            return new UserDto
            {
                DisplayName = user.Adi + " " + user.Soyadi,
                    Image = null,
                    Token = tokenService.CreateToken(user),
                    UserName = user.UserName,
                    Email=user.Email
            };
        }
    }
}