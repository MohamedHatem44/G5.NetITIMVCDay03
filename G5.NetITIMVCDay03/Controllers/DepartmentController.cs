using G5.NetITIMVCDay03.Context;
using Microsoft.AspNetCore.Mvc;

namespace G5.NetITIMVCDay03.Controllers
{
    public class DepartmentController : Controller
    {
        /*---------------------------------------------------------*/
        // Context
        CompanyContext db = new CompanyContext();
        /*---------------------------------------------------------*/
        // Index - List of All Departments
        [HttpGet]
        public IActionResult Index()
        {
            var _Departments = db.Departments;
            return View(_Departments);
        }
        /*---------------------------------------------------------*/
        // View Details - View Details of a specific Department
        [HttpGet]
        public IActionResult ViewDetails(int id)
        {
            var _Departmnet = db.Departments.Find(id);
            if(_Departmnet == null)
            {
                return RedirectToAction("Index");
            }
            return View(_Departmnet);
        }
        /*---------------------------------------------------------*/
    }
}
