using System;
 using System.Collections.Generic;
 using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace ArtsofteDAL.POCO_Entities
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public class Language
    {
        public int LanguageID { get; set; }
        public string Name { get; set; }
        
        // nav property to Employees
        public ICollection<Employee> Employees { get; set; }
    }
}