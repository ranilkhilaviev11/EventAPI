using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventAPI
{
    public class NewsletterToParticipantDTO
    {
        public int Id { get; set; }
        public int NewsletterId { get; set; }
        public int ParticipantId { get; set; }

    }


}

