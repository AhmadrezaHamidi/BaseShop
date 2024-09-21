using AhmadShop.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AhmadShop.Domain.Entities;

public class Customer : Entity
{
    public Customer(Guid id) : base(id) { }

    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
    public string Address { get; set; }

    public List<Order> PurchaseHistory { get; set; } = new List<Order>();
}

