using System;
namespace FlyWeight.Entity;

public class Soldier
{
//    1. Flyweight Pattern(الگوی سبک‌وزن)
//الگوی Flyweight برای بهینه‌سازی استفاده از حافظه زمانی که تعداد زیادی شیء مشابه داریم، استفاده می‌شود.هدف این الگو این است که اشیاء یکسان را به اشتراک بگذارد و از ایجاد چندین نسخه از آن‌ها جلوگیری کند. به عبارت دیگر، این الگو اجازه می‌دهد که حالت‌های مشترک اشیاء را ذخیره کرده و از آن‌ها در چندین شیء استفاده کنیم.

//زمانی که باید از Flyweight استفاده کنیم:
//وقتی تعداد زیادی شیء مشابه دارید که استفاده از حافظه را زیاد می‌کند.
//وقتی بخشی از شیء قابل اشتراک‌گذاری و استفاده‌ی مجدد بین اشیاء مختلف است.


    private string uniformColor; // رنگ لباس که مشترک است (Flyweight)

    public Soldier(string uniformColor)
    {
        this.uniformColor = uniformColor;
    }

    public void Report(int x, int y) // موقعیت سرباز
    {
        Console.WriteLine($"Soldier with {uniformColor} uniform at position ({x}, {y})");
    }
}


public class SoldierFactory
{
    private Dictionary<string, Soldier> soldiers = new Dictionary<string, Soldier>();

    public Soldier GetSoldier(string uniformColor)
    {
        if (!soldiers.ContainsKey(uniformColor))
        {
            soldiers[uniformColor] = new Soldier(uniformColor);
        }

        return soldiers[uniformColor];
    }
}


