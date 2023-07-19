using System;
using System.ComponentModel.DataAnnotations;

namespace CRUD_APP.Models
{
	public class EmployeeIndexViewModel
	{
        public List<Employee> employees { get; set; }

        public List<Employee> salaries { get; set; }
    }
}

