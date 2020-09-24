using System.Diagnostics.CodeAnalysis;

namespace ArtsofteDAL.POCO_Entities
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public class Department
    {
        public int DepartmentID { get; set; } 
        public int EmployeeID { get; set; }
        public string Name { get; set; }
        public int Floor { get; set; }
        
        // nav property to Employees
        public Employee Employee { get; set; }
    }
}