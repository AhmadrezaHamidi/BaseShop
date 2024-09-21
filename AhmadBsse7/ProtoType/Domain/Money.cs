using System;
namespace ProtoType.Domain;

public interface ICloneAble<T>
{
	T Clone();
}



public class Money : ICloneAble<Money> 
{
	public decimal Amounte { get;private set; }
	public decimal Curenvy { get;private set; }

    public Money Clone()=>this.MemberwiseClone() as Money;

    private Money(decimal amounte, decimal curenvy)
    {
        Amounte = amounte;
        Curenvy = curenvy;
    }

    public static Money CerateMoney(decimal amounte, decimal curenvy)
        => new Money(amounte, curenvy);


}

