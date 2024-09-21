using PersonAssert.DomainServices;

namespace PersonAssert;

public abstract class Asset
{
    public string OwnerId { get; set; }
    public  abstract void  AcceptVisitor(IVisitor visitor);

}

