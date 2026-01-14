namespace ShoppingListAW4E
{
    // App.xaml.cs jest punktem startowym aplikacji.
    // Wyjaśnienie prosto:
    // - Gdy aplikacja uruchamia się, tworzony jest obiekt App.
    // - W konstruktorze przypisujemy stronę główną (MainPage), która jest pierwszą
    // rzeczą, jaką zobaczy użytkownik. Tutaj ustawiamy ją na AppShell, czyli
    // naszą główną strukturę nawigacji.
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
        }
    }
}
