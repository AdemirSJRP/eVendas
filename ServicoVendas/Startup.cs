using AutoMapper;
using Domain.Services;
using eVendas.Consumer;
using eVendas.Domain.Core.Entities;
using eVendas.Domain.Core.Interfaces.Repositories;
using eVendas.Infra.Repository;
using eVendas.Publisher;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServicoVendas
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            #region Swagger
            services.AddSwaggerGen(o => o.SwaggerDoc("v1", new OpenApiInfo { Title = "eVendas - Vendas", Version = "v1" }));
            #endregion

            #region DbContext
            services.AddDbContext<RepositoryContext>(o => o.UseInMemoryDatabase(databaseName: "TempDB"));
            #endregion

            #region Dependency Injection
            services.AddTransient(typeof(IServiceBase<,>), typeof(ServiceBaseCrud<,>));
            services.AddTransient<IServiceBase<Guid, Produto>, ProdutoService>();
            services.AddTransient(typeof(IBaseRepository<,>), typeof(BaseRepository<,>));
            services.AddTransient<IPublisher, PublisherProduto>();
            services.AddTransient<IConsumer, ConsumerProduto>();
            #endregion

            #region AutoMapper
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            #endregion

            services.AddControllers()
                .AddNewtonsoftJson(o => o.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore)
                .AddFluentValidation(f => f.RegisterValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies()));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            #region Swagger
            app.UseSwagger();
            app.UseSwaggerUI(o => o.SwaggerEndpoint("/swagger/v1/swagger.json", "API"));
            #endregion

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => {
                endpoints.MapControllers();
            });
        }
    }
}
