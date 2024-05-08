using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting.Internal;
using PayCompute.Entity;
using PayCompute.Models;
using PayCompute.Services;

namespace PayCompute.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeServices _employeeServices;
        private readonly HostingEnvironment _hostingEnvironment;

        public EmployeeController(IEmployeeServices employeeServices, HostingEnvironment hostingEnvironment) 
        {
            this._employeeServices = employeeServices;
            this._hostingEnvironment = hostingEnvironment;
        }

        public IActionResult Index()
        {
            var employees = _employeeServices.GetAll().Select(employee => new EmployeeIndexViewModel
            {
                Id = employee.Id,
                EmployeeNo = employee.EmployeeNo,
                ImageUrl = employee.ImageUrl,
                FullName = employee.FullName,
                Gender = employee.Gender,
                Designation = employee.Designation,
                City = employee.City,
                DateJoined = employee.DateJoined
            }).ToList();
            return View(employees);
        }

        [HttpGet]
        public IActionResult Create() 
        {
            var model = new EmployeeCreateViewModel();
            return View();

        }

        [HttpPost]
        [ValidateAntiForgeryToken] //Prevents cross-site Request Forgery Attacks
        public async Task<IActionResult> Create(EmployeeCreateViewModel model)
        {
            if(ModelState.IsValid)
            {
                var employee = new Employee
                {
                    Id = model.Id,
                    EmployeeNo = model.EmployeeNo,
                    FirstName = model.FirstName,
                    MiddleName = model.MiddleName,
                    LastName = model.LastName,
                    FullName = model.FullName,
                    Gender = model.Gender,
                    Email = model.Email,
                    DOB = model.DOB,
                    DateJoined = model.DateJoined,
                    NationalInsuranceNoOrPin = model.NationalInsuranceNoOrPin,
                    PaymentMethod = model.PaymentMethod,
                    StudentLoan = model.StudentLoan,
                    UnionMember = model.UnionMember,
                    Address = model.Address,
                    City = model.City,
                    Phone = model.Phone,
                    Postcode = model.Postcode,
                    Designation = model.Designation
                };

                if (model.ImageUrl != null && model.ImageUrl.Length > 0)
                {
                    var uploadDir = @"wwwroot/Images/employee";
                    var fileName = Path.GetFileNameWithoutExtension(model.ImageUrl.FileName);
                    var extention = Path.GetExtension(model.ImageUrl.FileName);
                    var webRootPath = _hostingEnvironment.ContentRootPath;
                    fileName = DateTime.UtcNow.ToString("yymmssfff") + fileName + extention;
                    var path = Path.Combine(webRootPath, uploadDir, fileName);
                    await model.ImageUrl.CopyToAsync(new FileStream(path, FileMode.Create));
                    employee.ImageUrl = "/" + uploadDir + "/" + fileName;
                }
                await _employeeServices.CreateAsync(employee);
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

       
        public IActionResult Edit(int id)
        {
            var employee = _employeeServices.GetById(id);
            if (employee == null)
            {
                return NotFound();
            }
            var model = new EmployeeEditViewModel()
            {
                Id = employee.Id,
                EmployeeNo = employee.EmployeeNo,
                FirstName = employee.FirstName,
                MiddleName = employee.MiddleName,
                LastName = employee.LastName,
                Gender = employee.Gender,
                Email = employee.Email,
                DOB = employee.DOB,
                DateJoined = employee.DateJoined,
                NationalInsuranceNoOrPin = employee.NationalInsuranceNoOrPin,
                PaymentMethod = employee.PaymentMethod,
                StudentLoan = employee.StudentLoan,
                UnionMember = employee.UnionMember,
                Address = employee.Address,
                City = employee.City,
                Phone = employee.Phone,
                Postcode = employee.Postcode,
                Designation = employee.Designation
            };
            return View(model);  
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EmployeeEditViewModel model) 
        {
            if (ModelState.IsValid)
            {
                var employee = _employeeServices.GetById(model.Id);
                if(employee == null)
                {
                    return NotFound();
                }
                employee.EmployeeNo = model.EmployeeNo;
                employee.FirstName = model.FirstName;
                employee.MiddleName = model.MiddleName;
                employee.LastName = model.LastName;
                employee.Gender = model.Gender;
                employee.Email = model.Email;
                employee.DOB = model.DOB;
                employee.Phone = model.Phone;
                employee.DateJoined = model.DateJoined;
                employee.Designation = model.Designation;
                employee.NationalInsuranceNoOrPin = model.NationalInsuranceNoOrPin;
                employee.PaymentMethod = model.PaymentMethod;
                employee.StudentLoan = model.StudentLoan;
                employee.UnionMember = model.UnionMember;
                employee.Address = model.Address;
                employee.City = model.City;
                employee.Postcode = model.Postcode;
                if(model.ImageUrl != null && model.ImageUrl.Length > 0)
                {
                    var uploadDir = @"images/employee";
                    var fileName = Path.GetFileNameWithoutExtension(model.ImageUrl.FileName);
                    var extention = Path.GetExtension(model.ImageUrl.FileName);
                    var webRootPath = _hostingEnvironment.ContentRootPath;
                    fileName = DateTime.UtcNow.ToString("yymmssfff") + fileName + extention;
                    var path = Path.Combine(webRootPath, uploadDir, fileName);
                    await model.ImageUrl.CopyToAsync(new FileStream(path, FileMode.Create));
                    employee.ImageUrl = "/" + uploadDir + "/" + fileName;
                }
                await _employeeServices.UpdateAsync(employee);
                return RedirectToAction(nameof(Index));
            }
            return View();
        
        }

        [HttpGet]
        public IActionResult Detail(int id)
        {
            var employee = _employeeServices.GetById(id);
            if (employee == null)
            {
                return NotFound();
            }
            EmployeeDetailViewModel model = new EmployeeDetailViewModel()
            {
                Id = employee.Id,
                EmployeeNo = employee.EmployeeNo,
                FullName = employee.FullName,
                Gender = employee.Gender,
                DOB = employee.DOB,
                DateJoined = employee.DateJoined,
                Designation = employee.Designation,
                NationalInsuranceNoOrPin = employee.NationalInsuranceNoOrPin,
                Phone = employee.Phone,
                Email = employee.Email,
                PaymentMethod = employee.PaymentMethod,
                StudentLoan = employee.StudentLoan,
                UnionMember = employee.UnionMember,
                Address = employee.Address,
                City = employee.City,
                ImageUrl = employee.ImageUrl,
                Postcode = employee.Postcode
            };
            return View(model);


        }

        [HttpGet]
        public IActionResult Delete(int Id)
        {
            var employee = _employeeServices.GetById(Id);
            if (employee == null)
            {
                return NotFound();
            }
            var model = new EmployeeDeleteViewModel()
            {
                Id = employee.Id,
                FullName = employee.FullName
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(EmployeeDeleteViewModel model)
        {
            await _employeeServices.Delete(model.Id);
            return RedirectToAction(nameof(Index));
        }
    }
}
