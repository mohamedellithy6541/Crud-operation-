    using AutoMapper;
using Demo.Bll.Interfaces;
using Demo.Dal.Models;
using Demo.PL.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace Demo.PL.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IUniteOfWork _uniteOfWork;

        //private readonly IEmployeeRepository _EmployeeRepository;

        private readonly IMapper _mapper;

        public EmployeeController( /* IEmployeeRepository EmployeeRepository*/ 
            IUniteOfWork uniteOfWork,IMapper mapper )  
        {
           _uniteOfWork = uniteOfWork;
            //_EmployeeRepository = EmployeeRepository;

            _mapper = mapper;
        }
        public IActionResult Index(string searchvalue)
        {
            IEnumerable<Employee> Emp; 
            if (string.IsNullOrEmpty(searchvalue))
              Emp = _uniteOfWork.EmployeeRepository.GetAll();
            else  
             Emp=_uniteOfWork.EmployeeRepository.SearchByName(searchvalue);
          
            var emPmAP = _mapper.Map<IEnumerable<Employee>, IEnumerable<EmployeeViewModel>>(Emp);
            return View(emPmAP);
        }
        [HttpGet]
        public IActionResult create()
        {
            return View();
        }
      
         [HttpPost]
        public IActionResult create(EmployeeViewModel employeeViewModel)
        {
            if (ModelState.IsValid)
            {
                #region Manualmapped
                //var employee = new Employee()
                //{
                //    Name = employeeViewModel.Name,
                //    Address = employeeViewModel.Address,
                //    Age = employeeViewModel.Age,
                //    Salary = employeeViewModel.Salary,
                //    Email = employeeViewModel.Email,
                //    HireDate = employeeViewModel.HireDate,
                //    Departmentid = employeeViewModel.Departmentid,
                //};
                #endregion

                var empmaped = _mapper.Map<EmployeeViewModel, Employee>(employeeViewModel);
                _uniteOfWork.EmployeeRepository.Create(empmaped);
                _uniteOfWork.Complete();
                return RedirectToAction(nameof(Index));
            }

            return View(employeeViewModel);
        }
        //Details/Id
        public IActionResult Details(int? Id)
        {
            if (Id is null)
                return BadRequest();
            var Employee = _uniteOfWork.EmployeeRepository.Get(Id.Value);
            if (Employee is null)
                return NotFound();
            var employeevm = _mapper.Map<Employee,EmployeeViewModel>(Employee);
            return View(employeevm);
        }
        public IActionResult Edit(int? id)
        {
            if (id is null)
              return BadRequest();
            var Employee =_uniteOfWork.EmployeeRepository.Get(id.Value);
            var empmaped= _mapper.Map<Employee, EmployeeViewModel>(Employee);
            
            if (Employee is null)
                return NotFound();
            return View(empmaped);
        }
        [HttpPost]
        public IActionResult Edit(EmployeeViewModel EmpVm)
        {
            if (ModelState.IsValid)
                try
                {
                    var employee=_mapper.Map<EmployeeViewModel, Employee>(EmpVm);
                    _uniteOfWork.EmployeeRepository.Update(employee);
                    _uniteOfWork.Complete();
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception e)
                {

                    ModelState.AddModelError(string.Empty, e.Message);
                }

            return View(EmpVm);
        }
        public IActionResult Delete(int? id)
        {
            var dept =_uniteOfWork.EmployeeRepository.Get(id.Value);

            var employeevm = _mapper.Map<Employee, EmployeeViewModel>(dept);

             
            return View(employeevm);
        }
        [HttpPost]
        public IActionResult Delete(EmployeeViewModel  EmployeeVm)
        {
            var employee = _mapper.Map<EmployeeViewModel, Employee>(EmployeeVm);
             _uniteOfWork.EmployeeRepository.Delete(employee);
            _uniteOfWork.Complete();
            return RedirectToAction(nameof(Index));
        }

    }
}
