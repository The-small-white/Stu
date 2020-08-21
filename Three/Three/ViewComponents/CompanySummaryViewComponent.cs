using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Three.Service;
using Three.Services;

namespace Three.ViewComponents
{
    public class CompanySummaryViewComponent : ViewComponent
    {
        /// <summary>
        /// 定义只读操作部门类
        /// </summary>
        private readonly IDepartmentService _departmentService;

        public CompanySummaryViewComponent(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }
        public async Task<IViewComponentResult> InvokeAsync(string title)
        {
            ViewBag.Title = title;
            var summary = await _departmentService.GetCompanySummary();
            return View(summary);
        }
    }
}
