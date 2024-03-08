using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace DotNetCore_WebApi_OneToOneRelationShip.Models
{
	public class Employee
	{
		[Key]
		public int Id { get; set; }
		[Required]
		public string FirstName { get; set; }
		[Required]
		public string LastName { get; set; }

		[JsonIgnore]
		public Passport? Passport { get; set; }
	}
}
