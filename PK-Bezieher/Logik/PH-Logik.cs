using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PK_Bezieher.Logik

{
    internal class PH_Logik
    {
        public static Tickets? GezogenerTicket;
        public Tickets TicketZiehen()
        {
            Tickets ticket = new Tickets();
            ticket.Id = Guid.NewGuid();
            ticket.Eintritt = DateTime.Now;
            ticket.Bezahlt = false;
            GezogenerTicket = ticket;

            return ticket;
        }
        

        
            public double LivePreis(Tickets ticket) // aktuellen preis berechnen 
        {
            Tariff tariff = new Tariff();
                PreisBerechner Kalkulation = new PreisBerechner();

            return Kalkulation.KalkulationPreis(
                ticket.Eintritt,
                ticket.Austritt,
                tariff.PreisProMinute

                );
        }


        public void Bezahlen(Tickets ticket)
        { 
            ticket.Austritt = DateTime.Now;
            ticket.Bezahlt = true;
            // damit der Timer wieder auf 0 zuruck Khert
            GezogenerTicket = null;

        }

    }
}
