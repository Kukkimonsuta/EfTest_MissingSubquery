using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
using Microsoft.AspNet.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Data.Entity;

namespace EfTest
{
	public class Startup
	{
		// This method gets called by the runtime. Use this method to add services to the container.
		// For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
		public void ConfigureServices(IServiceCollection services)
		{
			services
				.AddEntityFramework()
				.AddSqlServer()
				.AddDbContext<EfTestContext>(o =>
				{
					o.UseSqlServer("Server=.;Database=ef-test.local;Trusted_Connection=True;");
				});
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, ILoggerFactory loggerFactory)
		{
			loggerFactory.AddConsole((s, l) => true, true);

			app.UseIISPlatformHandler();

			app.Run(async (context) =>
			{
				var dbContext = context.ApplicationServices.GetService<EfTestContext>();

				var users = dbContext.Users.Select(u => new
				{
					Id = u.Id,
					HasImages = u.Images.Any(),
					HasDocuments = u.Documents.Any()
				}).ToArray();

				await context.Response.WriteAsync("Hello World!");
			});
		}

		// Entry point for the application.
		public static void Main(string[] args) => WebApplication.Run<Startup>(args);
	}
}
