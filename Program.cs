﻿// See https://aka.ms/new-console-template for more information
using Labb_1___LINQ.Controller;
using Labb_1___LINQ.utils;

Seed seed = new Seed();
seed.SeedDataV3();


// // Menu
// var menu = new Menu(["Show produkts", "Show supplier with less 10 units", "Get curent order", "Get top 3 produkt", "Get all catogorys", "Get all order ditails", "exit"]);

// var menuRuning = true;

// while (menuRuning)
// {
//     var curentMenu = menu.Show();
//     switch (curentMenu)
//     {
//         case 0:
//             ProductController.Index("Electronics");
//             break;
//         case 1:
//             SupplierController.Index();
//             break;
//         case 2:
//             OrderController.GetTotalOrderValue();
//             break;
//         case 3:
//             OrderController.GetTopProduct(3);
//             break;
//         case 4:
//             CategoryController.GetCategory();
//             break;
//         case 5:
//             OrderController.GatAllOrdersDitails();
//             break;
//         case 6:
//             menuRuning = false;
//             break;
//         default:
//             menuRuning = false;
//             break;
//     }
// }