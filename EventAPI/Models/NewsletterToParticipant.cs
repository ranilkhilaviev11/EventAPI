using System;
using System.Collections.Generic;

namespace EventAPI
{
    public partial class NewsletterToParticipant
    {
        public int Id { get; set; }
        public int NewsletterId { get; set; }
        public int ParticipantId { get; set; }

        public Newsletter Newsletter { get; set; }
        public Participant Participant { get; set; }
    }
}
