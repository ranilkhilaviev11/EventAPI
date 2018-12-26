using System;
using System.Collections.Generic;

namespace EventAPI
{
    public partial class Newsletter
    {
        public Newsletter()
        {
            NewsletterToParticipant = new HashSet<NewsletterToParticipant>();
        }

        public int EventId { get; set; }
        public DateTime SendDateTime { get; set; }
        public string Message { get; set; }
        public string File { get; set; }
        public int Id { get; set; }

        public Events Event { get; set; }
        public ICollection<NewsletterToParticipant> NewsletterToParticipant { get; set; }
    }
}
