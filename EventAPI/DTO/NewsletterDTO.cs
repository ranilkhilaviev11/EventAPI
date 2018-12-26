using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventAPI
{
    public class NewsletterDTO
    {


        public int Id { get; set; }
        public int EventId { get; set; }
        public DateTime SendDateTime { get; set; }
        public string Message { get; set; }
        public string File { get; set; }



    }
}
