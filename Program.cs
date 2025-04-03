// See https://aka.ms/new-console-template for more information
using Labb_1___LINQ.utils;


// Menu
var menu = new Menu(["exit", "wowo"]);

var curentMenu = menu.Show();
var menuRuning = true;

while (menuRuning)
{
    switch (curentMenu)
    {
        case 1:
            menuRuning = false;
            break;
        default:
            menuRuning = false;
            break;
    }
}