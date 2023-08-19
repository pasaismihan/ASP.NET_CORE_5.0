using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MVCProjectEx_.Models;
using MVCProjectEx_.Models.ViewModels;

namespace MVCProjectEx_.Controllers
{
    public class EmployeeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Index2()
        {
            return View();
        }
        public IActionResult GetEmployeeInfo()
        {
          Products product = new Products()
          {
              Id = 1,
              ProductName= "bilmiyorum",
              TotalProduct = 10
          };
            Employee employee = new Employee()
            {
                EmployeeId = 1,
                EmployeeName = "pasa",
                EmployeePosition = "midior"
            };
            EmployeeProduct employeeProduct = new EmployeeProduct
            {
                Employee = employee,
                Products = product
            };
            return View(employeeProduct);
        }
    }
}

