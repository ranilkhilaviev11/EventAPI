using System;
using System.Collections.Generic;

namespace EventAPI.Models
{
    public partial class EventProgElem
    {
        public EventProgElem()
        {
            ParticipantToEventProgElem = new HashSet<ParticipantToEventProgElem>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public int EventId { get; set; }
        public int TypeId { get; set; }

        public Events Event { get; set; }
        public Type Type { get; set; }
        public ICollection<ParticipantToEventProgElem> ParticipantToEventProgElem { get; set; }
    }
}
