using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using AdminService.Services;
using SharedServices;
using Domain.Data;
using Domain.Models;
using Domain.Models.Interfaces.Adapters;
using Domain.Models.Interfaces.Services;
using AdminService.Adapters;
using SharedServices.ApiMiddleware.Interfaces;
using SharedServices.ApiMiddleware.Services;
using Domain.Models.Entities;

namespace AdminService
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
            services.AddEntityFrameworkNpgsql().AddDbContext<DbContext, AppDbContext>(options => options.UseNpgsql(Configuration.GetConnectionString("localConnection")));
            services.AddCors(options =>
            {
                options.AddPolicy(name: "CorsPolicy", builder =>
                {
                    builder.WithOrigins("http://localhost:4200")
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowCredentials();
                });
            });
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "BlueNoveltyAdminService", Version = "v1" });
            });

            services.Configure<AppSettings>(Configuration.GetSection("ApplicationSettings"));

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey= true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["ApplicationSettings:Secret"])),
                    ValidateIssuer = false,
                    ValidateAudience= false,
                };

            });

            //services
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<ICleaningRequestService, CleaningRequestService>();
            services.AddScoped<IHouseholdDetailService, HouseholdDetailService>();
            services.AddScoped<IServiceProviderService, ServiceProviderService>();
            services.AddScoped<IServiceService, ServiceService>();

            //adapters
            services.AddScoped<ICustomerAdapter, CustomerAdapter>();
            services.AddScoped<ICleaningRequestAdapter, CleaningRequestAdapter>();
            services.AddScoped<IHouseholdDetailAdapter, HouseholdDetailAdapter>();
            services.AddScoped<IServiceProviderAdapter, ServiceProviderAdapter>();
            services.AddScoped<IServiceAdapter, ServiceAdapter>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {


            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "BlueNoveltyAdminService v1"));

            app.UseCors("CorsPolicy");
            // TODO: app.UseHttpsRedirection();

            app.UseRouting();

            //app.UseCors("AllowOrigin");

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }

}
