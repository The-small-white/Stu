using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Three.Models;
using Three.Service;
using Three.Services;

namespace Three.Controllers
{
    public class EmployeeController : Controller
    {
        //定义两个只读的操作接口字段
        private readonly IDepartmentService _departmentService;
        private readonly IEmployeeService _employeeService;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="departmentService"></param>
        /// <param name="employeeService"></param>
        public EmployeeController(IDepartmentService departmentService, IEmployeeService employeeService)
        {
            _departmentService = departmentService;
            _employeeService = employeeService;
        }

        public async Task<IActionResult> Index(int departmentId)
        {
            var department = await this._departmentService.GetById(departmentId);//通过部门id查找部门人数
           ViewBag.Title = $"Employee of {department.Name}";
            ViewBag.DepartmentId = departmentId;
            var employees = await _employeeService.GetByDepartmentId(departmentId);//查询部门下员工信息
            return View(employees);
        }
        
        public IActionResult Add(int departmentId)
        {
            ViewBag.Title = "Add Employee";
            return View(new Employee
            {
                DepartmentId = departmentId
            });
        }

        [HttpPost]
        public async Task<IActionResult> Add(Employee model)
        {
            if (ModelState.IsValid)
            {
                await _employeeService.Add(model);
            }
            return RedirectToAction(nameof(Index), new { departmentId = model.DepartmentId });
        }

        public async Task<IActionResult> Fire(int employeeId)
        {
            var employee = await _employeeService.Fire(employeeId);
            return RedirectToAction(nameof(Index), new { departmentId = employee.DepartmentId });
        }

    }
}
