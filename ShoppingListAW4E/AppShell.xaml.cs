using ShoppingListAW4E.Views;

namespace ShoppingListAW4E
{
    // AppShell to klasa powiązana z AppShell.xaml. Tworzy strukturę nawigacji
    // i inicjalizuje ją. W prostych aplikacjach, takich jak ta, nie musimy dodawać
    // dodatkowej logiki w code-behind, ale ten plik pozostaje miejscem, gdzie
    // można dodać obsługę zdarzeń globalnej nawigacji.
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
        }
    }
}
