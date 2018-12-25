using System;
using System.Collections.Generic;

namespace EventAPI.Models
{
    public partial class NewsletterToParticipant
    {
        public int Id { get; set; }
        public int NewsletterId { get; set; }
        public int ParticipantId { get; set; }

        public Newslettwe Newsletter { get; set; }
        public Participant Participant { get; set; }
    }
}
