using Demo.Dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Bll.Interfaces
{
    public interface IEmployeeRepository :IGenaricRepository<Employee>
    {
        IQueryable<Employee> SearchByName(string name);
    }
}
