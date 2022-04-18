using AutoMapper;
using ImpulsionaTech.Contas.Application.DTOs.Clientes;
using ImpulsionaTech.Contas.Application.DTOs.Contas;
using ImpulsionaTech.Contas.Application.DTOs.TiposConta;
using ImpulsionaTech.Contas.Application.Interfaces;
using ImpulsionaTech.Contas.Application.Services;
using ImpulsionaTech.Contas.Application.Services.Clientes;
using ImpulsionaTech.Contas.Application.Services.Contas;
using ImpulsionaTech.Contas.Application.Services.TiposConta;
using ImpulsionaTech.Contas.Domain.Interfaces;
using ImpulsionaTech.Contas.Domain.Models.Clientes;
using ImpulsionaTech.Contas.Domain.Models.Contas;
using ImpulsionaTech.Contas.Domain.Models.TiposConta;
using ImpulsionaTech.Contas.Domain.Shared.Enum;
using ImpulsionaTech.Contas.Infrastructure.Data;
using ImpulsionaTech.Contas.Infrastructure.Data.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ImpulsionaTech.Contas.WebApi
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
            var config = new AutoMapper.MapperConfiguration(cfg =>
            {
                cfg.CreateMap<TipoContaRequest, TipoConta>();
                cfg.CreateMap<TipoConta, TipoContaResponse>();

                cfg.CreateMap<ClienteRequest, Cliente>();
                cfg.CreateMap<Cliente, ClienteResponse>();

                cfg.CreateMap<ContaRequest, Conta>();
                cfg.CreateMap<Conta, ContaResponse>();
            });
            IMapper mapper = config.CreateMapper();
            services.AddSingleton(mapper);

            services.AddDbContext<EFContext>(_ => _.UseInMemoryDatabase("TesteDatabase"));
            services.AddTransient(typeof(RepositoryBase<>));
            services.AddTransient<IUnitOfWork<TipoConta>, UnitOfWork<TipoConta>>();
            services.AddTransient<IUnitOfWork<Cliente>, UnitOfWork<Cliente>>();
            services.AddTransient<IUnitOfWork<Conta>, UnitOfWork<Conta>>();
            services.AddTransient<IClienteService, ClienteService>();
            services.AddTransient<ITipoContaService, TipoContaService>();
            services.AddTransient<IContaService, ContaService>();
            services.AddTransient<IServiceBase<ContaRequest, ContaResponse, Conta>, ServiceBase<ContaRequest, ContaResponse, Conta>>();
            services.AddTransient<IServiceBase<TipoContaRequest, TipoContaResponse, TipoConta>, ServiceBase<TipoContaRequest, TipoContaResponse, TipoConta>>();
            services.AddTransient<IServiceBase<ClienteRequest, ClienteResponse, Cliente>, ServiceBase<ClienteRequest, ClienteResponse, Cliente>>();
            services.AddSwaggerGen(swagger =>
            {
                swagger.SwaggerDoc("v1", new OpenApiInfo { Title = "ImpulsionaTech.Contas" });
                swagger.DescribeAllParametersInCamelCase();
            });
            services.AddControllers().AddJsonOptions(
                options =>
                {
                    var enumConverter = new JsonStringEnumConverter();
                    options.JsonSerializerOptions.Converters.Add(enumConverter);
                });
            
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }



            app.UseRouting();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "ImpulsionaTech.Contas");

            });

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });


        }


    }
}