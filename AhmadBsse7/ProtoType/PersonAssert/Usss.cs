using System;
using PersonAssert.DomainServices;

namespace PersonAssert
{
	public class Usss
	{
		List<Asset> assets = new List<Asset>()
		{
			new Bank(200,200,200),
			new Car(200,200,200),
			new RealAsset(200,200,200),
		};


		public long Do()
		{
			MontlyIncomeTaxCalculator montlyIncomeTax = new MontlyIncomeTaxCalculator();
			assets.ForEach(a => a.AcceptVisitor(montlyIncomeTax));
			return montlyIncomeTax.InCome();
        }
    }
}

