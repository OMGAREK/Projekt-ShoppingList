using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text.Json.Serialization;
using System.Windows.Input;

namespace ShoppingListAW4E.Models
{
    public class Product : INotifyPropertyChanged
    {
        private int quantity;
        private bool isBought;

        public string Name { get; set; }
        public string Unit { get; set; }
        public string CategoryName { get; set; }

        public int Quantity
        {
            get => quantity;
            set { quantity = value; OnPropertyChanged(); }
        }

        public bool IsBought
        {
            get => isBought;
            set { isBought = value; OnPropertyChanged(); }
        }

        [JsonIgnore] public ICommand IncreaseCommand { get; set; }
        [JsonIgnore] public ICommand DecreaseCommand { get; set; }

        public Product()
        {
            InitializeCommands();
        }

        public void InitializeCommands()
        {
            IncreaseCommand = new Command(() => Quantity++);
            DecreaseCommand = new Command(() =>
            {
                if (Quantity > 0)
                    Quantity--;
            });
        }


        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string n = "")
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(n));
    }
}
