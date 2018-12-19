using System;
using System.Collections.Generic;

namespace EventAPI
{
    public partial class Hotel
    {
        public Hotel()
        {
            HotelRoomType = new HashSet<HotelRoomType>();
            Participant = new HashSet<Participant>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<HotelRoomType> HotelRoomType { get; set; }
        public ICollection<Participant> Participant { get; set; }
    }
}
