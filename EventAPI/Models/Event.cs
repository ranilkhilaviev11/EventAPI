using System;
using System.Collections.Generic;

namespace EventAPI
{
    public partial class Events
    {
        public Events()
        {
            EventProgElem = new HashSet<EventProgElem>();
            Newsletter = new HashSet<Newsletter>();
            Participant = new HashSet<Participant>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime Enddate { get; set; }
        public DateTime StartReg { get; set; }
        public DateTime? Endreg { get; set; }

        public ICollection<EventProgElem> EventProgElem { get; set; }
        public ICollection<Newsletter> Newsletter { get; set; }
        public ICollection<Participant> Participant { get; set; }
    }
}
