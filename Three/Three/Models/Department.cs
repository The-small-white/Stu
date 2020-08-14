using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Three.Models
{
    /// <summary>
    /// 部门表
    /// </summary>
    public class Department
        
    {
        [Display(Name = "部门id")]
        /// <summary>
        /// 部门id
        /// </summary>
        public int Id { get; set; }

        [Display(Name="部门名称")] //asp- for用法
        /// <summary>
        /// 部门名字
        /// </summary>
        
        public string Name { get; set; }
        [Display(Name = "部门地区")]
        /// <summary>
        /// 部门地区
        /// </summary>
        public string Location { get; set; }
        [Display(Name = "员工人数")]
        /// <summary>
        /// 员工人数
        /// </summary>
        public int EmployeeCount { get; set; }

    }
}
