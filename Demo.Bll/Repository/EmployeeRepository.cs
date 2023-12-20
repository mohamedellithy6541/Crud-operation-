using Demo.Bll.Interfaces;
using Demo.Dal.Context;
using Demo.Dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Bll.Repository
{
    public class EmployeeRepository : GenaricRepository<Employee> , IEmployeeRepository    
    {
        private readonly Mydbcontext _mydbcontext;

        public EmployeeRepository( Mydbcontext mydbcontext):base(mydbcontext)
        {
           _mydbcontext = mydbcontext;
        }

        public IQueryable<Employee> SearchByName(string name)
        => _mydbcontext.Employees.Where(e=>e.Name.ToLower().Contains(name));
    }
}
