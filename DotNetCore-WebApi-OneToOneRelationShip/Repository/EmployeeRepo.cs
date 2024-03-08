using DotNetCore_WebApi_OneToOneRelationShip.Data;
using DotNetCore_WebApi_OneToOneRelationShip.Models;
using DotNetCore_WebApi_OneToOneRelationShip.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCore_WebApi_OneToOneRelationShip.Repository
{
	public class EmployeeRepo : IEmployeeRepo
	{
		private readonly EmployeeContext _context;
		private readonly ILogger _logger;

		public EmployeeRepo(EmployeeContext context, ILogger<EmployeeRepo> logger)
		{
			_context = context;
			_logger = logger;
		}

		public async Task<IActionResult> AddAsync(Employee employee)
		{
			try
			{
				var resp = await _context.Employees.AddAsync(employee);
				await _context.SaveChangesAsync();
				return new OkObjectResult(resp);
			}
			catch (Exception ex)
			{
				_logger.LogError($"Error occurred while adding employee: {ex.Message}");
				throw new Exception("Error occurred while adding employee", ex);
			}
		}

		public async Task<IEnumerable<GetAllEmployeeDTO>> GetAllAsync()
		{
			try
			{
				var employees =  _context.Employees
					.Include(emp => emp.Passport)
					.ToList();

				IEnumerable<GetAllEmployeeDTO> results = employees.Select(emp => new GetAllEmployeeDTO
				{
					PassportNumber = emp.Passport?.PassportNumber,
					PassportName = emp.Passport?.PassportName,
					ExpiryDate = emp.Passport?.ExpiryDate ?? DateTime.MinValue, // Use null-coalescing operator to handle nullable DateTime
					FirstName = emp.FirstName,
					LastName = emp.LastName,
					EmployeeId = emp.Passport?.EmployeeId ?? 0 // Use null-coalescing operator to handle nullable int
				}).ToList();

				return results;
			}
			catch (Exception ex)
			{
				throw new Exception($"{ex.Message}", ex);
			}
		}

		public async Task<GetAllEmployeeDTO>  GetAsync(int Id)
		{
			var emp = await _context.Employees.FindAsync(Id);
			
			if (emp == null)
			{
				return null;
			}
			else
			{
				var passport = await _context.Passport.FirstOrDefaultAsync(x => x.EmployeeId == Id);
				return new GetAllEmployeeDTO()
				{
					FirstName = emp.FirstName,
					LastName = emp.LastName,
					PassportName = passport.PassportName,
					PassportNumber = passport.PassportNumber,
					EmployeeId = emp.Id
				};
			}
				
			}
		}
			
			
		
	
}
