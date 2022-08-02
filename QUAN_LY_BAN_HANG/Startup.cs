using BanHang.Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;

using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;
using BanHang.Domain.Interfaces;
using BanHang.Infrastructure.Repositories;
using BanHang.Appication.Interfaces;
using BanHang.Appication.Services;

namespace QUAN_LY_BAN_HANG
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

            //services.AddHealthChecks()
            //    .AddCheck(Configuration.GetConnectionString("QuanLyBanHangConnection"), "SELECT * From Product")
            //    .AddDbContextCheck<BanHangDbContext>();

            //services.Add(new ServiceDescriptor(typeof(BanHangDbContext), new BanHangDbContext(Configuration.GetConnectionString("ConnectionStrings.Default"))));
            string mySqlConnectionStr = Configuration.GetConnectionString("Default");
            var serverVersion = new MySqlServerVersion(new System.Version(8, 0, 29));
            services.AddCors(options => options.AddPolicy("ApiCorsPolicy", builder =>
            {
                builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
            }));

            //services.AddMvc();
            services.AddDbContext<BanHangDbContext>(options =>
            {
                options.UseMySql(mySqlConnectionStr, serverVersion);
            });
            services.AddControllers();

            // DI for Repositories
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<IUserRepository, UserRepository>();

            // DI for Services
            services.AddTransient<IBanHangServices, BanHangServices>();

        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors("ApiCorsPolicy");

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            //app.UseMvc();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

    }
    
}
