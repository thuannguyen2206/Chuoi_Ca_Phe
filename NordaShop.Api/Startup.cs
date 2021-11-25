using DataAccess.Context;
using DinkToPdf;
using DinkToPdf.Contracts;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Repositories;
using Service.IServices;
using Service.Services;
using System;
using System.IO;
using System.Reflection;
using System.Runtime.Loader;
using System.Text;

namespace NordaShop.Api
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
            services.AddDbContext<NordaShopDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddControllers();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(op =>
            {
                op.RequireHttpsMetadata = false;
                op.SaveToken = true;
                op.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidIssuer = Configuration["Jwt:Issuer"],
                    ValidAudience = Configuration["Jwt:Audience"],
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ClockSkew = TimeSpan.Zero,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]))
                };
            });

            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader());
            });

            services.Configure<FormOptions>(o => {
                o.ValueLengthLimit = int.MaxValue;
                o.MultipartBodyLengthLimit = int.MaxValue;
                o.MemoryBufferThreshold = int.MaxValue;
            });

            var context = new CustomAssemblyLoadContext();
            context.LoadUnmanagedLibrary(Path.Combine(Directory.GetCurrentDirectory(), "ExternalFiles\\libwkhtmltox-64bit\\", "libwkhtmltox.dll"));

            this.ConfigureDependency(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
 
            app.UseHttpsRedirection();

            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(Path.Combine(env.ContentRootPath, "assets")),
                RequestPath = "/assets"
            });

            app.UseAuthentication();

            app.UseRouting();
            app.UseCors("CorsPolicy");

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private void ConfigureDependency(IServiceCollection services)
        {

            // Add Scoped
            services.AddScoped<IUnitOfWork, UnitOfWork<NordaShopDbContext>>();
            services.AddSingleton(typeof(IConverter), new SynchronizedConverter(new PdfTools()));

            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IEmailService, EmailService>();
            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IStorageService, StorageService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ICartService, CartService>();
            services.AddScoped<IBrandService, BrandService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<ISliderService, SliderService>();
            services.AddScoped<IOptionService, OptionService>();
            services.AddScoped<IMenuService, MenuService>();
            services.AddScoped<IUtilityService, UtilityService>();
            services.AddScoped<IContactService, ContactService>();
            services.AddScoped<ITagService, TagService>();
            services.AddScoped<IPromotionService, PromotionService>();
            services.AddScoped<IReportService, ReportService>();
            services.AddScoped<IBlogService, BlogService>();
        }

        internal class CustomAssemblyLoadContext : AssemblyLoadContext
        {
            public IntPtr LoadUnmanagedLibrary(string absolutePath)
            {
                return LoadUnmanagedDll(absolutePath);
            }
            protected override IntPtr LoadUnmanagedDll(string unmanagedDllName)
            {
                return LoadUnmanagedDllFromPath(unmanagedDllName);
            }
            protected override Assembly Load(AssemblyName assemblyName)
            {
                throw new NotImplementedException();
            }
        }

    }
}
