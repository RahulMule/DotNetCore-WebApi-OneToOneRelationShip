using DotNetCore_WebApi_OneToOneRelationShip.Models;
using Microsoft.AspNetCore.Mvc;

namespace DotNetCore_WebApi_OneToOneRelationShip.Repository.IRepository
{
	public interface IEmployeeRepo
	{
		Task<IEnumerable<GetAllEmployeeDTO>> GetAllAsync();
		Task<IActionResult> AddAsync(Employee employee);
	}
}
