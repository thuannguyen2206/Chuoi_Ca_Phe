using AutoMapper;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NordaShop.Admin.Mapping;
using NordaShop.IntegrationApi;
using NordaShop.IntegrationApi.Interfaces;
using Service.IServices;
using Service.Services;
using System;

namespace NordaShop.Admin
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
            services.AddHttpClient();
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                {
                    options.LoginPath = "/Account/Login";
                    options.Cookie.HttpOnly = true;
                    options.AccessDeniedPath = "/Account/AccessDenied";
                    options.ExpireTimeSpan = TimeSpan.FromDays(10);
                });


            //add razor runtime
            IMvcBuilder builder = services.AddRazorPages();
            var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
#if DEBUG
            if (environment == Environments.Development)
            {
                builder.AddRazorRuntimeCompilation();
            }
#endif

            // AutoMapping
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });
            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);

            services.AddSession(option =>
            {
                option.IdleTimeout = new TimeSpan(6, 0, 0);
                option.Cookie.Name = "NordaShop.Admin";
            });

            services.Configure<FormOptions>(o => {
                o.ValueLengthLimit = int.MaxValue;
                o.MultipartBodyLengthLimit = int.MaxValue;
                o.MemoryBufferThreshold = int.MaxValue;
            });


            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddScoped<IUserApiClient, UserApiClient>();
            services.AddScoped<IBrandApiClient, BrandApiClient>();
            services.AddScoped<ICartApiClient, CartApiClient>();
            services.AddScoped<ICategoryApiClient, CategoryApiClient>();
            services.AddScoped<IOrderApiClient, OrderApiClient>();
            services.AddScoped<IProductApiClient, ProductApiClient>();
            services.AddScoped<IRoleApiClient, RoleApiClient>();
            services.AddScoped<ISlideApiClient, SlideApiClient>();
            services.AddScoped<IOptionApiClient, OptionApiClient>();
            services.AddScoped<IMenuApiClient, MenuApiClient>();
            services.AddScoped<IPromotionApiClient, PromotionApiClient>();
            services.AddScoped<IContactApiClient, ContactApiClient>();
            services.AddScoped<ITagApiClient, TagApiClient>();
            services.AddScoped<IReportApiClient, ReportApiClient>();
            services.AddScoped<IBlogApiClient, BlogApiClient>();
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
            app.UseAuthentication();
            app.UseRouting();
            app.UseAuthorization();
            app.UseSession();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "Login",
                    pattern: "login",
                    defaults: new { controller = "Account", action = "Login" });

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }

}
