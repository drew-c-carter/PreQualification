using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Andrew.Web.PreQualification.Data;
using Andrew.Web.PreQualification.Models;
using Andrew.Web.PreQualification.Services;
using Andrew.Web.PreQualification.Data.Interfaces.CcInterfaces;
using Andrew.Web.PreQualification.Data.Repositories;
using Andrew.Web.PreQualification.Models.Interfaces;
using Andrew.Web.PreQualification.Models.Services;
using Andrew.Web.PreQualification.Models.PreQualModels.CcModels;
using Andrew.Web.PreQualification.Models.Services.Interfaces;

namespace Andrew.Web.PreQualification
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
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            // Add application services.
            services.AddTransient<IEmailSender, EmailSender>();

            services.AddMvc();

            services.AddDbContext<PreQualificationContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("PreQualificationContext")));

			services.AddScoped<ICardApplicationRepository, CardApplicationRepository>();
			services.AddScoped<ICardApplicationResultRepository, CardApplicationResultRepository>();

			services.AddScoped<ICreditApplication, CardApplication>();
			services.AddScoped<IAgeMonthsCalculator, AgeProcessingService>();

			services.AddScoped<IApplicationProcessingService, ApplicationProcessingService>();

			services.AddScoped<ICardRepository, CardRepository>();

			services.AddScoped<IApplicationRetrievalService, ApplicationRetrievalService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=CardApplications}/{action=Create}/");
            });
        }
    }
}
