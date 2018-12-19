using System;
using System.Collections.Generic;

namespace EventAPI
{
    public partial class ParticipantToEventProgElem
    {
        public int Id { get; set; }
        public int EventProgElemId { get; set; }
        public int ParticipantId { get; set; }

        public EventProgElem EventProgElem { get; set; }
        public Participant Participant { get; set; }
    }
}
