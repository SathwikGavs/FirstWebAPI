/*
using FirstWebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FirstWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase

        static View<Employee> employeeList = new View<Employee>();
    [HttpGet]


    {
        //private RepositoryEmployee _repositoryEmployee;
        public EmployeeController(RepositoryEmployee repository)
        {
            _repositoryEmployee = repository;
        }
        // GET: EmployeeController
        public ActionResult Index()
        {
            List<Employee> employees = _repositoryEmployee.AllEmployees();
            return employeeList;
        }



        // GET: EmployeeController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }



        // GET: EmployeeController/Create
        public ActionResult Create()
        {
            return View();
        }



        // POST: EmployeeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }



        // GET: EmployeeController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }



        // POST: EmployeeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }



        // GET: EmployeeController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }



        // POST: EmployeeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }



    }
}

*/



using FirstWebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FirstWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private RepositoryEmployee _repositoryEmployee;
        public EmployeeController(RepositoryEmployee repository)
        {
            _repositoryEmployee = repository;
        }
        [HttpGet("/ListAllEmployees")]
        public IEnumerable<EmpViewModel> ListAllEmployees()
        {
            List<Employee> employees = _repositoryEmployee.AllEmployees();
            IEnumerable<EmpViewModel> empList = _repositoryEmployee.Lister(employees);
            return empList;
        }
        [HttpGet("/FindEmployee")]
        public EmpViewModel FindEmployee(int id)
        {
            Employee employeeById = _repositoryEmployee.FindEmpoyeeById(id);
            EmpViewModel empList = _repositoryEmployee.Viewer(employeeById);
            return empList;
        }
        [HttpPost("/AddEmployee")]
        public string AddEmployee(EmpViewModel newEmployeeView)
        {
            Employee newEmployee = _repositoryEmployee.ViewToEmp(newEmployeeView);
            int employeestatus = _repositoryEmployee.AddEmployee(newEmployee);
            if (employeestatus == 0)
            {
                return "Employee Not Added To Database Since it already exist";
            }
            else
            {
                return "Employee Added To Database";
            }
        }
        [HttpPut("/ModifyEmployee")]
        public Employee ModifyEmployee(int id, [FromBody] EmpViewModel newEmployeeView)
        {
            Employee newEmployee = _repositoryEmployee.FindEmpoyeeById(id);
            newEmployee = _repositoryEmployee.ViewToEmp(newEmployeeView);
            _repositoryEmployee.UpdateEmployee(newEmployee);
            return newEmployee;
        }
        [HttpDelete("/DeleteEmployee")]
        public string DeleteEmployee(int id)
        {
            int employeestatus = _repositoryEmployee.DeleteEmployee(id);
            if (employeestatus == 0)
            {
                return "Employee does not exist in the Database";
            }
            else
            {
                return "Employee Successfully Deleted";
            }
        }
    }
}

