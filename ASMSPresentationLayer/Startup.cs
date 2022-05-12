using ASMSDataAccessLayer;
using ASMSEntityLayer.IdentityModels;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ASMSEntityLayer.Mappings;
using ASMSBusinessLayer.EmailService;
using ASMSBusinessLayer.ContractsBLL;
using ASMSBusinessLayer.ImplementationsBLL;

namespace ASMSPresentationLayer
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
        //ConfigureServices : Kullanýlacak servislerin belirtildiði,eklendiði dependecy injection iþlemlerinin yapýldýðý metottur.
        {
            //Aspnet Core'un ConnectionString baðlantýsý yapabilmesi için yapýlandýrma servislerine
            //dbcontext nesnesini eklmesi gerekir
            services.AddDbContext<MyContext>(options =>
            
            options.UseSqlServer(Configuration.GetConnectionString("SqlConnection")));


            services.AddControllersWithViews();  //Projenin MVC projesi olduðunu belirtiyoruz.
            services.AddRazorPages(); //razor sayfalarý için
            services.AddMvc();  //MVC özelliði kullanmak için eklendi.
            services.AddSession(options => options.IdleTimeout = TimeSpan.FromSeconds(20));
            //oturum zamaný

            //*********************************************************//
            services.AddIdentity<AppUser, AppRole>(options =>

                {
                    options.User.RequireUniqueEmail = true;
                    options.Password.RequiredLength = 6;
                    options.Password.RequireLowercase = false;
                    options.Password.RequireUppercase = false;
                    options.Password.RequireNonAlphanumeric = false;
                    options.Password.RequireDigit = false;
                    options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-_@.";

                }).AddDefaultTokenProviders().AddEntityFrameworkStores<MyContext>();

            //Mapleme eklendi.
            services.AddAutoMapper(typeof(Maps));

            services.AddSingleton<IEmailSender, EmailSender>();

            services.AddScoped<IStudentBusinessEngine, StudentBusinessEngine>();

            services.AddScoped<IUserAddressBusinessEngine, UserAddressBusinessEngine>();

            services.AddScoped<ASMSDataAccessLayer.ContractsDAL.IUnitOfWork, ASMSDataAccessLayer.ImplementationsDAL.UnitOfWork>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, RoleManager<AppRole> roleManager) //servis ayarlarýnýn yapýldýðý yer

        {
            //Configure : HTTP isteklerinin izleyeceði yolunun yapýlandýrýldýðý sýnýftýr.
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();  //wwwroot klasörünün eriþimi içindir. Javascript, css ve resimler gibi statik dosyalarý kullanmak için

            app.UseRouting(); //controller/Action/Id
            app.UseSession(); //Oturum mekanizmasýnýn kullanýlmasý için.
            app.UseAuthentication();  // Login Logout iþlemlerinin gerektirdiði oturum iþleyiþlerini kullanabilmek için. 
            app.UseAuthorization();  //[Authorize] attribute için

            // app.UseStatusCodePages();
            // bu metot bizim projemiz içerisinde yer almayan bir view a gidilmek istendiðinde otomatik olarak 404 sayfasýný kullanýcýya gösteren metottur.

            //rolleri oluþturacak static metot çaðrýldý.
            CreateDefaultData.CreateData.Create(roleManager);



            // MVC ile ayný kod bloðu endpoint'in mekanizmasýnýn nasýl olacaðý belirleniyor.

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
            //yukarýdaki 6 satýr projemiz çalýþtýrýldýðýnda HomeController da yer alan Index.cshtml sayfasýna yönlendirme iþlemini gerçekleþtirir.
        }
    }
}
