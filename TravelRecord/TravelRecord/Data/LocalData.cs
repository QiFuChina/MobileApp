using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelRecord.Data
{
    public class Event
    {
        public int ID { get; set; }
        public String Title { get; set; }
        public String Date { get; set; }
        public String Introduction { get; set; }
    }

    public class LocalData
    {
        public static String Name = "LocalData Service.";
        public static List<Event> GetEvent()
        {
            return new List<Event>()
            {
                new Event()
                {
                    ID=1,Title="A",Date="B",Introduction="C"
                },
                new Event()
                {
                    ID=2,Title="D",Date="E",Introduction="F"
                },
                new Event()
                {
                    ID=3,Title="G",Date="H",Introduction="I"
                },
            };
        }
    }
}
