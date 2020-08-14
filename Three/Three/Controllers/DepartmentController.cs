using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Three.Services;
using Three.Models;
using Microsoft.Extensions.Options;
using Three.Service;

namespace Three.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IDepartmentService _departmentService;

       // 用于检索已配置的选项实例。
        private readonly IOptions<ThreeOptions> _threeOptions;

        public IOptions<ThreeOptions> ThreeOptions { get; }

        public DepartmentController(IDepartmentService departmentService, IOptions<ThreeOptions> threeOptions)
        {
            _departmentService = departmentService;
            _threeOptions = threeOptions;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.Title = "Department Index";
            var departments = await _departmentService.GetAll();
            return View(departments);
        }

        //[HTTPGet]
        public IActionResult Add()
        {
            ViewBag.Title = "添加员工";
            return View(new Department());
        }
        [HttpPost]
        public async Task<IActionResult> Add(Department m)
        {
            if (ModelState.IsValid)
            {
                await _departmentService.Add(m);
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
