using PersonAssert.DomainServices;

namespace PersonAssert;

public class RealAsset : Asset
{
    public RealAsset(long price, long montlyTax, long rentTax)
    {
        Price = price;
        MontlyTax = montlyTax;
        RentTax = rentTax;
    }

    public long Price { get; set; }
    public long MontlyTax { get; set; }
    public long RentTax { get; set; }

    public override void AcceptVisitor(IVisitor visitor)
    {
        visitor.Accept(this);
    }

}

