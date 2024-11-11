using System;

public class Date
{
    private int year;
    private int month;
    private int day;
    public Date(int year, int month, int day)
    {
        this.year = year;
        this.month = month;
        this.day = day;
    }
    public bool IsValid()
    {
        // Перевірка валідності року місяця і дня
        if (year < 1 || month < 1 || month > 12 || day < 1)
            return false;
        // Кількість днів у кожному місяці
        int[] daysInMonth = { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
        // Перевірка на високосний рік
        if (IsLeapYear(year))
            daysInMonth[1] = 29;
        // Валідність дня в місяці
        return day <= daysInMonth[month - 1];
    }
    private bool IsLeapYear(int year)
    {
        return (year % 4 == 0 && year % 100 != 0) || (year % 400 == 0);
    }
    // Збільшення дати на 1 день
    public void Plus1()
    {
        int[] daysInMonth = { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
        if (IsLeapYear(year))
            daysInMonth[1] = 29;
        day++;
        if (day > daysInMonth[month - 1])
        {
            day = 1;
            month++;
            if (month > 12)
            {
                month = 1;
                year++;
            }
        }
    }
    // Виведення дати на екран
    public void Print()
    {
        Console.WriteLine($"{day:D2}/{month:D2}/{year}");
    }
}
class Program
{
    static void Main()
    {
        try
        {
            // Значення з клавіатури
            Console.Write("Enter year: ");
            int year = int.Parse(Console.ReadLine());
            Console.Write("Enter month: ");
            int month = int.Parse(Console.ReadLine());
            Console.Write("Enter day: ");
            int day = int.Parse(Console.ReadLine());
            Date date = new Date(year, month, day);
            date.Print();
            // Перевірка валідності дати
            if (date.IsValid())
            {
                // Збільшення дати на одну одиницю
                date.Plus1();
                // Виведення нової дати
                date.Print();
            }
            else
            {
                Console.WriteLine("The date is not valid.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }
}
