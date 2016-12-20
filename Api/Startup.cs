using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Domain.Entities;

namespace Api
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApiContext>(options => {
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));

                // Register the entity sets needed by OpenIddict.
                // Note: use the generic overload if you need
                // to replace the default OpenIddict entities.
                options.UseOpenIddict();
            });

             services.AddIdentity<User, IdentityRole>()
                .AddEntityFrameworkStores<ApiContext>()
                .AddDefaultTokenProviders();
            // Add framework services.

            services.AddOpenIddict()
            // Register the Entity Framework stores.
            .AddEntityFrameworkCoreStores<ApiContext>()

            // Register the ASP.NET Core MVC binder used by OpenIddict.
            // Note: if you don't call this method, you won't be able to
            // bind OpenIdConnectRequest or OpenIdConnectResponse parameters.
            .AddMvcBinders()

            // Enable the token endpoint (required to use the password flow).
            .EnableTokenEndpoint("/connect/token")

            // Allow client applications to use the grant_type=password flow.
            .AllowPasswordFlow()

            // During development, you can disable the HTTPS requirement.
            .DisableHttpsRequirement()

            // Register a new ephemeral key, that is discarded when the application
            // shuts down. Tokens signed using this key are automatically invalidated.
            // This method should only be used during development.
            .AddEphemeralSigningKey();
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseIdentity();

            app.UseOAuthValidation(); // enabled auth through bearer tokens
            
            app.UseOpenIddict();
            
            app.UseMvc();
        }
    }
}
