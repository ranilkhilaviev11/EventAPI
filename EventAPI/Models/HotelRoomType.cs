using System;
using System.Collections.Generic;

namespace EventAPI
{
    public partial class HotelRoomType
    {
        public HotelRoomType()
        {
            Participant = new HashSet<Participant>();
        }

        public int Id { get; set; }
        public int HotelId { get; set; }
        public string Type { get; set; }

        public Hotel hotel { get; set; }
        public ICollection<Participant> Participant { get; set; }
    }
}
