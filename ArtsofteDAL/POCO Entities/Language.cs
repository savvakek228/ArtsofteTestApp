using System.Diagnostics.CodeAnalysis;

namespace ArtsofteDAL.POCO_Entities
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public class Language
    {
        public int LanguageID { get; set; }
        public int EmployeeID { get; set; }
        public string Name { get; set; }
        
        // nav property to Employees
        public Employee Employee { get; set; }
    }
}