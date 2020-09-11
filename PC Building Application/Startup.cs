using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Serialization;
using PC_Building_Application.Data;
using PC_Building_Application.Data.Repositories;
using PC_Building_Application.Data.Repositories.Interfaces;
using PC_Building_Application.Helper;
using Microsoft.OpenApi.Models;
using System.Reflection;
using System.IO;
using PC_Building_Application.Data.Models;

namespace PC_Building_Application
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            services.AddDbContext<DataContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DevConnection")));

            services.AddControllersWithViews()
                .AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            );
            services.AddControllers().AddNewtonsoftJson(s =>
            {
                s.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            });

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddScoped<IUserRepo, UserRepo>();
            services.AddScoped<IPhotoRepo, PhotoRepo>();
            services.AddScoped<IMotherboardRepo, MotherboardRepo>();
            services.AddScoped<ISocketTypeRepo, SocketTypeRepo>();
            services.AddScoped<ICPURepo, CPURepo>();
            services.AddScoped<IRAMRepo, RAMRepo>();
            services.AddScoped<IGPURepo, GPURepo>();
            services.AddScoped<IPowerSupplyRepo, PowerSupplyRepo>();
            services.AddScoped<ICaseRepo, CaseRepo>();
            services.AddScoped<IStorageRepo, StorageRepo>();
            services.AddScoped<ICoolerRepo, CoolerRepo>();
            services.AddScoped<ICoolerSocketTypeRepo, CoolerSocketTypeRepo>();
            services.AddScoped<IManufacturerRepo, ManufacturerRepo>();
            services.AddScoped<IPCRepo, PCRepo>();
            services.AddScoped<IPCRamRepo, PCRamRepo>();
            services.AddScoped<IPCStorageRepo, PCStorageRepo>();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(opt =>
                {
                    opt.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Configuration.GetSection("AppSettings:Token").Value)),
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };
                });

            services.Configure<CloudinarySettings>(Configuration.GetSection("CloudinarySettings"));

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "PC Building Application",
                    Description = "Application that helps you build PCs",
                    TermsOfService = new Uri("https://example.com/terms"),
                    Contact = new OpenApiContact
                    {
                        Name = "Amar Ćatović",
                        Email = "amar_catovic@hotmail.com",
                        Url = new Uri("https://www.facebook.com/amar.catovic.39/"),
                    }
                });
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseSwagger();
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "PC Builder API");
            });

            PopulateDb.Populate(app);
        }
    }
}
