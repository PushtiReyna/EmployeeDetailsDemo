using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeDemo.Models;

public partial class EmployeeMst
{
    public int EmployeeId { get; set; }

    [Required(ErrorMessage = "Please enter your Name"), MaxLength(50)]
    [RegularExpression(@"^[a-zA-Z][a-zA-Z ]+[a-zA-Z]$", ErrorMessage = "Please enter only letters for Employee Name.")]
    public string EmployeeName { get; set; } = null!;


    [Required(ErrorMessage = "Please enter your Gender")]
    public string Gender { get; set; } = null!;


    [DataType(DataType.DateTime)]
    [Required(ErrorMessage = "Please enter your  Date Of Birth")]
    public DateTime Dob { get; set; }


    [Required(ErrorMessage = "Please enter your Mobile No.")]
    [MinLength(10, ErrorMessage = "The Mobile No. must be at least 10 characters")]
    [MaxLength(10, ErrorMessage = "The Mobile No. cannot be more than 10 characters")]
    public string MobileNo { get; set; } = null!;


    [Required(ErrorMessage = "Please enter your  Address"), MaxLength(100)]
    public string Address { get; set; } = null!;


    [Required(ErrorMessage = "Please enter your Username"), MaxLength(10)]
    [RegularExpression(@"^[a-zA-Z0-9][a-zA-Z0-9 ]+[a-zA-Z0-9]$", ErrorMessage = "username must contain uppercase letter, lowercase letter and numbers.")]
    
    public string UserName { get; set; } = null!;

    [DataType(DataType.Password)]
    [Required(ErrorMessage = "Please enter your password")]
    [MinLength(4, ErrorMessage = "The password must be at least 4 characters")]
    [MaxLength(6, ErrorMessage = "The password cannot be more than 6 characters")]
    [RegularExpression(@"^((?=.*[a-z])(?=.*[A-Z])(?=.*\d)).+$", ErrorMessage = "Password must contain uppercase letter,lowercase letter and special chararcters.")]
    public string Passoword { get; set; } = null!;


    [Required(ErrorMessage = "Please Select Department.")]
    public int? DepartmentId { get; set; }




    //public string? Department { get; set; }
   // [ForeignKey("DepartmentMst")]
   // public int Departmentid { get; set; }
   public virtual DepartmentMst? Departments { get; set; }

    //public List<EmployeeMst> GetDepartmentList()
    //{
    //    var department = new List<EmployeeMst>();
    //    
    //    return department;
    //}
}
