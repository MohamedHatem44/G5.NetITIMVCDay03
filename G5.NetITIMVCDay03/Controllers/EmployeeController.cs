using G5.NetITIMVCDay03.Context;
using G5.NetITIMVCDay03.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace G5.NetITIMVCDay03.Controllers
{
    public class EmployeeController : Controller
    {
        /*---------------------------------------------------------*/
        // Context
        CompanyContext db = new CompanyContext();
        /*---------------------------------------------------------*/
        // Index - List of All Employees
        [HttpGet]
        public IActionResult Index()
        {
            // View Model
            var allEmployees = db.Employees.Include(emp => emp.Department);
            return View(allEmployees);
        }
        /*---------------------------------------------------------*/
        // View Details - View Details of a specific Employee
        [HttpGet]
        public IActionResult ViewDetails(int id)
        {
            var employee = db.Employees.Include(emp => emp.Department).FirstOrDefault(emp => emp.Id == id);
            if(employee == null)
            {
                return RedirectToAction("Index");
            }
            return View(employee);
        }
        /*---------------------------------------------------------*/
        // Create - Get Method to show the form for creating a new Employee
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Departments = new SelectList(db.Departments, "Id", "DeptName");
            return View();
        }
        /*---------------------------------------------------------*/
        // Create - Post Method to save/add a new Employee (Add To Data Base)
        [HttpPost]
        public IActionResult Create(Employee employee)
        {
            db.Employees.Add(employee);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        /*---------------------------------------------------------*/
        // Edit - Get Method to show the form for Editing a Employee
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var oldEmployee = db.Employees.Include(e => e.Department).FirstOrDefault(emp => emp.Id == id);
            if(oldEmployee == null)
            {
                return RedirectToAction("Index");
            }
            ViewBag.Departments = new SelectList(db.Departments, "Id", "DeptName");
            return View(oldEmployee);
        }
        /*---------------------------------------------------------*/
        // Edit - Post Method to save a Employee (Save To Data Base)
        [HttpPost]
        public IActionResult Edit(Employee employee)
        {
            var oldEmployee = db.Employees.FirstOrDefault(emp => emp.Id == employee.Id);
            if (oldEmployee == null)
            {
                return RedirectToAction("Index");
            }
            oldEmployee.Name = employee.Name;
            oldEmployee.Age = employee.Age;
            oldEmployee.Salary = employee.Salary;
            oldEmployee.DepartmentId = employee.DepartmentId;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        /*---------------------------------------------------------*/
        // Delete
        public IActionResult Delete(int id)
        {
            var employeeToDelete = db.Employees.FirstOrDefault(emp => emp.Id == id);
            if (employeeToDelete == null)
            {
                return RedirectToAction("Index");
            }
            db.Employees.Remove(employeeToDelete);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        /*---------------------------------------------------------*/
    }
}
