using fontWebCore.Common.Context;
using fontWebCore.Common.Function;
using fontWebCore.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace fontWebCore
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
            services.AddControllersWithViews();
            services.AddDbContext<ODSContext>(options => options.UseSqlServer("Name=ConnectionStrings:ODSConnect"));
            services.AddTransient<EncryptionProcessor<SHA256Processor>, SHA256Processor>();
            services.AddSession();


            //�Nappsetting���@��settingConfig�]�w��Model��
            settingConifgModel setting = new settingConifgModel();
            Configuration.GetSection("SettingConfig").Bind(setting);
            services.AddSingleton(setting);

            //�q�պAŪ���n�J�O�ɳ]�w
            //double LoginExpireMinute = this.Configuration.GetValue<double>("loginExpireMinute");
            //���U CookieAuthentication�AScheme����
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(option =>
            {
                //�γ\�n�q�պA��Ū���A�ۤv�r�u�M�w
                option.LoginPath = new PathString("/Home/Login");//�n�J��
                option.LogoutPath = new PathString("/Home/Logout");//�n�XAction
                //�Τ᭶�����d�Ӥ[�A�n�J�O���A��Controller��Action�̥Τ�n�J�ɡA�]�i�H�]�w��
                option.ExpireTimeSpan = TimeSpan.FromMinutes(setting.loginExpireMinute);//�S���w�]14��
                //����w��ĳfalse�A�սc�z���n��|�n�Dcookie���ੵ�i�Ĵ��A�o�ɳ]false�ܦ�����O���ɶ�
                //���p�G�A���Ȥ���������@���b�ϥΨt�Ϋo�e���Q�۰ʵn�X���ܡA�A�A�]��true(�M��z��policy�ЫȤᲤ�L�����ˬd) 
                option.SlidingExpiration = false;
            });

            services.AddControllersWithViews(options =>
            {
                //���MCSRF��w�����A�o�̴N�[�J�������ҽd��Filter���ܡA�ݷ|Controller�N�����A�[�W[AutoValidateAntiforgeryToken]�ݩ�
                options.Filters.Add(new AutoValidateAntiforgeryTokenAttribute());
            });

            services.AddMvc(config =>
            {
                // MVC �A�Ȥ����U Filter�A�o�˴N�i�H�M�Ψ�Ҧ��� Request
                config.Filters.Add(new AuthorizeFilter());
            });
            // �ϧ�����
            services.AddMemoryCache()
                .AddSimpleCaptcha(builder =>
                {
                    builder.UseMemoryStore();
                    builder.AddConfiguration(options =>
                    {
                        //�]�w���ҽX����
                        options.CodeLength = 6;
                        //�]�w�Ϥ��j�p
                        //options.ImageWidth = 100;
                        //options.ImageHeight = 36;
                        //�]�w�O�_�Ϥ��j�p�g
                        options.IgnoreCase = false;
                        //���ҽX�w�]�����Ĵ���5����
                        //options.ExpiryTime = TimeSpan.FromMinutes(5);
                        options.CodeGenerator = new MyCaptchaCodeGenerator();
                    });
                });
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
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }
        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        // �d�N�gCode���ǡA����������...
        app.UseAuthentication();
        //Controller�BAction�~��[�W [Authorize] �ݩ�
        app.UseAuthorization();


        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
        });
    }
}
}
