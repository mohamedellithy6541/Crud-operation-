using Demo.Bll.Interfaces;
using Demo.Dal.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Bll.Repository
{
    public class UniteOfWork : IUniteOfWork
    {
        private readonly Mydbcontext _mydbcontext;

        public IDepartmentRepository departmentRepository { get; set ; }
        public IEmployeeRepository EmployeeRepository { get; set; }
        public UniteOfWork(Mydbcontext mydbcontext)
        {
            departmentRepository = new DepartmentRepository(mydbcontext);
            EmployeeRepository = new EmployeeRepository(mydbcontext);
            _mydbcontext = mydbcontext;
        }
        public int Complete()
        {
            return _mydbcontext.SaveChanges();
        }

        public void Dispose()
        {
            _mydbcontext.Dispose();
        }
    }
}
