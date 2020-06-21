using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TodoApplication.Data;
using TodoApplication.Services;
using TodoApplication.Utilities.Loggers;

namespace TodoApplication
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
            services.AddIdentityCore<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<TodoDbContext>();

            services.AddDbContext<TodoDbContext>(options =>
                options.UseSqlite(Configuration.GetConnectionString("DefaultConnection")));

            services.AddControllersWithViews();
            //TODO : services.AddMvcCore(); //.AddDataAnnotations();

            //Dependencies
            services.AddScoped<ITodoItemService,RealTodoItemService>();
            services.AddSingleton<IKodluyoruzLogger, KodluyoruzLogger>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Todo}/{action=Index}/{id?}");
            });
        }
    }
}
