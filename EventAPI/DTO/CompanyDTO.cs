using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventAPI
{
    public class CompanyDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CompanyFieldOfActivity { get; set; }
        public int MainOfficeCountryId { get; set; }
    }
}
