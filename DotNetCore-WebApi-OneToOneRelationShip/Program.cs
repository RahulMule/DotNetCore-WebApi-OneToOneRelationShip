
using DotNetCore_WebApi_OneToOneRelationShip.Data;
using DotNetCore_WebApi_OneToOneRelationShip.Repository;
using DotNetCore_WebApi_OneToOneRelationShip.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace DotNetCore_WebApi_OneToOneRelationShip
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.

			builder.Services.AddControllers();
			// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
			builder.Services.AddEndpointsApiExplorer();
			builder.Services.AddSwaggerGen();
			builder.Services.AddScoped<IEmployeeRepo,EmployeeRepo>();
			var connstring = builder.Configuration.GetConnectionString("connstring");
			builder.Services.AddDbContext<EmployeeContext>(Options => Options.UseSqlServer(connstring));
			var app = builder.Build();

			// Configure the HTTP request pipeline.
			if (app.Environment.IsDevelopment())
			{
				app.UseSwagger();
				app.UseSwaggerUI();
			}

			app.UseHttpsRedirection();

			app.UseAuthorization();


			app.MapControllers();

			app.Run();
		}
	}
}
