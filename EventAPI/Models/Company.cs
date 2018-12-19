using System;
using System.Collections.Generic;

namespace EventAPI
{
    public partial class Company
    {
        public Company()
        {
            Participant = new HashSet<Participant>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string CompanyFieldOfActivity { get; set; }
        public int? MainOfficeCountryId { get; set; }

        public Country MainOfficeCountry { get; set; }
        public ICollection<Participant> Participant { get; set; }
    }
}
