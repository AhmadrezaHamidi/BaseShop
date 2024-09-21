// See https://aka.ms/new-console-template for more information
using SmapleBuilder.Domain;

Console.WriteLine("Hello, World!");
var builder = new UrlBuilder().WitheHost("LoaclHost").WithePort("1433").WitheReasource("Vali")
    .WitheProtocol("https").Build();
