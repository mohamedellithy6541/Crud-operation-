using Demo.Bll.Interfaces;
using Demo.Bll.Repository;
using Demo.Dal.Context;
using Demo.Dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Bll
{
    public class DepartmentRepository : GenaricRepository<Department> ,IDepartmentRepository
    {
        public DepartmentRepository(Mydbcontext mydbcontext):base(mydbcontext)
        {
            
        }
    }
}
