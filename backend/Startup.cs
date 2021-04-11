using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using SCEES.Domain.Repositories;
using SCEES.Domain.Services;
using SCEES.Persistence;
using SCEES.Persistence.Repositories;
using SCEES.Services;

namespace SCEES {
    public class Startup {
        public Startup (IConfiguration configuration) {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices (IServiceCollection services) {
            //database
            string mysqlConnection = Configuration.GetConnectionString ("DefaultConnection");
            services.AddDbContextPool<ContextDbApp> (options =>
                options.UseMySql (mysqlConnection, ServerVersion.AutoDetect (mysqlConnection))
            );

            //services
            services.AddScoped<IUserService, UserServices> ();
            services.AddScoped<ICategoryService, CategoryService> ();
            services.AddScoped<IProductService, ProductService> ();
            services.AddScoped<ISaleService, SaleService> ();
            //repositories
            services.AddScoped<IUserRepository, UserRepository> ();
            services.AddScoped<ICategoryRepository, CategoryRepository> ();
            services.AddScoped<IProductRepository, ProductRepository> ();
            services.AddScoped<ISaleRepository, SaleRepository> ();

            services.AddCors(c => c.AddPolicy("ApiPolicy", builder =>{
                builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
            }));

            services.AddControllers ();
            services.AddSwaggerGen (c => {
                c.SwaggerDoc ("v1", new OpenApiInfo { Title = "SCEES", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure (IApplicationBuilder app, IWebHostEnvironment env) {
            if (env.IsDevelopment ()) {
                app.UseDeveloperExceptionPage ();
                app.UseSwagger ();
                app.UseSwaggerUI (c => c.SwaggerEndpoint ("/swagger/v1/swagger.json", "SCEES v1"));
            }

            app.UseHttpsRedirection ();

            app.UseRouting ();

            // global cors policy
            app.UseCors("ApiPolicy"); // allow credentials

            app.UseEndpoints (endpoints => {
                endpoints.MapControllers ();
            });
        }
    }
}