using AutoMapper;
using ExerciseTracker.Data;
using ExerciseTracker.DataAccessLayer.UnitOfWork;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using IConfiguration = Microsoft.Extensions.Configuration.IConfiguration;

namespace ExerciseTracker.API
{
    public class Startup
    {
        
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        
        public IConfiguration Configuration { get; }
        
        public void ConfigureServices(IServiceCollection service)
        {
            var dbContextConfiguration = new ExerciseTrackerDbContextConfiguration(Configuration);

            service.AddDbContext<ExerciseTrackerDbContext>(options => options.UseNpgsql(dbContextConfiguration.ConnectionString));
            service.AddScoped<IUnitOfWork, UnitOfWork>();
            service.AddAutoMapper(typeof(Startup));
            
            service.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }
        
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHttpsRedirection();
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            

            //app.UseAuthentication();
            
            app.UseMvc();
        }
    }
}