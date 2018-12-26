using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventAPI
{
    public class EventsDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime Enddate { get; set; }
        public DateTime StartReg { get; set; }
        public DateTime? Endreg { get; set; }
    }
}
