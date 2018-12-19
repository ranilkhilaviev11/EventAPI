using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace EventAPI
{

    public class DeserializingCountries
    {
        MailingContext _context = new MailingContext();

        public List<Country> myobjList;
        public void PostCountries()
        {

            if (!_context.Country.Any())
            {
                //string path = File.ReadAllText(@"countries_ru.json");
                StreamReader re = new StreamReader("countries_ru.json");
                JsonTextReader reader = new JsonTextReader(re);
                JsonSerializer JSON = new JsonSerializer();
                myobjList = JSON.Deserialize<List<Country>>(reader);

            }
        }
    }
}
