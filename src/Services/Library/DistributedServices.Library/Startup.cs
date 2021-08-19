using Application.Library.Implementation.Authors;
using Application.Library.Implementation.Books;
using Application.Library.Interfaces;
using Application.Library.Interfaces.Authors;
using AutoMapper;
using Infrastructure.Library.Implementation.Context;
using Infrastructure.Library.Implementation.RepositoriesImplementation;
using Infrastructure.Library.Implementation.RepositoriesInterface;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DistributedServices.Library
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
            //var connectionString = Environment.GetEnvironmentVariable("SQL_SERVER_CONNECTION");
            var connectionString = Configuration["ConnectionStrings:DefaultConnection"];
            var migrationsAssembly = "Infrastructure.Library.Implementation";

            services.AddDbContext<ApplicationDbContext>(options =>
               options.UseSqlServer(connectionString,
               sqlServerOptionsAction: sqlOptions =>
               {
                   sqlOptions.MigrationsAssembly(migrationsAssembly);
                   sqlOptions.EnableRetryOnFailure(maxRetryCount: 15, maxRetryDelay: TimeSpan.FromSeconds(30), errorNumbersToAdd: null);
               }),
               ServiceLifetime.Scoped
           );

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IBookService, BookService>();
            services.AddScoped<IAuthorService, AuthorService>();

            MapperConfiguration mappingConfig = new MapperConfiguration(config =>
            {
                config.AddMaps("Domain.Library.Configuration.Dtos");
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ApplicationDbContext db)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }


            UpdateDatabase(app);


            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private static void UpdateDatabase(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices
                .GetRequiredService<IServiceScopeFactory>()
                .CreateScope())
            {
                using (var context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>())
                {
                    context.Database.Migrate();
                }
            }
        }
    }
}
