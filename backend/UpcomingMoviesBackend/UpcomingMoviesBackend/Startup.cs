using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using UpcomingMoviesBackend.Data;
using UpcomingMoviesBackend.Data.Local;
using UpcomingMoviesBackend.Data.Model;

namespace UpcomingMoviesBackend
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        readonly string ApiAllowSpecificOrigins = "_myAllowSpecificOrigins";

        public IConfiguration Configuration { get; }
        public static Api Api { get; private set; }

        public static string ConnectionString { get; private set; }
        

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(
                builder =>
                {
                    builder.WithOrigins("http://localhost:8080")
                                .AllowAnyHeader()
                                .AllowAnyMethod()
                                .AllowCredentials();
                });
            });

            ConnectionString = Configuration["ConnectionString:MoviesDB"];
            services.AddDbContext<MovieDatabaseContext>(opts => opts.UseSqlServer(ConnectionString));

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseCors(ApiAllowSpecificOrigins);
            app.UseHttpsRedirection();
            app.UseMvc();

            Api = new Api()
            {
                Url = Configuration["Api:Url"],
                Key = Configuration["Api:Key"],
                ImageUrl = Configuration["Api:ImageUrl"]
            };

            var sync = new Sync();
            _ = sync.Execute();
        }
    }
}
