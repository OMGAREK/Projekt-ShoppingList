namespace ShoppingListAW4E
{
    // MainPage to przykładowa strona utworzona domyślnie przez projekt.
    // Zawiera prosty licznik służący do demonstracji działania przycisków i UI.
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        // Metoda wywoływana po kliknięciu przycisku z licznikiem.
        // Zwiększa licznik i aktualizuje tekst przycisku.
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
