using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Three.Models
{
    /// <summary>
    /// 公司情况表
    /// </summary>
    public class CompanySummary
    {
        public int EmployeeCount { get; set; }//员工总人数
        public int AverageDepartmentEmployeeCount { get; set; }//每个部门平均人数
    }
}
