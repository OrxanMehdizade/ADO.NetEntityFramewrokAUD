using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO.NetEntityFramewrokAUD
{
    public class Cars
    {
        public int Id { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string Year { get; set; }
        public string StNumber { get; set; }
        public override string ToString() => $"ID-> {Id}\n" +
            $"Make-> {Make}\n" +
            $"Model-> {Model}\n" +
            $"Year-> {Year}\n" +
            $"St.Number-> {StNumber}\n";
    }
}
