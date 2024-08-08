using Final.Models;
using Final.DAL;
using Final.BLL;
using Microsoft.EntityFrameworkCore;

namespace Final {
	public class Program {
		public static void Main(string[] args) {
			var builder = WebApplication.CreateBuilder(args);

			// Register DbContext with the connection string from appsettings.json
			builder.Services.AddDbContext<EventManagementContext>(options =>
				options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

			// Register DAL and BLL services
			builder.Services.AddTransient<EventDAL>();
			builder.Services.AddTransient<AttendeeDAL>();
			builder.Services.AddTransient<RegistrationDAL>();
			builder.Services.AddTransient<EventService>();
			builder.Services.AddTransient<AttendeeService>();
			builder.Services.AddTransient<RegistrationService>();

			// Add services to the container.
			builder.Services.AddControllersWithViews();

			var app = builder.Build();

			// Configure the HTTP request pipeline.
			if (!app.Environment.IsDevelopment()) {
				app.UseExceptionHandler("/Home/Error");
				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
				app.UseHsts();
			}

			app.UseHttpsRedirection();
			app.UseStaticFiles();

			app.UseRouting();

			app.UseAuthorization();

			app.MapControllerRoute(
				name: "default",
				pattern: "{controller=Home}/{action=Index}/{id?}");

			app.Run();
		}
	}
}
