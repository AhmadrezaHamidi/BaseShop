using AhmadShop.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AhmadShop.Domain.Entities;

public class Product : Entity
{
    public Product(Guid id) : base(id) { }

    public string Name { get; set; }
    public string Model { get; set; }
    public string Brand { get; set; }
    public decimal Price { get; set; }
    public string Description { get; set; }
    public int StockQuantity { get; set; }
    public string Category { get; set; }
}
