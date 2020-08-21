using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Three.Models;

namespace Three.Service
{
    /// <summary>
    /// 操作部门表接口
    /// </summary>
   public  interface IDepartmentService
    {
        Task<IEnumerable<Department>> GetAll();

        Task<Department> GetById(int id);
        /// <summary>
        /// 获取公司部门平均人数
        /// </summary>
        /// <returns></returns>
        Task<CompanySummary> GetCompanySummary();
        Task Add(Department department);
    }
}
