using Amara.Solutions.Models;
using Amara.UserManagement.Services;
using Amara.UserManagement.Services.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using UserManagement.Models;
using UserManagement.Repository.EF;
using UserManagement.Repository.EF.Data;
using UserManagement.Repository.EF.Interface;
using UserRepositoryDapper = UserManagement.Repository.Dapper.UserRepository;
using UserRepositoryEF = UserManagement.Repository.EF.UserRepository;

namespace Amara.UserManagement
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            this.Configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();//.SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddDbContext<UserContext>(
                opt => opt.UseSqlServer(
                    Configuration["ConnectionStrings:MyConnectionString"]));

            services
                .AddTransient<IUserService, UserService>()
                .AddTransient<IUnitOfWork, UnitOfWork>()
                .AddTransient<IUserRepository, UserRepositoryEF>()
                .AddTransient<IReadOnlyRepository<User>,  UserRepositoryDapper>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();
            app.UseDefaultFiles();
            app.UseMvcWithDefaultRoute();
        }
    }
}
