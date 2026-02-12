using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PK_Bezieher
{
    internal class PreisBerechner 
    {
        public double KalkulationPreis(DateTime Eintritt, DateTime? Austritt, double PreisProMinute)

        {


            DateTime AustrittsZeit;

            if (Austritt != null)
            {
                AustrittsZeit = Austritt.Value;
            }

            else
            {
                AustrittsZeit = DateTime.Now;
            }


           

           TimeSpan Dauer = AustrittsZeit - Eintritt;

            Double AnzahlMinuten = Math.Ceiling(Dauer.TotalMinutes);

            double EndPreis = AnzahlMinuten * PreisProMinute;

            return EndPreis;


        }

        


    }
}
