using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using VenturaHR.Application.Helpers;
using VenturaHR.Application.Services;
using VenturaHR.Domain.Repositories;
using VenturaHR.Domain.Services;
using VenturaHR.Infrastructure.Data;
using VenturaHR.Infrastructure.Data.Repositories;
using WebApi.Authorization;
using WebApi.Helpers;

namespace VenturaHR.Api
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
            services.AddCors();
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "VenturaHR.Api", Version = "v1" });
            });

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme);
            services.AddDbContext<DbContext, VenturaDbContext>();

            // configure automapper with all automapper profiles from this assembly
            services.AddAutoMapper(typeof(AutoMapperProfile));

            // configure strongly typed settings object
            services.Configure<AppSettings>(Configuration.GetSection("AppSettings"));

            // configure DI for application services
            services.AddScoped<IJwtUtils, JwtUtils>();

            services.AddScoped<IUsuarioService, UsuarioService>();
            services.AddTransient<IRespostaService, RespostaService>();
            services.AddTransient<IVagaService, VagaService>();

            services.AddTransient<IUsuarioRepository, UsuarioRepository>();
            services.AddTransient<IRespostaRepository, RespostaRepository>();
            services.AddTransient<IVagaRepository, VagaRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "VenturaHR.Api v1"));
            }

            app.UseCors(x => x
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());

            app.UseRouting();

            app.UseAuthorization();

            // global error handler
            app.UseMiddleware<ErrorHandlerMiddleware>();

            // custom jwt auth middleware
            app.UseMiddleware<JwtMiddleware>();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
