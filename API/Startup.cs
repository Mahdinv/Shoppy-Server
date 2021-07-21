using API.Extensions;
using API.Helpers;
using API.Middleware;
using AutoMapper;
using Infrastructure.Data;
using Infrastructure.Identity;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StackExchange.Redis;

namespace API
{
    public class Startup
    {
        private readonly IConfiguration _config;

        public Startup(IConfiguration config)
        {
            _config = config;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAutoMapper(typeof(MappingProfiles));

            services.AddControllers();

            services.AddDbContext<StoreContext>(x => x.UseSqlServer(_config.GetConnectionString("DefaultConnection")));

            services.AddDbContext<AppIdentityDbContext>(x =>
            {
                x.UseSqlServer(_config.GetConnectionString("IdentityConnection"));
            }); /*tozihat safe 10 mored 1*/

            services.AddSingleton<IConnectionMultiplexer>(c =>
            {
                var configuration = ConfigurationOptions.Parse(_config.GetConnectionString("Redis"), true);
                return ConnectionMultiplexer.Connect(configuration);
            }); /*tozihat safe 7 mored 6*/

            services.AddApplicationServices(); /*faghat bara khalvat kardane inja bood ye meghdarisho bordam to file zekr shode*/

            services.AddIdentityServices(_config); /*baraye Identity va seed data AppUser*/

            services.AddSwaggerDocumentation(); /*inam az SwaggerServiceExtensions miad*/

            services.AddCors(); /*tozihat safe 3 mored 5*/
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseMiddleware<ExceptionMiddleware>(); /*tozihat safe 2 mored 7*/

            /*if (env.IsDevelopment())
            {
                /*app.UseDeveloperExceptionPage();*/ /*khat bala ezafe shod in pak mishe*//*
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "API v1"));
            }*/

            app.UseStatusCodePagesWithReExecute("/errors/{0}"); /*az ErrorController miad. mige age url eshtebahi ya bad vared shod error 404 bede*/

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseStaticFiles();

            app.UseCors(x => x.AllowAnyHeader().AllowAnyMethod().WithOrigins("http://localhost:4200"));

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseSwaggerDocumentation(); /*inam az SwaggerServiceExtensions miad*/

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
