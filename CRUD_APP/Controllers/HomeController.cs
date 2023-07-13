using System;
using Microsoft.AspNetCore.Mvc;
using CRUD_APP.Models;
using CRUD_APP.Interfaces;
using System.Text.Json;

namespace CRUD_APP.Controllers
{
    public class HomeController : Controller
    {
        private readonly IEmployee employee;

        public HomeController(IEmployee employee)
        {
            this.employee = employee;
        }

        public IActionResult Index()
        {
            try
            {
                var Getempresult = employee.GetEmployee().Result;
                //todo 
                EmployeeIndexModel model = new EmployeeIndexModel();
                model.employees = employee.GetEmployee().Result.ToList();
                return View(model);
            }
            catch (Exception ex)
            {
                // Hata durumunda uygun bir işlem yapabilirsiniz, örneğin loglama
                ViewBag.ErrorMessage = "An error occurred while retrieving employee data: " + ex.Message;
                return View();
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateEmployee(Employee empmodel)
        {
            if (ModelState.IsValid)
            {
                employee.CreateEmployee(empmodel);
            }
            else
            {
                EmployeeViewModel model = new EmployeeViewModel();
                model.isModelValid = false;
                TempData["EmployeeViewModel"] = JsonSerializer.Serialize(model);
                return RedirectToAction("Create");
            }

            TempData["Message"] = "Data Saved Successfully..";
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            EmployeeViewModel empview = new EmployeeViewModel()
            {
                viewEmployee = employee.GetEmployeeById(id)
            };
            return View(empview);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(EmployeeViewModel viewEmployee)
        {
                Employee empmodel = new Employee()
                {
                    id = viewEmployee.id,
                    firstName = viewEmployee.firstName,
                    lastName = viewEmployee.lastName,
                    job = viewEmployee.job,
                    salary = viewEmployee.salary,
                    hiredate = viewEmployee.hiredate
                };
                var result = employee.UpdateEmployee(empmodel);
                TempData["Message"] = "Employee updated successfully.";
                return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            EmployeeViewModel empview = new EmployeeViewModel()
            {
                viewEmployee = employee.GetEmployeeById(id)
            };
            return View(empview);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(EmployeeViewModel viewmodel)
        {
            var result = employee.DeleteEmployee(viewmodel.id);
            TempData["Message"] = "Employee deleted successfully.";
            return RedirectToAction("Index");
        }
    }
}
