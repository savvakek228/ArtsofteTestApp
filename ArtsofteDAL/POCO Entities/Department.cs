using System;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

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
        [JsonIgnore]
        public Employee Employee { get; set; }
    }
}