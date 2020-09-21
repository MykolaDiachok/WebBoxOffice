using System;
using System.IO;
using System.Reflection;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using WebBoxOffice.Core.Services;
using WebBoxOffice.Data;
using WebBoxOffice.Identity.Data;
using WebBoxOffice.Identity.Models;

namespace WebBoxOffice
{
    /// <summary>
    /// Main class
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="configuration"></param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// <summary>
        /// 
        /// </summary>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// XmlCommentsFilePath - path to xml file for documentation
        /// </summary>
        public string XmlCommentsFilePath
        {
            get
            {
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                return xmlPath;
            }
        }

        /// <summary>
        /// ConfigureServices - This method gets called by the runtime. Use this method to add services to the container.
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.IncludeXmlComments(XmlCommentsFilePath);
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "WebBoxOffice API", Version = "v1" });
            });
            services.AddDbContext<WebBoxOfficeIdentityDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("IdentityConnection")));

            services.AddDbContext<WebBoxOfficeDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("WebBoxOfficeConnection")));

            services.AddHttpContextAccessor();
            services.AddSingleton<IUriService>(o =>
            {
                var accessor = o.GetRequiredService<IHttpContextAccessor>();
                var request = accessor.HttpContext.Request;
                var uri = string.Concat(request.Scheme, "://", request.Host.ToUriComponent());
                return new UriService(uri);
            });
            services.AddDefaultIdentity<WebBoxOfficeUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddRoles<WebBoxOfficeRole>()
                .AddEntityFrameworkStores<WebBoxOfficeIdentityDbContext>();

            services.AddIdentityServer()
                .AddApiAuthorization<WebBoxOfficeUser, WebBoxOfficeIdentityDbContext>();
                

            services.AddAuthentication()
                .AddIdentityServerJwt();
            services.AddControllersWithViews();
            services.AddRazorPages();
            // In production, the Angular files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist";
            });
        }

        /// <summary>
        /// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        /// <param name="logger"></param>
        /// <param name="identityDbContext"></param>
        /// <param name="boxOfficeDbContext"></param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILogger<Startup> logger,
            WebBoxOfficeIdentityDbContext identityDbContext, WebBoxOfficeDbContext boxOfficeDbContext)
        {
            if (!((RelationalDatabaseCreator) identityDbContext.Database.GetService<IDatabaseCreator>()).Exists())
            {
                logger.LogInformation("Identity Database not found, will create new...");
                identityDbContext.Database.EnsureCreated();
            }

            if (!((RelationalDatabaseCreator) boxOfficeDbContext.Database.GetService<IDatabaseCreator>()).Exists())
            {
                logger.LogInformation("Database not found, will create new...");
                boxOfficeDbContext.Database.EnsureCreated();
                new AddNewDbRecords(boxOfficeDbContext).AddNewRecords();
            }
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebBoxOffice API v1");
            });
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            if (!env.IsDevelopment())
            {
                app.UseSpaStaticFiles();
            }

            app.UseRouting();

            app.UseAuthentication();
            app.UseIdentityServer();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });

            app.UseSpa(spa =>
            {
                // To learn more about options for serving an Angular SPA from ASP.NET Core,
                // see https://go.microsoft.com/fwlink/?linkid=864501

                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseAngularCliServer(npmScript: "start");
                }
            });
        }
    }
}
