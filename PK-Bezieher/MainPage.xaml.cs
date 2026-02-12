namespace PK_Bezieher
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        public PH_Logik Logik = new PH_Logik();
        public Tickets GezogenerTicket;


        public async void TicketZiehen_Clicked(object sender ,EventArgs e)
        {
            Tickets ticket = new Tickets();
            ticket.Id = Guid.NewGuid();
            ticket.Eintritt = DateTime.Now;
            ticket.Bezhalt = false;

            await DisplayAlert(
                "Ticket",
                " sie haben Ihr Ticket gezogen am " + ticket.Eintritt + "Eingetretten",
                "danke"
                );


        }

        private void OnCounterClicked(object sender, EventArgs e)
        {
            count++;

            if (count == 1)
                CounterBtn.Text = $"Clicked {count} time";
            else
                CounterBtn.Text = $"Clicked {count} times";

            SemanticScreenReader.Announce(CounterBtn.Text);
        }
    }

}
