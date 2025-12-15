using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingListAW4E.Models
{
    public class Category : INotifyPropertyChanged
    {
        private string name;
        private bool isExpanded;

        public string Name
        {
            get => name;
            set { name = value; OnPropertyChanged(); }
        }

        public bool IsExpanded
        {
            get => isExpanded;
            set
            {
                isExpanded = value;
                OnPropertyChanged();
            }
        }

        public Category(string name)
        {
            Name = name;
        }

        public ObservableCollection<Product> Products { get; set; } = new();

        public event PropertyChangedEventHandler? PropertyChanged;
        void OnPropertyChanged([CallerMemberName] string name = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
