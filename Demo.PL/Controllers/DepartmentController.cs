using AutoMapper;
using Demo.Bll.Interfaces;
using Demo.Dal.Models;
using Demo.PL.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Demo.PL.Controllers
{
    public class DepartmentController : Controller
    {
        //private readonly IDepartmentRepository _departmentRepository;
        private readonly IUniteOfWork _uniteOfWork;
        private readonly IMapper _mapper;

        public DepartmentController(IUniteOfWork uniteOfWork,IMapper mapper)
        {
           _uniteOfWork = uniteOfWork;
            //_departmentRepository = departmentRepository;
            _mapper = mapper;
        }
        public IActionResult Index()
        {
            var dept = _uniteOfWork.departmentRepository.GetAll();
            var deptmap = _mapper.Map<IEnumerable<Department>, IEnumerable<DeparmentViewModel>>(dept);
            return View(deptmap);
        }
        public IActionResult create()
        {
            return View();
        }
        [HttpPost]

        public IActionResult create(DeparmentViewModel departmentVm)
        {
            if (ModelState.IsValid)
            {
                var mappeddept = _mapper.Map<DeparmentViewModel, Department>(departmentVm);
                _uniteOfWork.departmentRepository.Create(mappeddept);
                _uniteOfWork.Complete();
                return RedirectToAction(nameof(Index));
            }

            return View(departmentVm);
        }
        //Details/Id
        public IActionResult Details(int? Id)
        {
            if (Id is null)
                return BadRequest();
            var department = _uniteOfWork.departmentRepository.Get(Id.Value);
            var deptmapped = _mapper.Map<Department, DeparmentViewModel>(department);
            if (department is null)
                return NotFound();
            return View(deptmapped);
        }
        public IActionResult Edit(int? id)
        {
            if (id is null)
                return BadRequest();
            var department = _uniteOfWork.departmentRepository  .Get(id.Value);
            var deptmaped = _mapper.Map<Department, DeparmentViewModel>(department);
            if (department is null)
                return NotFound();
            return View(deptmaped);
        }
        [HttpPost]
        public IActionResult Edit(DeparmentViewModel department)
        {
            if (ModelState.IsValid)
                try
                {
                    var departmentVm = _mapper.Map<DeparmentViewModel, Department>(department);
                _uniteOfWork.departmentRepository.Update(departmentVm);
                    _uniteOfWork.Complete();
                 return RedirectToAction(nameof(Index));
                }
                catch (Exception e)
                {

                    ModelState.AddModelError(string.Empty, e.Message);
                }
            
            return View(department);
        }
        public IActionResult Delete(int? id)
        {
            var dept =_uniteOfWork.departmentRepository.Get(id.Value);
            var deptmapped = _mapper.Map<Department, DeparmentViewModel>(dept);

            return View(deptmapped);
        }
        [HttpPost]
        public IActionResult Delete(DeparmentViewModel departmentVm) 
        {
         var mapeddept=_mapper.Map<DeparmentViewModel,Department>(departmentVm);
                _uniteOfWork.departmentRepository.Delete(mapeddept);
              _uniteOfWork.Complete();
               return RedirectToAction(nameof (Index));  

        }






    }
}