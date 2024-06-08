using CoreApp.Middlewares;

namespace CoreApp
{
    public class Startup
    {
        IWebHostEnvironment _env;

        //public Startup(IWebHostEnvironment env)
        //{
        //    _env = env;
        //}
        public void ConfigureServices(IServiceCollection services)
        {

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment() || env.IsStaging())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseStaticFiles();

            app.UseMiddleware<LoggingMiddleware>();

            app.UseStatusCodePages();

            Console.WriteLine($"Launching project from: {env.ContentRootPath}");

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context => { await context.Response.WriteAsync($"Hellow world {env.EnvironmentName} {env.ApplicationName}"); });
            });
        }
    }
}