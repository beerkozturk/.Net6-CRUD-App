using System;
using System.ComponentModel.DataAnnotations;

namespace CRUD_APP.Models
{
	public class EmployeeViewModel
	{
        [Key]
        public Employee viewEmployee { get; set; }
        public int id { get; set; }
        public string? firstName { get; set; }
        public string? lastName { get; set; }
        public string? job { get; set; }
        //DataAnnotations
        public float? salary { get; set; }
        public DateTime? hiredate { get; set; }

        public bool isModelValid { get; set; }
    }
}

