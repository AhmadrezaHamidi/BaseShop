using System;
using System.Runtime.ConstrainedExecution;

namespace PersonAssert.DomainServices;

public class MontlyIncomeTaxCalculator : IVisitor
{
    private long MontlyInComeTax;

    public void Accept(Car car)
    {
      this.MontlyInComeTax += car.MontlyTax;
    }

    public void Accept(Bank bank)
    {
        this.MontlyInComeTax += 0;
    }

    public void Accept(RealAsset realAsset)
    {
        this.MontlyInComeTax += realAsset.MontlyTax;
    }

    public long InCome() => MontlyInComeTax;

}

