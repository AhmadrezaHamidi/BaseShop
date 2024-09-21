using System;
namespace IVendingMachineState.Domain;

// اینترفیس State (وضعیت)
public interface IVendingMachineState
{
    void InsertCoin();
    void Dispense();
}

// حالت Ready (حالت آماده)
public class ReadyState : IVendingMachineState
{
    public void InsertCoin()
    {
        Console.WriteLine("Coin inserted. Machine is ready to dispense.");
    }

    public void Dispense()
    {
        Console.WriteLine("Please insert a coin first.");
    }
}

// حالت Dispensing (حالت فروش)
public class DispensingState : IVendingMachineState
{
    public void InsertCoin()
    {
        Console.WriteLine("Already dispensing. Please wait.");
    }

    public void Dispense()
    {
        Console.WriteLine("Product dispensed.");
    }
}

// ماشین فروش خودکار که حالت‌های مختلف دارد
public class VendingMachine
{
    private IVendingMachineState state;

    public VendingMachine()
    {
        state = new ReadyState(); // در حالت آماده شروع می‌شود
    }

    public void SetState(IVendingMachineState newState)
    {
        state = newState;
    }

    public void InsertCoin()
    {
        state.InsertCoin();
        SetState(new DispensingState()); // بعد از وارد کردن سکه به حالت فروش می‌رویم
    }

    public void Dispense()
    {
        state.Dispense();
        SetState(new ReadyState()); // بعد از فروش محصول به حالت آماده برمی‌گردیم
    }
}

// استفاده از الگوی State
// خروجی: Product dispensed.

