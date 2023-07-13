using System;
using System.ComponentModel.DataAnnotations;

namespace CRUD_APP.Models
{
	public class Employee
	{
        [Key]
        public int id { get; set; }
        public string? firstName { get; set; }
        public string? lastName { get; set; }
        public string? job { get; set; }
        public float? salary { get; set; }
        public DateTime? hiredate { get; set; }

        public Employee()
		{
		}

	}
}

