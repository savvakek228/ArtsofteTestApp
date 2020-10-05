using System.Collections.ObjectModel;
using System.Diagnostics.CodeAnalysis;
 using System.Text.Json.Serialization;

 namespace ArtsofteDAL.Models
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public class Employee
    {
        public int EmployeeID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public bool Gender { get; set; }
        public int Age { get; set; }
        public int DepartmentID { get; set; }
        public int LanguageID { get; set; }
        
        public Department Department { get; set; }
        
        public Language Language { get; set; }
    }
}