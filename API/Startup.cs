using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Persistence;
using Microsoft.EntityFrameworkCore;
using MediatR;
using Application.Calisans;
using Application.Core;
using FluentValidation.AspNetCore;
using API.Middleware;
using Domain;
using Microsoft.AspNetCore.Identity;
using API.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Application.Interfaces;
using Infrastructure.Security;

namespace API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers(opt=>{
                var policy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
                opt.Filters.Add(new AuthorizeFilter(policy));
            })
            .AddFluentValidation(config=>{
                config.RegisterValidatorsFromAssemblyContaining<Create>();
            });
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "WebAPIv5", Version = "v1" });
            });

            services.AddDbContext<DataContext>(opt =>{
                opt.UseSqlServer(Configuration.GetConnectionString("HRDatabase"));
            });

            services.AddCors(opt=>{
                opt.AddDefaultPolicy(policy=>{
                    policy.AllowAnyMethod().AllowAnyHeader().WithOrigins("http://localhost:3000");
                });
            });
            services.AddMvc().AddJsonOptions(opt=>{
                opt.JsonSerializerOptions.PropertyNamingPolicy = null;
                opt.JsonSerializerOptions.ReferenceHandler=System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
            });


            services.AddMediatR(typeof(List.Handler).Assembly);

            services.AddAutoMapper(typeof(MappingProfiles).Assembly);

            services.AddScoped<IUserAccessor,UserAccessor>();


            services.AddIdentityCore<Calisanlar>(opt=>{
                opt.Password.RequireNonAlphanumeric=false;
            }).AddEntityFrameworkStores<DataContext>().AddSignInManager<SignInManager<Calisanlar>>();

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["TokenKey"]));
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer( opt=>{
                opt.TokenValidationParameters=new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey=key,
                    ValidateIssuer=false,
                    ValidateAudience=false
                };
            });

            services.AddScoped<TokenService>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseMiddleware<ExceptionMiddleware>();
            if (env.IsDevelopment())
            {
                
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebAPIv5 v1"));
            }

           // app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
