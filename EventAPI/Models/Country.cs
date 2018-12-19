using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace EventAPI
{
    public partial class Country
    {
        public Country()
        {
            Company = new HashSet<Company>();
            ParticipantCitizenship = new HashSet<Participant>();
            ParticipantResidenceCountry = new HashSet<Participant>();
        }
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }
        [JsonProperty(PropertyName = "nameRus")]
        public string Name { get; set; }

        public ICollection<Company> Company { get; set; }
        public ICollection<Participant> ParticipantCitizenship { get; set; }
        public ICollection<Participant> ParticipantResidenceCountry { get; set; }
    }
}
