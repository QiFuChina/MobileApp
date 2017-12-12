using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelRecord.Data;

namespace TravelRecord.Model
{
    class Organization
    {
        public List<Event> Event { get; set; }
        public String Name { get; set; }

        public int ID { get; set; }
        public String Title { get; set; }
        public String Date { get; set; }
        public String Introduction { get; set; }

        public Organization(String databaseName)
        {
            Name = databaseName;
            Event = LocalData.GetEvent();
        }
    }
}
