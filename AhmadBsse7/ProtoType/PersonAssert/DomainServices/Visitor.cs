using System;
namespace PersonAssert.DomainServices;


public interface IVisitor
{
	void Accept(Car car);
	void Accept(Bank bank);
	void Accept(RealAsset realAsset);
}



public class Visitor
{
	public Visitor()
	{
	}
}

