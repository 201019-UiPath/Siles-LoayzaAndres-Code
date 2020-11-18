using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HerosDB;
using HerosDB.Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace HerosWeb
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

			//add DbContext
			//configure options here (not in HeroContext's OnConfiguring() method)
			services.AddDbContext<HeroContext>(options=>options.UseNpgsql(Configuration.GetConnectionString("HerosDb")));
			//every time you make an HTTP request, the DBRepo is instantiated
			services.AddScoped<ISuperHeroRepo, DBRepo>(); //everytime I need an ISuperHeroRepo, pass in a DBRepo
			services.AddScoped<IMapper, DBMapper>();  //every time I need an IMapper, pass in a DBMapper

			services.AddScoped<IVillainRepo, DBRepo>();
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

			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllerRoute(
					name: "default", //this is the default routing pattern
					pattern: "{controller=SuperHero}/{action=GetAllHeroes}/{id?}"); //by default, home/index
			});
		}
	}
}
