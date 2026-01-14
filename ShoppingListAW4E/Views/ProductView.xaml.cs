using ShoppingListAW4E.Models;
using System;
using Microsoft.Maui.Controls;

namespace ShoppingListAW4E.Views
{
    public partial class ProductView : ContentView
    {
        public ProductView()
        {
            InitializeComponent();
        }

        void OnDecreaseClicked(object sender, EventArgs e)
        {
            if (BindingContext is Product product && product.Quantity >0)
            {
                product.Quantity--;
                ShoppingListPage? page = FindShoppingListPage();
                page?.SaveProducts();
            }
        }

        void OnIncreaseClicked(object sender, EventArgs e)
        {
            if (BindingContext is Product product)
            {
                product.Quantity++;
                ShoppingListPage? page = FindShoppingListPage();
                page?.SaveProducts();
            }
        }

        ShoppingListPage? FindShoppingListPage()
        {
            Element element = this;
            while (element != null)
            {
                if (element is ShoppingListPage page)
                    return page;
                element = element.Parent;
            }

            return null;
        }

        void OnBoughtClicked(object sender, EventArgs e)
        {
            if (BindingContext is not Product product)
                return;

            ShoppingListPage? page = FindShoppingListPage();
            page?.ToggleBought(product);
        }

        void OnRemoveClicked(object sender, EventArgs e)
        {
            if (BindingContext is not Product product)
                return;

            ShoppingListPage? page = FindShoppingListPage();
            page?.RemoveProduct(product);
        }
    }
}
