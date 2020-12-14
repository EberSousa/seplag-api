using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using api.Dal;
using api.Dal.Default;
using api.Context;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text.Json;
using System.IO;
using System;

namespace api
{
    public class Startup
    {
        private static readonly string MyJwkLocation = Path.Combine(Environment.CurrentDirectory, "mysupersecretkey.json");
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton(Configuration);
            services.AddControllers();
            services.AddTransient<IBeneficiosDal, BeneficiosDal>();
            services.AddTransient<ICategoriasDocumentosDal, CategoriasDocumentosDal>();
            services.AddTransient<ILocaisTramitacaoDal, LocaisTramitacaoDal>();
            services.AddTransient<IServidoresDal, ServidoresDal>();
            services.AddTransient<ITramitacaoDal, TramitacaoDal>();
            services.AddTransient<IUsuariosDal, UsuariosDal>();

            services.AddDbContext<ApiDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("seplagDbConnection"));
            });

            var key = JsonSerializer.Deserialize<JsonWebKey>(File.ReadAllText(MyJwkLocation));
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = key,
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });
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

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
