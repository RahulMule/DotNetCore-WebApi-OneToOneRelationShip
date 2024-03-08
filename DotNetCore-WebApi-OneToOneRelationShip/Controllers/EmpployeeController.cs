using DotNetCore_WebApi_OneToOneRelationShip.Models;
using DotNetCore_WebApi_OneToOneRelationShip.Repository.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DotNetCore_WebApi_OneToOneRelationShip.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class EmpployeeController : ControllerBase
	{
		private readonly IEmployeeRepo _repo;
		public EmpployeeController(IEmployeeRepo repo)
		{
			_repo = repo;
		}

		[HttpPost]
		public async Task<ActionResult<IEnumerable<Employee>>> AddEmployee(AddEmployeeDTO employee)
		{
			if (ModelState.IsValid)
			{
				Passport passport = new Passport()
				{
					PassportName = employee.PassportName,
					PassportNumber = employee.PassportNumber,
					ExpiryDate = employee.ExpiryDate
				};
				Employee newemployee = new Employee()
				{
					FirstName = employee.FirstName,
					LastName = employee.LastName,
					Passport = passport
				};
				passport.Employee = newemployee;
				try
				{
					dynamic resp = await _repo.AddAsync(newemployee);
					
					if (resp != null)
					{
						return Ok();
					}
					return BadRequest();
				}
				catch (Exception ex)
				{
					return StatusCode(500, ex.Message);
				}
			}
			else
			{
				return BadRequest(ModelState);
			}
		}

		[HttpGet]
		public async Task<ActionResult<IEnumerable<GetAllEmployeeDTO>>> GetAllAsync()
		{
			try
			{
				var employees = await _repo.GetAllAsync();
				return Ok(employees);
			}
			catch (Exception ex)
			{
				return BadRequest();

			}

		}
	}
}
