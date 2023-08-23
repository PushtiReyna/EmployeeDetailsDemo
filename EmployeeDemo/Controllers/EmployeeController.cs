using EmployeeDemo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace EmployeeDemo.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly EmployeeDbContext _db;

        public EmployeeController(EmployeeDbContext db)
        {
            _db = db;
        }

        public IActionResult ListEmployee()
        {
            try
            {
                List<FetchData> employeeList = new List<FetchData>();

                FetchData employeeData = new FetchData();

                var EmployeeList = _db.EmployeeMsts.ToList();
                #region foreach 

                foreach (var item in EmployeeList)
                {
                    var departmentName = _db.DepartmentMsts.FirstOrDefault(x => x.DepartmentId == item.DepartmentId);
                    employeeData = new FetchData();
                    employeeData.EmployeeId = item.EmployeeId;
                    employeeData.EmployeeName = item.EmployeeName;
                    employeeData.Gender = item.Gender;
                    employeeData.Dob = item.Dob;
                    employeeData.MobileNo = item.MobileNo;
                    employeeData.UserName = item.UserName;
                    employeeData.Address = item.Address;
                    employeeData.Passoword = item.Passoword;
                    if (departmentName != null)
                    {
                        employeeData.DepartmentName = departmentName.DepartmentName;
                    }
                  
                    employeeList.Add(employeeData);
                }


                #endregion
                #region linq through join
                //var employeeList = (from u in _db.EmployeeMsts
                //                    join j in _db.DepartmentMsts
                //                    on u.DepartmentId equals j.DepartmentId
                //                    select new FetchData
                //                    {
                //                        EmployeeId = u.EmployeeId,
                //                        EmployeeName = u.EmployeeName,
                //                        DepartmentName = j.DepartmentName

                //                    }).ToList();
                #endregion
                //foreach (var employee in EmployeeList)
                //{
                //    employeeData.EmployeeName = employee.EmployeeName;

                //}
                //LoadDepartments();
                #region 
                // view bag through pass list
                //  var model = new EmployeeMst();
                // ViewBag.departmentlist = new SelectList(GetDepartmentList(),"Id", "Title");

                //var employeeList = _db.EmployeeMsts.ToList();
                #endregion
                return View(employeeList);
            }
            catch (Exception ex)
            {
                throw;
            }

        }
        public IActionResult DetailEmployee(int id)
        {
            try
            {
                FetchData employeeData = new FetchData();
                var employeeDetail = _db.EmployeeMsts.FirstOrDefault(x => x.EmployeeId == id);
                if (employeeDetail != null)
                {
                    var departmentName = _db.DepartmentMsts.FirstOrDefault(x => x.DepartmentId == employeeDetail.DepartmentId);
                    employeeData = new FetchData();
                    employeeData.EmployeeId = employeeDetail.EmployeeId;
                    employeeData.EmployeeName = employeeDetail.EmployeeName;
                    employeeData.Gender = employeeDetail.Gender;
                    employeeData.Dob = employeeDetail.Dob;
                    employeeData.MobileNo = employeeDetail.MobileNo;
                    employeeData.UserName = employeeDetail.UserName;
                    employeeData.Address = employeeDetail.Address;
                    employeeData.Passoword = employeeDetail.Passoword;
                    employeeData.DepartmentName = departmentName.DepartmentName;

                    return View(employeeData);
                }

                return RedirectToAction("ListEmployee");
            }

            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpGet]
        public IActionResult CreateEmployee()
        {
            try
            {
                //var model = new EmployeeMst();
                //return View(model);
                LoadDepartments();
                return View();
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        [HttpPost]
        public IActionResult CreateEmployee(EmployeeMst Employee)
        {
            try
            {
                LoadDepartments();

                if (ModelState.IsValid)
                {
                    if (_db.EmployeeMsts.Where(u => u.EmployeeName == Employee.EmployeeName).Any())
                    {
                        TempData["ErrorMessage"] = "Employee Name already exists.";
                        return View();
                    }
                    else
                    {
                        var EmployeeAdd = new EmployeeMst()
                        {
                            EmployeeName = Employee.EmployeeName,
                            Gender = Employee.Gender,
                            Dob = Employee.Dob,
                            DepartmentId = Employee.DepartmentId,
                            MobileNo = Employee.MobileNo,
                            Address = Employee.Address,
                            UserName = Employee.UserName,
                            Passoword = Employee.Passoword,
                        };

                        _db.EmployeeMsts.Add(EmployeeAdd);
                        _db.SaveChanges();
                        return RedirectToAction("ListEmployee");
                    }
                }
                return View();
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        [HttpGet]
        public IActionResult UpdateEmployee(int id)
        {
            try
            {
                LoadDepartments();
                var employeeDetail = _db.EmployeeMsts.FirstOrDefault(x => x.EmployeeId == id);
                if (employeeDetail != null)
                {
                    return View(employeeDetail);
                }
                return RedirectToAction("ListEmployee");
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        [HttpPost]
        public IActionResult UpdateEmployee(EmployeeMst Employee)
        {
            try
            {
                var updateEmployee = _db.EmployeeMsts.FirstOrDefault(x => x.EmployeeId == Employee.EmployeeId);

                if (updateEmployee != null)
                {
                    updateEmployee.EmployeeId = Employee.EmployeeId;
                    updateEmployee.EmployeeName = Employee.EmployeeName;
                    updateEmployee.Gender = Employee.Gender;
                    updateEmployee.Dob = Employee.Dob;
                    updateEmployee.DepartmentId = Employee.DepartmentId;
                    updateEmployee.MobileNo = Employee.MobileNo;
                    updateEmployee.Address = Employee.Address;
                    updateEmployee.UserName = Employee.UserName;
                    updateEmployee.Passoword = Employee.Passoword;


                    if (_db.EmployeeMsts.Where(u => u.EmployeeName == updateEmployee.EmployeeName && u.EmployeeId != updateEmployee.EmployeeId).Any())
                    {
                        TempData["ErrorMessage"] = "Employee Name already exists.";
                        return View();
                    }
                    else
                    {
                        _db.Entry(updateEmployee).State = EntityState.Modified;
                        _db.SaveChanges();
                        return RedirectToAction("ListEmployee");
                    }
                }
                return View();
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public IActionResult DeleteEmployee(int id)
        {
            try
            {
                var employeeDelete = _db.EmployeeMsts.FirstOrDefault(x => x.EmployeeId == id);
                if (employeeDelete != null)
                {
                    _db.EmployeeMsts.Remove(employeeDelete);
                    _db.SaveChanges();
                    return RedirectToAction("ListEmployee");
                }
                return RedirectToAction("ListEmployee");
            }
            catch (Exception ex)
            {

                throw;
            }
        }



        //private List<EmployeeMst> GetDepartmentList()
        //{
        //     var department = new List<EmployeeMst>();
        //    department.Add(new EmployeeMst() { Id=1, Title = "it" });
        //    department.Add(new EmployeeMst() { Id = 2, Title = "cse" });
        //    return department;
        //}

        [NonAction]
        private void LoadDepartments()
        {
            var departments = _db.DepartmentMsts.ToList();
            ViewBag.DepartmentMsts = new SelectList(departments, "DepartmentId", "DepartmentName");
        }
    }
}
