using System;
using System.Collections.Generic;
using zhuang_c_sharp;

namespace ConsoleApp1
{
    class Program
    {
        static void Main()
        {
            // 創建一個 List 來儲存飲料
            List<Drink> drinks = new List<Drink>();
            List<OrderItem> orders = new List<OrderItem>();
            AddNewDrink(drinks);

            // 顯示每種飲料的資訊
            DisPlayDrinkMenu(drinks);
            // 訂購飲料
            OrderDrink(drinks, orders);
            // 計算售價
            CalculateAmount(orders);
        }

        private static void CalculateAmount(List<OrderItem> orders)
        {
            double total = 0.0;
            string message = "";
            double sellPrice = 0.0;

            foreach (OrderItem orderItem in orders)
            {
                total += orderItem.subtotal;
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
            Console.WriteLine($"您總共訂購了{orders.Count}個品項，總金額為{total}元，{message}");
            Console.WriteLine(message);
            Console.WriteLine($"折扣後金額為{sellPrice:C2}");
        }


        private static void OrderDrink(List<Drink> myDrinks, List<OrderItem> myOrders)
        {
            Console.WriteLine();
            Console.WriteLine("請開始訂購飲料，按下x鍵離開。");
            string s;
            int index, quantity, subtotal;
            while (true)
            {
                Console.Write("請輸入品名編號 ? ");
                s = Console.ReadLine();
                if (s == "x")
                {
                    Console.WriteLine("謝謝惠顧，歡迎下次再來!");
                    break;
                }
                else
                {
                    index = Convert.ToInt32(s);
                }

                Console.Write("請輸入數量: ");
                s = Console.ReadLine();
                if (s == "x")
                {
                    Console.WriteLine("謝謝惠顧，歡迎下次再來!");
                    break;
                }
                else
                {
                    quantity = Convert.ToInt32(s);
                    subtotal = myDrinks[index].Price * quantity;
                    Console.WriteLine($"您訂購{myDrinks[index].Name}{myDrinks[index].Size}{quantity}杯，每杯{myDrinks[index].Price}元");
                    myOrders.Add(new OrderItem { Index = index, Quantity = quantity, subtotal = subtotal });
                }
            }
        }

        private static void DisPlayDrinkMenu(List<Drink> drinks)
        {
            Console.WriteLine("飲料清單\n");
            Console.WriteLine(String.Format("{0,-3} {1,-8} {2,-5} {3,5}", "編號", "品名", "大小", "價格"));
            int i = 0;
            foreach (var drink in drinks)
            {
                Console.WriteLine($"{i,-5} {drink.Name,-8} {drink.Size,-5} {drink.Price,5:C1}");
                i++;
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
