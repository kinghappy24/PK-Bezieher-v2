using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PK_Bezieher
{

    public partial class Tickets_Ansicht : ContentPage
    {
        public Tickets_Ansicht()
        {
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            DauerRefresh();
        }

        private PH_Logik Logik = new PH_Logik();

        private void DauerRefresh()
        {
            var ticket = PH_Logik.GezogenerTicket;

            if (ticket == null) // check / meldung wenn user kein ticket hat.
            {
                Meldung.Text = "Du musst zuerst ein Ticket Ziehen"; 
                Dauer.Text = "";
                Preis.Text = "";
                return;
            }

       

            
            Meldung.Text =
                $"ID: {ticket.Id}\n" +
                $"Eintritt: {ticket.Eintritt:dd.MM.yyyy HH:mm:ss}\n" +
                $"Bezahlt: {ticket.Bezahlt}";

            
            TimeSpan dauer = DateTime.Now - ticket.Eintritt;
            if (dauer.TotalSeconds < 0)
                dauer = TimeSpan.Zero;

            Dauer.Text = $"Dauer: {dauer:hh\\:mm\\:ss}"; // übersichtlichkeit ( daten format ( lese dokuementation )

            
            double preis = Logik.LivePreis(ticket);
            Preis.Text = $"Preis: {preis:0.00} CHF";
        }

        private void Refresh_Clicked(object sender, EventArgs e)
        {
            DauerRefresh();
        }

        private async void Bezahlen_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Zahlung());
        }


    }

}