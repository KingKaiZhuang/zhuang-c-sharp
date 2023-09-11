using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    class Program
    {
        static void Main()
        {
            // 創建一個 List 來儲存飲料
            List<Drink> drinks = new List<Drink>();

            AddNewDrink(drinks);

            // 顯示每種飲料的資訊
            DisPlayDrinkMenu(drinks);
        }

        private static void DisPlayDrinkMenu(List<Drink> drinks)
        {
            Console.WriteLine("品名     容量     價格");
            foreach (var drink in drinks)
            {
                Console.WriteLine($"飲料名稱: {drink.Name,-5} 尺寸: {drink.Size,-5} 價格: {drink.Price,-5}");
            }
        }

        private static void AddNewDrink(List<Drink> drinks)
        {
            drinks.Add(new Drink() { Name = "紅茶", Size = "大杯", Price = 50 });
            drinks.Add(new Drink() { Name = "綠茶", Size = "中杯", Price = 45 });
            drinks.Add(new Drink() { Name = "咖啡", Size = "中杯", Price = 60 });
            drinks.Add(new Drink() { Name = "柳橙汁", Size = "小杯", Price = 40 });
            drinks.Add(new Drink() { Name = "可樂", Size = "大杯", Price = 55 });
        }
    }

}
