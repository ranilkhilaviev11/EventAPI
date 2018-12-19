using System;
using System.Collections.Generic;

namespace EventAPI
{
    public partial class Participant
    {
        public Participant()
        {
            NewsletterToParticipant = new HashSet<NewsletterToParticipant>();
            ParticipantToEventProgElem = new HashSet<ParticipantToEventProgElem>();
        }

        public int Id { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string MiddleName { get; set; }
        public DateTime BirthDate { get; set; }
        public string PhoneNum { get; set; }
        public string Email { get; set; }
        public string Post { get; set; }
        public int? EventId { get; set; }
        public int? ResidenceCountryId { get; set; }
        public int? CitizenshipId { get; set; }
        public int? CompanyId { get; set; }
        public int? HotelId { get; set; }
        public int? HotelRoomTypeId { get; set; }

        public Country Citizenship { get; set; }
        public Company Company { get; set; }
        public Events Event { get; set; }
        public Hotel Hotel { get; set; }
        public HotelRoomType HotelRoomType { get; set; }
        public Country ResidenceCountry { get; set; }
        public ICollection<NewsletterToParticipant> NewsletterToParticipant { get; set; }
        public ICollection<ParticipantToEventProgElem> ParticipantToEventProgElem { get; set; }
    }
}
