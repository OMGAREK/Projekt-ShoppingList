using ShoppingListAW4E.Models;
using System.Collections.ObjectModel;
using System.Text.Json;
using System.Windows.Input;

namespace ShoppingListAW4E.ViewModels;

public class CategoriesViewModel
{
    const string CategoryFile = "categories.json";
    const string ProductFile = "products.json";

    public ObservableCollection<Category> Categories { get; set; }

    public ICommand ToggleCategoryCommand { get; }
    public ICommand AddCategoryCommand { get; }

    public string NewCategoryName { get; set; }

    public CategoriesViewModel()
    {
        Categories = LoadCategories();

        if (Categories.Count == 0)
        {
            Categories.Add(new Category("Warzywa"));
            Categories.Add(new Category("Owoce"));
            Categories.Add(new Category("Nabiał"));
            Categories.Add(new Category("Chemia"));
            SaveCategories();
        }

        LoadProductsIntoCategories();

        ToggleCategoryCommand = new Command<Category>(c => c.IsExpanded = !c.IsExpanded);
        AddCategoryCommand = new Command(AddCategory);
    }

    void AddCategory()
    {
        if (string.IsNullOrWhiteSpace(NewCategoryName))
            return;

        Categories.Add(new Category(NewCategoryName));
        NewCategoryName = string.Empty;
        SaveCategories();
    }

    void LoadProductsIntoCategories()
    {
        string path = Path.Combine(FileSystem.AppDataDirectory, ProductFile);
        if (!File.Exists(path)) return;

        var products = JsonSerializer.Deserialize<ObservableCollection<Product>>(
            File.ReadAllText(path)) ?? new();

        foreach (var p in products)
        {
            var cat = Categories.FirstOrDefault(c => c.Name == p.CategoryName);
            cat?.Products.Add(p);
        }
    }

    ObservableCollection<Category> LoadCategories()
    {
        string path = Path.Combine(FileSystem.AppDataDirectory, CategoryFile);
        if (!File.Exists(path)) return new();
        return JsonSerializer.Deserialize<ObservableCollection<Category>>(
            File.ReadAllText(path)) ?? new();
    }

    void SaveCategories()
    {
        string path = Path.Combine(FileSystem.AppDataDirectory, CategoryFile);
        File.WriteAllText(path, JsonSerializer.Serialize(
            Categories, new JsonSerializerOptions { WriteIndented = true }));
    }
}
