using AhmadShop.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AhmadShop.Domain.Entities;

public class Order : Entity
{
    public Order(Guid id) : base(id) { }

    public DateTime OrderDate { get; set; }

    // Relationships
    public Guid CustomerId { get; set; }
    public Customer Customer { get; set; }
    public Guid SalespersonId { get; set; }
    public Guid ProductId { get; set; }
    public Product Product { get; set; }

    public int Quantity { get; set; }
    public decimal TotalAmount { get; set; }
    public string PaymentStatus { get; set; }
    public DateTime? DeliveryDate { get; set; }
}
