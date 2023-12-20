using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Bll.Interfaces
{
    public interface IUniteOfWork
    {
        public IEmployeeRepository EmployeeRepository { get; set; }
        public IDepartmentRepository departmentRepository   { get; set; }
        public int Complete();

        public void Dispose();

    }
}
