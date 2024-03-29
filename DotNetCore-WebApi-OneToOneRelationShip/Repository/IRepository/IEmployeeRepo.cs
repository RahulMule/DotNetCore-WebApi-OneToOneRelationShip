﻿using DotNetCore_WebApi_OneToOneRelationShip.Models;
using Microsoft.AspNetCore.Mvc;

namespace DotNetCore_WebApi_OneToOneRelationShip.Repository.IRepository
{
	public interface IEmployeeRepo
	{
		Task<IEnumerable<GetAllEmployeeDTO>> GetAllAsync();
		Task<IActionResult> AddAsync(Employee employee);
		Task<GetAllEmployeeDTO> GetAsync(int Id);
		Task RemoveEmployee(int Id);
		Task UpdateEmployee(Employee employee);
	}
}
