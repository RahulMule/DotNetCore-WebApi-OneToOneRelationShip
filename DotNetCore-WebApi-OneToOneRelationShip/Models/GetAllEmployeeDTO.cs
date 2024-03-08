using System.ComponentModel.DataAnnotations;

namespace DotNetCore_WebApi_OneToOneRelationShip.Models
{
	public class GetAllEmployeeDTO
	{
		public string FirstName { get; set; }
		[Required]
		public string LastName { get; set; }

		[Required]
		public string PassportNumber { get; set; }
		[Required]
		public string PassportName { get; set; }
		[Required]
		public DateTime ExpiryDate { get; set; }
		public int EmployeeId { get; set; }
	}
}
