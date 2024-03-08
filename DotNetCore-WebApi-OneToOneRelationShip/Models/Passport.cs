using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace DotNetCore_WebApi_OneToOneRelationShip.Models
{
	public class Passport
	{
		[Key]
		public int Id { get; set; }
		[Required]
		public string PassportNumber { get; set; }
		[Required]
		public string PassportName { get; set;}
		[Required]
		public DateTime ExpiryDate { get; set;}

		public int EmployeeId {  get; set;}
		
		public Employee? Employee { get; set;}
	}
}
