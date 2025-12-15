using ShoppingListAW4E.Models;
using System.Collections.ObjectModel;
using System.Text.Json;
using System.Windows.Input;

namespace ShoppingListAW4E.ViewModels
{
    public class ShoppingListViewModel
    {
        private const string ProductFile = "products.json";
        private const string CategoryFile = "categories.json";

        public ObservableCollection<Product> Products { get; set; }
        public ObservableCollection<Category> Categories { get; set; }

        public string NewProductName { get; set; }
        public string NewProductUnit { get; set; }
        public int NewProductQuantity { get; set; } = 1;

        public Category SelectedCategory { get; set; }

        public ICommand AddProductCommand { get; }
        public ICommand RemoveProductCommand { get; }
        public ICommand ToggleBoughtCommand { get; }

        public ShoppingListViewModel()
        {
            Categories = LoadCategories();
            Products = LoadProducts();

            AddProductCommand = new Command(AddProduct);
            RemoveProductCommand = new Command<Product>(RemoveProduct);
            ToggleBoughtCommand = new Command<Product>(ToggleBought);
        }

        private void AddProduct()
        {
            if (string.IsNullOrWhiteSpace(NewProductName) ||
                string.IsNullOrWhiteSpace(NewProductUnit) ||
                SelectedCategory == null)
                return;

            Products.Add(new Product
            {
                Name = NewProductName,
                Unit = NewProductUnit,
                Quantity = NewProductQuantity,
                CategoryName = SelectedCategory.Name
            });

            SaveProducts();
        }

        private void RemoveProduct(Product product)
        {
            Products.Remove(product);
            SaveProducts();
        }

        private void ToggleBought(Product product)
        {
            product.IsBought = !product.IsBought;

            Products.Remove(product);
            Products.Add(product);

            SaveProducts();
        }

        private ObservableCollection<Product> LoadProducts()
        {
            string path = Path.Combine(FileSystem.AppDataDirectory, ProductFile);
            if (!File.Exists(path)) return new();

            var products = JsonSerializer.Deserialize<ObservableCollection<Product>>(
                File.ReadAllText(path)) ?? new();

            foreach (var p in products)
            {
                p.InitializeCommands();
            }

            return products;
        }


        private ObservableCollection<Category> LoadCategories()
        {
            string path = Path.Combine(FileSystem.AppDataDirectory, CategoryFile);
            if (!File.Exists(path)) return new();
            return JsonSerializer.Deserialize<ObservableCollection<Category>>(File.ReadAllText(path)) ?? new();
        }

        private void SaveProducts()
        {
            string path = Path.Combine(FileSystem.AppDataDirectory, ProductFile);
            File.WriteAllText(path, JsonSerializer.Serialize(Products, new JsonSerializerOptions { WriteIndented = true }));
        }
    }
}
