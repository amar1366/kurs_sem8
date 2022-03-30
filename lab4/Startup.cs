using lab4.Manager.Departments;
using lab4.Manager.Professors;
using lab4.Manager.Universities;
using lab4.Services;
using lab4.Storage.Migrations;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace lab4
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        private IConfigurationRoot _configurationRoot;
        public Startup(IWebHostEnvironment hostEnvironment)
        {
            _configurationRoot = new ConfigurationBuilder().SetBasePath(hostEnvironment.ContentRootPath).AddJsonFile("UniversityDbSetting.json").Build();
        }
        
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<CenterDataContext>(option => option.UseSqlServer(_configurationRoot.GetConnectionString("UniversityDb")));
            services.AddMvc(option => option.EnableEndpointRouting = false);
            services.AddTransient<InterfaceDManager, DManager>();
            services.AddTransient<InterfacePManager, PManager>();
            services.AddTransient<InterfaceUManager, UManager>();
            services.AddTransient<IConvertToExcel, ConvertToExcel>();
            services.AddTransient<ICryptographyService, CryptographyService>();
            services.AddTransient<IDataEncryptionService, DataEncryptionService>();
            services.AddTransient<ISettingEDSFileService, SettingEDSFileService>();
            services.AddTransient<IPortInfoService, PortInfoService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseDeveloperExceptionPage();
            app.UseStatusCodePages();
            app.UseRequestLocalization();
            app.UseStaticFiles();
            app.UseMvcWithDefaultRoute();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                name: "default",
                template: "{controller=Department}/{action=Index}/{id?}/{DepartmentId?}/{ProfessorId?}/{UniversityId?}");
            });
        }
    }
}
