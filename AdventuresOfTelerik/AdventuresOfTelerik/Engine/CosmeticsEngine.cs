using Cosmetics.Cart;
using Cosmetics.Core.Contracts;
using Cosmetics.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cosmetics.Core.Engine
{
    public sealed class CosmeticsEngine : IEngine
    {
        private const string InvalidCommand = "Invalid command name: {0}!";
        private const string CategoryExists = "Category with name {0} already exists!";
        private const string CategoryCreated = "Category with name {0} was created!";
        private const string CategoryDoesNotExist = "Category {0} does not exist!";
        private const string ProductDoesNotExist = "Product {0} does not exist!";
        private const string ProductAddedToCategory = "Product {0} added to category {1}!";
        private const string ProductRemovedCategory = "Product {0} removed from category {1}!";
        private const string ProductAlreadyExist = "Product with name {0} already exists!";
        private const string ProductCreated = "Product with name {0} was created!";
        private const string ProductAddedToShoppingCart = "Product {0} was added to the shopping cart!";
        private const string ProductDoesNotExistInShoppingCart = "Shopping cart does not contain product with name {0}!";
        private const string ProductRemovedFromShoppingCart = "Product {0} was removed from the shopping cart!";
        private const string TotalPriceInShoppingCart = "${0} total price currently in the shopping cart!";
        private const string InvalidGenderType = "Invalid gender type!";
        private const string InvalidUsageType = "Invalid usage type!";

        private static readonly CosmeticsEngine SingleInstance = new CosmeticsEngine();

        private readonly CosmeticsFactory factory;
        private readonly ShoppingCart shoppingCart;
        private readonly IDictionary<string, Category> categories;
        private readonly IDictionary<string, Product> products;

        private CosmeticsEngine()
        {
            this.factory = new CosmeticsFactory();
            this.shoppingCart = new ShoppingCart();
            this.categories = new Dictionary<string, Category>();
            this.products = new Dictionary<string, Product>();
        }

        public static CosmeticsEngine Instance
        {
            get
            {
                return SingleInstance;
            }
        }

        public void Start()
        {
            var commands = this.ReadCommands();
            var commandResult = this.ProcessCommands(commands);
            this.PrintReports(commandResult);
        }

        private IList<ICommand> ReadCommands()
        {
            var commands = new List<ICommand>();

            var currentLine = Console.ReadLine();

            while (!string.IsNullOrEmpty(currentLine))
            {
                var currentCommand = Command.Parse(currentLine);
                commands.Add(currentCommand);

                currentLine = Console.ReadLine();
            }

            return commands;
        }

        private IList<string> ProcessCommands(IList<ICommand> commands)
        {
            var reports = new List<string>();

            foreach (var command in commands)
            {
                try
                {
                    var report = this.ProcessSingleCommand(command);
                    reports.Add(report);
                }
                catch (Exception ex)
                {
                    reports.Add(ex.Message);
                }
            }

            return reports;
        }

        private string ProcessSingleCommand(ICommand command)
        {
            switch (command.Name)
            {
                case "CreateCategory":
                    var categoryName = command.Parameters[0];
                    return this.CreateCategory(categoryName);

                case "AddToCategory":
                    var categoryNameToAdd = command.Parameters[0];
                    var productToAdd = command.Parameters[1];
                    return this.AddToCategory(categoryNameToAdd, productToAdd);

                case "RemoveFromCategory":
                    var categoryNameToRemove = command.Parameters[0];
                    var productToRemove = command.Parameters[1];
                    return this.RemoveCategory(categoryNameToRemove, productToRemove);

                case "ShowCategory":
                    var categoryToShow = command.Parameters[0];
                    return this.ShowCategory(categoryToShow);

                case "CreateProduct":
                    var shampooName = command.Parameters[0];
                    var shampooBrand = command.Parameters[1];
                    var shampooPrice = decimal.Parse(command.Parameters[2]);
                    var shampooGender = command.Parameters[3];
                    return this.CreateProduct(shampooName, shampooBrand, shampooPrice, shampooGender);

                case "AddToShoppingCart":
                    var productToAddToCart = command.Parameters[0];
                    return this.AddToShoppingCart(productToAddToCart);

                case "RemoveFromShoppingCart":
                    var productToRemoveFromCart = command.Parameters[0];
                    return this.RemoveFromShoppingCart(productToRemoveFromCart);

                case "TotalPrice":
                    return this.shoppingCart.ProductList.Any() ? string.Format(TotalPriceInShoppingCart, this.shoppingCart.TotalPrice()) : $"No product in shopping cart!";

                default:
                    return string.Format(InvalidCommand, command.Name);
            }
        }

        private void PrintReports(IList<string> reports)
        {
            var output = new StringBuilder();

            foreach (var report in reports)
            {
                output.AppendLine(report);
            }

            Console.Write(output.ToString());
        }

        private string CreateCategory(string categoryName)
        {
            if (this.categories.ContainsKey(categoryName))
            {
                return string.Format(CategoryExists, categoryName);
            }

            var category = this.factory.CreateCategory(categoryName);
            this.categories.Add(categoryName, category);

            return string.Format(CategoryCreated, categoryName);
        }

        private string AddToCategory(string categoryNameToAdd, string productToAdd)
        {
            if (!this.categories.ContainsKey(categoryNameToAdd))
            {
                return string.Format(CategoryDoesNotExist, categoryNameToAdd);
            }

            if (!this.products.ContainsKey(productToAdd))
            {
                return string.Format(ProductDoesNotExist, productToAdd);
            }

            var category = this.categories[categoryNameToAdd];
            var product = this.products[productToAdd];

            category.AddProduct(product);

            return string.Format(ProductAddedToCategory, productToAdd, categoryNameToAdd);
        }

        private string RemoveCategory(string categoryNameToAdd, string productToRemove)
        {
            if (!this.categories.ContainsKey(categoryNameToAdd))
            {
                return string.Format(CategoryDoesNotExist, categoryNameToAdd);
            }

            if (!this.products.ContainsKey(productToRemove))
            {
                return string.Format(ProductDoesNotExist, productToRemove);
            }

            var category = this.categories[categoryNameToAdd];
            var product = this.products[productToRemove];

            category.RemoveProduct(product);

            return string.Format(ProductRemovedCategory, productToRemove, categoryNameToAdd);
        }

        private string ShowCategory(string categoryToShow)
        {
            if (!this.categories.ContainsKey(categoryToShow))
            {
                return string.Format(CategoryDoesNotExist, categoryToShow);
            }

            var category = this.categories[categoryToShow];

            return category.Print();
        }

        private string CreateProduct(string name, string brand, decimal price, string gender)
        {
            if (this.products.ContainsKey(name))
            {
                return string.Format(ProductAlreadyExist, name);
            }

            var shampoo = this.factory.CreateProduct(name, brand, price, gender);
            this.products.Add(name, shampoo);

            return string.Format(ProductCreated, name);
        }

        private string AddToShoppingCart(string productName)
        {
            if (!this.products.ContainsKey(productName))
            {
                return string.Format(ProductDoesNotExist, productName);
            }

            var product = this.products[productName];
            this.shoppingCart.AddProduct(product);

            return string.Format(ProductAddedToShoppingCart, productName);
        }

        private string RemoveFromShoppingCart(string productName)
        {
            if (!this.products.ContainsKey(productName))
            {
                return string.Format(ProductDoesNotExist, productName);
            }

            var product = this.products[productName];

            if (!this.shoppingCart.ContainsProduct(product))
            {
                return string.Format(ProductDoesNotExistInShoppingCart, productName);
            }

            this.shoppingCart.RemoveProduct(product);

            return string.Format(ProductRemovedFromShoppingCart, productName);
        }
    }
}
