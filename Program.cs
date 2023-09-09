using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Hello, World!");

        int score = 85;
        if (score >= 60)
        {
            Console.WriteLine("及格了！");
        }
        else
        {
            Console.WriteLine("不及格！");
        }

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
