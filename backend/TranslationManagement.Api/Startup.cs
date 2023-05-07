using External.ThirdParty.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using TranslationManagement.Api.DataAccess.Interfaces;
using TranslationManagement.Api.DataAccess.Repositories;
using TranslationManagement.Api.Services.Interfaces;
using TranslationManagement.Api.Transformers;
using TranslationManagement.Api.Transformers.Interfaces;

namespace TranslationManagement.Api
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
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "TranslationManagement.Api", Version = "v1" });
            });
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder
                        .AllowAnyMethod()
                        .AllowCredentials()
                        .SetIsOriginAllowed((host) => true)
                        .AllowAnyHeader());
            });
            services.AddTransient<ITranslationJobRepository, TranslationJobRepository>();
            services.AddTransient<ITranslationJobService, TranslationJobService>();
            services.AddTransient<INotificationService, UnreliableNotificationService>();
            services.AddTransient<IMyNotificationService, MyNotificationService>();
            services.AddTransient<IFileParserTransformer, FileParserTransformer>();

            services.AddDbContext<AppDbContext>(options => 
                options.UseSqlite("Data Source=TranslationAppDatabase.db"));
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "TranslationManagement.Api v1"));

            app.UseCors("CorsPolicy");

            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
