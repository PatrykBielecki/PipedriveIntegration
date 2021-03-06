using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PipedriveIntegration.Core.Configuration;
using PipedriveIntegration.Mapper;
using PipedriveIntegration.Service;

namespace PipedriveIntegration
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
            var webconMapping = new WebconMapping();
            Configuration.Bind("WebconIds", webconMapping);
            services.AddSingleton(webconMapping);

            services.AddControllersWithViews();
            services.AddControllers();
            services.AddSwaggerGen();
            services.AddTransient<IWebconService, WebconService>();
            services.AddTransient<IPipedriveService, PipedriveService>();
            services.AddTransient<IOrganizationFromWebconMapper, OrganizationFromWebconMapper>();
            services.Configure<WebconConfig>(Configuration.GetSection("WebconConfig"));
            services.AddControllers().AddNewtonsoftJson();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseForwardedHeaders();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseSwagger(c =>
            {
                c.SerializeAsV2 = true;
            });
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                c.RoutePrefix = "swagger";
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
