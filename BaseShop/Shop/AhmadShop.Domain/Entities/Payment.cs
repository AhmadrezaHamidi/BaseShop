using AhmadShop.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AhmadShop.Domain.Entities;

public class Payment : Entity
{
    public Payment(Guid id) : base(id) { }

    public Guid OrderId { get; set; }
    public Order Order { get; set; }

    public string PaymentMethod { get; set; }
    public DateTime PaymentDate { get; set; }
    public decimal AmountPaid { get; set; }
    public string TransactionId { get; set; }
    public string PaymentStatus { get; set; }
}
