using System;
using Microsoft.AspNetCore.Mvc;
using CRUD_APP.Models;
using CRUD_APP.Interfaces;
using System.Text.Json;
using CRUD_APP.ViewModel;
using System.Linq;

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
                EmployeeIndexViewModel model = new EmployeeIndexViewModel();
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

        public IActionResult Delete(int? id)
        {
            if (id != null)
            {
                var result = employee.DeleteEmployee(id);
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(EmployeeViewModel viewmodel)
        {
            TempData["Message"] = "Employee deleted successfully.";
            return RedirectToAction("Index");
        }

        public IActionResult Salary()
        {
            var model = new EmployeeIndexViewModel();
            model.salaries = employee.GetEmployee().Result.OrderByDescending(x => x.salary).ToList();
            return View(model);
        }



        //todo : Stats isminde bir metod oluştur ve içerisinde StatsViewModel ı new ile oluştur ve içerisine database sorgusu ile
        //en yüksek maaş, ortalama maaş, en düşük maaş, toplam çalışan sayısını yazdır.
        //employee.GetEmployee().Result.Count() -> Toplam çalışan sayısını verir.

        public async Task<IActionResult> StatsAsync()
        {
            var empList = (await employee.GetEmployee());
            var model = new StatsViewModel();
            model.maxSalary = empList.Max(x => x.salary).GetValueOrDefault();
            model.avgSalary = empList.Average(x => x.salary).GetValueOrDefault();
            model.minSalary = empList.Min(x => x.salary).GetValueOrDefault();
            model.maxWorker = empList.Count();
            return View(model);
        }
    }
}
