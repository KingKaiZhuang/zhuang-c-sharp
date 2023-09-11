//註解選定的程式碼：按下 Ctrl + K，然後再按下 Ctrl + C。
//取消註解選定的程式碼：按下 Ctrl + K，然後再按下 Ctrl + U。

using orderDrink;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace Test1
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Drink> drinks = new List<Drink>();
            List<OrderItem> orders = new List<OrderItem>();
            /*
                1. 創建一個 List 來儲存飲料
                2. 顯示每種飲料的資訊
                3. 訂購飲料
                4. 計算售價
            */
            drinkMenu(drinks);
            watchMenu(drinks);
            orderDrink(drinks, orders);
            CalculateAmount(orders);
        }

        private static void CalculateAmount(List<OrderItem> myOrders)
        {
            double total = 0.0;
            string message = "";
            double sellPrice = 0.0;
            
            foreach(OrderItem orderItem in myOrders)
            {
                total += orderItem.Subtotal;
            }

            if (total >= 500)
            {
                message = "訂單滿500元以上者8折";
                sellPrice = total * 0.8;
            }
            else if (total >= 300)
            {
                message = "訂單滿300元以上者85折";
                sellPrice = total * 0.85;
            }
            else if (total >= 200)
            {
                message = "訂單滿200元以上者9折";
                sellPrice = total * 0.9;
            }
            else
            {
                message = "訂單未滿200元不打折";
                sellPrice = total;
            }

            Console.WriteLine();
            Console.WriteLine($"您總共訂購了{myOrders.Count}個品項，總金額為{total}元，{message}");
            Console.WriteLine(message);
            Console.WriteLine($"折扣後金額為{sellPrice:C2}"); // C2 意思為 $
        }

        private static void orderDrink(List<Drink> myDrinks, List<OrderItem> myOrders)
        {
            Console.WriteLine();
            Console.WriteLine("請開始訂購飲料，按下x鍵離開。");
            string s;
            int Id, quantity, subtotal;
            while(true)
            {
                Console.Write("請輸入品名編號 ? ");
                s = Console.ReadLine();
                if (s == "x")
                {
                    Console.WriteLine("謝謝惠顧，歡迎下次再來!");
                    return;
                }
                else
                {
                    Id = Convert.ToInt32(s) - 1;
                }

                Console.Write("請輸入數量: ");
                s = Console.ReadLine();

                if (s == "x")
                {
                    Console.WriteLine("謝謝惠顧，歡迎下次再來!");
                    return;
                }
                else
                {
                    quantity = Convert.ToInt32(s);
                    subtotal = myDrinks[Id].Price * quantity;
                    Console.WriteLine($"您訂購{myDrinks[Id].Name}{myDrinks[Id].Size}{quantity}杯，每杯{myDrinks[Id].Price}元");
                    myOrders.Add(new OrderItem() { Id = Id, Quantity = quantity, Subtotal = subtotal });
                }
            }
        }

        private static void watchMenu(List<Drink> myDrinks)
        {
            Console.WriteLine("飲料清單\n");
            Console.WriteLine(String.Format("{0,-5}{1,-6}{2,-5}{3,-5}", "編號", "品名", "大小", "價格"));
            Console.WriteLine();
            int i = 0;
            foreach (var drink in myDrinks)
            {
                Console.WriteLine($"{i + 1,-7}{drink.Name,-6}{drink.Size,-5}{drink.Price,-5}");
                i++;
            }
        }

        private static void drinkMenu(List<Drink> myDrinks)
        {
            myDrinks.Add(new Drink() { Name = "紅茶", Size = "大杯", Price = 50 });
            myDrinks.Add(new Drink() { Name = "綠茶", Size = "中杯", Price = 45 });
            myDrinks.Add(new Drink() { Name = "咖啡", Size = "中杯", Price = 60 });
            myDrinks.Add(new Drink() { Name = "奶茶", Size = "小杯", Price = 40 });
            myDrinks.Add(new Drink() { Name = "可樂", Size = "大杯", Price = 55 });
        }
    }
}