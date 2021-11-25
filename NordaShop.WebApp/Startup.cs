using AspNetCoreHero.ToastNotification;
using AspNetCoreHero.ToastNotification.Extensions;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NordaShop.IntegrationApi;
using NordaShop.IntegrationApi.Interfaces;
using NordaShop.WebApp.Filters;
using NordaShop.WebApp.Mappings;
using System;

namespace NordaShop.WebApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Configuration = configuration;
            Env = env;
        }

        public IConfiguration Configuration { get; }

        public IWebHostEnvironment Env { get; }


        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews().AddNewtonsoftJson(options =>
                        options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
            services.AddHttpClient();

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(op =>
                {
                    op.LoginPath = "/Account/SignIn";
                    op.Cookie.HttpOnly = true;
                    op.AccessDeniedPath = "/Account/AccessDenied";
                    op.ExpireTimeSpan = TimeSpan.FromDays(10);
                })
                .AddFacebook(facebook =>
                {
                    facebook.AppId = Configuration["Facebook:AppId"];
                    facebook.AppSecret = Configuration["Facebook:AppSecret"];
                    facebook.AccessDeniedPath = "/Account/AccessDenied";
                    facebook.CallbackPath = "/facebook-signin";
                })
                .AddGoogle(google =>
                {
                    google.CallbackPath = "/google-signin";
                    google.ClientId = Configuration["Google:ClientId"];
                    google.ClientSecret = Configuration["Google:ClientSecret"];
                    google.AccessDeniedPath = "/Account/AccessDenied";
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

            services.AddSession(op =>
            {
                op.Cookie.Name = "NordaShop.Site";
                op.IdleTimeout = new TimeSpan(6, 0, 0);
            });


            // Add Dependency injection
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
            services.AddScoped<IContactApiClient, ContactApiClient>();
            services.AddScoped<ITagApiClient, TagApiClient>();
            services.AddScoped<IPromotionApiClient, PromotionApiClient>();
            services.AddScoped<IDeliveryApiClient, DeliveryApiClient>();
            services.AddScoped<IBlogApiClient, BlogApiClient>();
            services.AddScoped<IPaymentApiClient, PaymentApiClient>();
            services.AddScoped<AuthorizationFilter>();
           
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            // Toast notify
            services.AddNotyf(config => { config.DurationInSeconds = 5; config.IsDismissable = true; config.Position = NotyfPosition.BottomRight; });
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
            app.UseNotyf();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "PostDetail",
                    pattern: "blogs/{id}/{seoalias?}",
                    defaults: new { controller = "Blog", action = "Detail" });

                endpoints.MapControllerRoute(
                    name: "ProductDetail",
                    pattern: "products/{id}/{seoalias?}",
                    defaults: new { controller = "Product", action = "Detail" });

                endpoints.MapControllerRoute(
                    name: "OrderResult",
                    pattern: "order-result/orderid={orderid}&success={success}",
                    defaults: new { controller = "Order", action = "OrderResult" });

                endpoints.MapControllerRoute(
                    name: "OrderTracking",
                    pattern: "order-tracking",
                    defaults: new { controller = "Order", action = "OrderTracking" });

                endpoints.MapControllerRoute(
                    name: "Shop",
                    pattern: "shop",
                    defaults: new { controller = "Product", action = "Index" });

                endpoints.MapControllerRoute(
                    name: "Blog",
                    pattern: "blog",
                    defaults: new { controller = "Blog", action = "Index" });

                endpoints.MapControllerRoute(
                    name: "Contact",
                    pattern: "contact",
                    defaults: new { controller = "Contact", action = "Index" });

                endpoints.MapControllerRoute(
                    name: "About",
                    pattern: "about",
                    defaults: new { controller = "Contact", action = "About" });

                endpoints.MapControllerRoute(
                    name: "SignIn",
                    pattern: "signin",
                    defaults: new { controller = "Account", action = "SignIn" });

                endpoints.MapControllerRoute(
                    name: "SignUp",
                    pattern: "signup",
                    defaults: new { controller = "Account", action = "SignUp" });

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }


    }
}
