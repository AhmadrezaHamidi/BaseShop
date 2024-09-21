// See https://aka.ms/new-console-template for more information
using FlyWeight.Entity;

Console.WriteLine("Hello, World!");

var factory = new SoldierFactory();

var soldier1 = factory.GetSoldier("Red");
var soldier2 = factory.GetSoldier("Blue");
var soldier3 = factory.GetSoldier("Red"); // استفاده مجدد از سرباز با رنگ قرمز

soldier1.Report(10, 20);
soldier2.Report(30, 40);
soldier3.Report(50, 60);