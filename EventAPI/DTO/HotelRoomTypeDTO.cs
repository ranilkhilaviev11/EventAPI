using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventAPI
{
    public class HotelRoomTypeDTO
    {
        public int Id { get; set; }
        public int HotelId { get; set; }
        public string Type { get; set; }
    }
}
