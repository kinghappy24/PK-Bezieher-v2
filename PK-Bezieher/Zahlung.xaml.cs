using System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace PK_Bezieher
{
    public partial class Zahlung : ContentPage
    {
        private PH_Logik Logik = new PH_Logik();

        public Zahlung()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing(); // beim click aktualisierend

            var ticket = PH_Logik.GezogenerTicket;

            if (ticket == null)
            {
                Details.Text = "ziehe zuerst einmal ein Ticket .";
                Total.Text = "";
                Ergebnis.Text = "";
                return;
            }

                    Details.Text =
                        $"ID: {ticket.Id}\n" +
                        $"Eintritt: {ticket.Eintritt:dd.MM.yyyy HH:mm:ss}\n" +
                        $"Bezahlt: {ticket.Bezahlt}";

                    double preis = Logik.LivePreis(ticket);
                    Total.Text = $"Jetztiger Preis: {preis:0.00} CHF";

                    Ergebnis.Text = "";
        }

        private async void Bezahlen_Clicked(object sender, EventArgs e)
        {
            var ticket = PH_Logik.GezogenerTicket;

            if (ticket == null) // besitzt user ein ticket?
            {
                Ergebnis.Text = "Du hast kein Ticket.";
                return;
            }

                if (ticket.Bezahlt) // falls user versucht zu bezahlen obwohl bereits bezahlt.
                {
                    Ergebnis.Text = "Du hast schon bezahlt.";
                    return;
                }

            Logik.Bezahlen(ticket);

            double preis = Logik.LivePreis(ticket);

            Details.Text =
                $"ID: {ticket.Id}\n" +
                $"Eintritt: {ticket.Eintritt:dd.MM.yyyy HH:mm:ss}\n" +
                $"Austritt: {ticket.Austritt:dd.MM.yyyy HH:mm:ss}\n" +
                $"Bezahlt: {ticket.Bezahlt}";

            Total.Text = $"Endpreis: {preis:0.00} CHF";
            Ergebnis.Text = "Bezahlt.";
        }
    }
}
