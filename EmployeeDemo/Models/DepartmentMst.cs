using System;
using System.Collections.Generic;

namespace EmployeeDemo.Models;

public partial class DepartmentMst
{
    public int DepartmentId { get; set; }

    public string DepartmentName { get; set; } = null!;

    public virtual ICollection<EmployeeMst> EmployeeMsts { get; set; } = new List<EmployeeMst>();
}
