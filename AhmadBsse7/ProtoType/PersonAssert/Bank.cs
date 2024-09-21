using PersonAssert.DomainServices;

namespace PersonAssert;

public class Bank : Asset
{
    public Bank(long income, long montlyInsert, long loan)
    {
        Income = income;
        MontlyInsert = montlyInsert;
        this.loan = loan;
    }

    public long  Income { get; set; }
    public long  MontlyInsert  { get; set; }
    public long  loan { get; set; }

    public override void AcceptVisitor(IVisitor visitor)
    {
        //Duble-DisPaching 
        visitor.Accept(this);
    }
}

