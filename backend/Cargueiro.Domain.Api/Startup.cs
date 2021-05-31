using AutoMapper;
using Cargueiro.Domain.Api.Models;
using Cargueiro.Domain.Entidades;
using Cargueiro.Domain.Handlers;
using Cargueiro.Domain.Infra.Contexts;
using Cargueiro.Domain.Infra.Repositorios;
using Cargueiro.Domain.Repositorios;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace Cargueiro.Domain.Api
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

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Cargueiro.Domain.Api", Version = "v1" });
            });

            services.AddDbContext<DataContext>(opt => opt.UseInMemoryDatabase("Database"));
            services.AddScoped<MovimentacaoCargueiroHandler, MovimentacaoCargueiroHandler>();
            services.AddScoped<IFrotaCargueiroRepositorio, FrotaCargueiroRepositorio>();
            services.AddScoped<IMovimentacaoCargueiroRepositorio, MovimentacaoCargueiroRepositorio>();

            var config = new AutoMapper.MapperConfiguration(cfg =>
           {
               cfg.CreateMap<MovimentacaoCargueiroViewModel, MovimentacaoCargueiro>();
           });
            IMapper mapper = config.CreateMapper();
            services.AddSingleton(mapper);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

            }

            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Cargueiro.Domain.Api v1"));

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
