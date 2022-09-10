using HR.LeaveManagement.Application;
using HR.LeaveManagement.Persistence;
namespace HR.LeaveManagement.Api
{
    public class Startup
    {
        public IConfiguration configRoot
        {
            get;
        }
        public Startup(IConfiguration configuration)
        {
            configRoot = configuration;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            services.ConfigureApplicationServices();
            //services.ConfigureInfrastructureServices();
            services.ConfigurePersistenceServices(configRoot);
            services.AddCors(o=>
            o.AddPolicy("CorsPolicy", builder=>builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()));
        }
        public void Configure(WebApplication app, IWebHostEnvironment env)
        {
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthorization();
            app.UseCors("CorsPolicy");
            app.MapRazorPages();
            app.Run();
        }
    }
}
