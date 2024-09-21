using PersonAssert.DomainServices;

namespace PersonAssert;

public class Car : Asset
{
    public Car(long balance, long montlyTax, long rentlrTax)
    {
        Balance = balance;
        MontlyTax = montlyTax;
        RentlrTax = rentlrTax;
    }

    public long Balance { get; set; }
    public long MontlyTax { get; set; }
    public long RentlrTax { get; set; }
    public override void AcceptVisitor(IVisitor visitor)
    {
        visitor.Accept(this);
    }
}

