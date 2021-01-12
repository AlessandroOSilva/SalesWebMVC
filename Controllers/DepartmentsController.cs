using Microsoft.AspNetCore.Mvc;
using SaleWebMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SaleWebMVC.Controllers
{
    public class DepartmentsController : Controller
    {
        public IActionResult Index()
        {
            List<Department> list = new List<Department>();

            list.Add(new Department { Id = 1, Name = "Comercial" });
            list.Add(new Department { Id = 2, Name = "Managment" });
            return View(list);
        }
    }
}
