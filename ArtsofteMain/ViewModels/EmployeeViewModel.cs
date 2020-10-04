using System.Diagnostics.CodeAnalysis;

namespace ArtsofteTestWebApp.ViewModels
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public class EmployeeViewModel
    {
        public int? EmployeeID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public bool Gender { get; set; }
        public int Age { get; set; }
        public string Department { get; set; }
        public string Language { get; set; }
    }
}