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
        //ConfigureServices : Kullan�lacak servislerin belirtildi�i,eklendi�i dependecy injection i�lemlerinin yap�ld��� metottur.
        {
            //Aspnet Core'un ConnectionString ba�lant�s� yapabilmesi i�in yap�land�rma servislerine
            //dbcontext nesnesini eklmesi gerekir
            services.AddDbContext<MyContext>(options =>
            
            options.UseSqlServer(Configuration.GetConnectionString("SqlConnection")));


            services.AddControllersWithViews();  //Projenin MVC projesi oldu�unu belirtiyoruz.
            services.AddRazorPages(); //razor sayfalar� i�in
            services.AddMvc();  //MVC �zelli�i kullanmak i�in eklendi.
            services.AddSession(options => options.IdleTimeout = TimeSpan.FromSeconds(20));
            //oturum zaman�

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
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, RoleManager<AppRole> roleManager) //servis ayarlar�n�n yap�ld��� yer

        {
            //Configure : HTTP isteklerinin izleyece�i yolunun yap�land�r�ld��� s�n�ft�r.
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();  //wwwroot klas�r�n�n eri�imi i�indir. Javascript, css ve resimler gibi statik dosyalar� kullanmak i�in

            app.UseRouting(); //controller/Action/Id
            app.UseSession(); //Oturum mekanizmas�n�n kullan�lmas� i�in.
            app.UseAuthentication();  // Login Logout i�lemlerinin gerektirdi�i oturum i�leyi�lerini kullanabilmek i�in. 
            app.UseAuthorization();  //[Authorize] attribute i�in

            // app.UseStatusCodePages();
            // bu metot bizim projemiz i�erisinde yer almayan bir view a gidilmek istendi�inde otomatik olarak 404 sayfas�n� kullan�c�ya g�steren metottur.

            //rolleri olu�turacak static metot �a�r�ld�.
            CreateDefaultData.CreateData.Create(roleManager);



            // MVC ile ayn� kod blo�u endpoint'in mekanizmas�n�n nas�l olaca�� belirleniyor.

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
            //yukar�daki 6 sat�r projemiz �al��t�r�ld���nda HomeController da yer alan Index.cshtml sayfas�na y�nlendirme i�lemini ger�ekle�tirir.
        }
    }
}
