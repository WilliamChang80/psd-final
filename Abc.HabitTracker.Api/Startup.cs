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
using Microsoft.EntityFrameworkCore;
using Npgsql.EntityFrameworkCore.PostgreSQL;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Abc.HabitTracker.Api.Entity;
using Microsoft.EntityFrameworkCore.Design;
using Abc.HabitTracker.Api.Repository;
using Abc.HabitTracker.Api.Repository.Impl;
using Abc.HabitTracker.Api.Service;
using Abc.HabitTracker.Api.Service.Impl;

namespace Abc.HabitTracker.Api
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
            services.AddDbContext<ApplicationDbContext>(options =>
            options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<IBadgeRepository, BadgeRepositoryPostgre>();
            services.AddScoped<IBadgeService, BadgeService>();

            services.AddScoped<IHabitRepository, HabitRepositoryPostgre>();
            services.AddScoped<IHabitService, HabitService>();

            services.AddScoped<ILogsRepository, LogsRepositoryPostgre>();
            services.AddScoped<ILogsService, LogsService>();

            services.AddScoped<IUserRepository, UserRepositoryPostgre>();
            services.AddScoped<IUserService, UserService>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

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
