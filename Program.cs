using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Hello, World!");

        // 正確的初始化Person物件
        Person person1 = new Person();
        person1.Name = "Alice";
        person1.Age = 25;
    }
}

class Person
{
    public string Name;
    public int Age;
}
