using System;
using System.Collections.Generic;

namespace EventAPI
{
    public partial class Type
    {
        public Type()
        {
            EventProgElem = new HashSet<EventProgElem>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<EventProgElem> EventProgElem { get; set; }
    }
}
