using System;
namespace Domain;

public class CustomException : Exception
{
    // سازنده‌ی پیش‌فرض
    public CustomException() : base("An error occurred in the application.")
    {
    }

    // سازنده‌ای که پیام خاصی را می‌پذیرد
    public CustomException(string message) : base(message)
    {
    }

    // سازنده‌ای که پیام و علت (Exception داخلی) را می‌پذیرد
    public CustomException(string message, Exception innerException)
        : base(message, innerException)
    {
    }

    // سازنده‌ای برای پشتیبانی از Serialization (جهت انتقال از طریق شبکه)
    protected CustomException(System.Runtime.Serialization.SerializationInfo info,
        System.Runtime.Serialization.StreamingContext context)
        : base(info, context)
    {
    }
}

