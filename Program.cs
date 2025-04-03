// See https://aka.ms/new-console-template for more information
using Labb_1___LINQ.Controller;
using Labb_1___LINQ.utils;


// Menu
var menu = new Menu(["Show produkts", "Show supplier with less 10 units", "exit"]);

var menuRuning = true;

while (menuRuning)
{
    var curentMenu = menu.Show();
    switch (curentMenu)
    {
        case 0:
            ProductComponent.Index("Electronics");
            break;
        case 1:
            SupplierComponent.Index();
            break;
        case 2:
            menuRuning = false;
            break;
        default:
            menuRuning = false;
            break;
    }
}