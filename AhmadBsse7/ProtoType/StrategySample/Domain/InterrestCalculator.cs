using System;
namespace StrategySample.Domain;

public interface InterestCalculator
{
	long Calculaotr();
}

public class MangersInterestCalculator : InterestCalculator
{
    public long Calculaotr()
    {
        return 0;
    }
}

public class EmployeesIntersrestCalculator : InterestCalculator
{
    public long Calculaotr()
    {
        return 1;
    }
}


