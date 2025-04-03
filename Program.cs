// See https://aka.ms/new-console-template for more information
using Labb_1___LINQ.Components;
using Labb_1___LINQ.utils;


// Menu
var menu = new Menu(["Show produkts", "exit"]);

var menuRuning = true;

while (menuRuning)
{
    var curentMenu = menu.Show();
    switch (curentMenu)
    {
        case 0:
            Product.Index("Electronics");
            break;
        case 1:
            menuRuning = false;
            break;
        default:
            menuRuning = false;
            break;
    }
}