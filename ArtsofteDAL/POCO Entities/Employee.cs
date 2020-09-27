using System.Collections.ObjectModel;
using System.Diagnostics.CodeAnalysis;

namespace ArtsofteDAL.POCO_Entities
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public class Employee
    {
        public int EmployeeID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public virtual Collection<Department> Departments { get; set; }
        public virtual Collection<Language> Languages { get; set; }

        public Employee()
        {
            Departments = new Collection<Department>();
            Languages = new Collection<Language>();
        }
    }
}