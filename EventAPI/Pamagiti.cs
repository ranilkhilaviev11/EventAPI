using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventAPI
{
    public class Pamagiti
    {

        public int Id { get; set; }
        public int EventId { get; set; }
        public DateTime SendDateTime { get; set; }
        public string Message { get; set; }
        public string File { get; set; }
      //  public int NewsletterToParticipantId { get; set; }
      //  public int ParticipantId { get; set; }
        public IGrouping<string ,NewsletterToParticipantDTO> Participants { get; set; }
    }
}
