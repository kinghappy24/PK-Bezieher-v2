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
