using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Three.Models;

 namespace Three.Services
{
    /// <summary>
    /// 员工服务接口
    /// </summary>
    public interface IEmployeeService
    {
        /// <summary>
        /// 添加员工
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        Task Add(Employee employee);
        /// <summary>
        /// 获取员工表
        /// </summary>
        /// <param name="departmentId"></param>
        /// <returns></returns>
        Task<IEnumerable<Employee>> GetByDepartmentId(int departmentId);
        /// <summary>
        /// 开除员工
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Employee> Fire(int id);
    }
}
