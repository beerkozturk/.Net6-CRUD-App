using System;
using CRUD_APP.Models;

namespace CRUD_APP.Interfaces
{
	public interface IEmployee
	{
        Task<int> CreateEmployee(Employee employee);
        Task<int> UpdateEmployee(Employee employee);
        Task<int> DeleteEmployee(int? id);
        Employee GetEmployeeById(int id);
        Task<IEnumerable<Employee>> GetEmployee();

    }
}

