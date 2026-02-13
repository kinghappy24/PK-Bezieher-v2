using PK_Bezieher.Logik;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PK_Bezieher
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        private PH_Logik Logik = new PH_Logik();
        private Tickets GezogenerTicket;


        public async void TicketZiehen_Clicked(object sender ,EventArgs e)
        {
            Logik.TicketZiehen();

            await Navigation.PushAsync(new Tickets_Ansicht());


        }

        
    }

}
