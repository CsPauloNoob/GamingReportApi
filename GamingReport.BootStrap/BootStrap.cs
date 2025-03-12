using GamingReport.Core._Game.Interfaces;
using GamingReport.Core._Game.Services;
using GamingReport.Core._Developer.Interfaces;
using GamingReport.Core._Developer.Services;
using Microsoft.Extensions.DependencyInjection;
using GamingReport.Infra;
using GamingReport.Core.Reviews.Interfaces;
using GamingReport.Core.Reviews.Services;
using GamingReport.Core.Interfaces;
using GamingReport.Core.Reviews;
using GamingReport.Infra.Repositories;
using Microsoft.EntityFrameworkCore;
using GamingReport.Core._Game;

namespace GamingReport.DI
{
    public static class BootStrap
    {
        public static void RegisterServices(IServiceCollection services)
        {


            services.AddDbContext<Context>(opt => 
            opt.UseSqlite("Data Source=app.db;"));

            services.AddScoped<IGameService, GameServices>();
            services.AddScoped<IDeveloperServices, DeveloperService>();
            services.AddTransient<IReviewService, ReviewServices>();

            services.AddScoped<IRepository<Review>, Repository<Review>>();
            services.AddScoped<IRepository<Game>, Repository<Game>>();
            //services.AddScoped(typeof(IRepository<Review>), typeof(Repository<Review>));


            //services.AddScoped<Infra.Context>();
        }
    }
}
