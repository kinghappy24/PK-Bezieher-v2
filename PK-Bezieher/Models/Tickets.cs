using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PK_Bezieher.Logik
{
    internal class Tickets
    {

        public Guid Id { get; set; }

        public double preis {  get; set; }
        public DateTime Eintritt { get; set; }
        public DateTime? Austritt { get; set; }

        public bool Bezahlt { get; set; }


        


        



    }
}
