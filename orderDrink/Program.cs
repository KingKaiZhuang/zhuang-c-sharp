using orderDrink;
using System;

namespace orderDrink
{
    class Program
    {
        static void Main(string[] args)
        {
            List<drink> drinks = new List<drink>();
            List<order> orders = new List<order>();
            menuCreate(drinks);
            menuPrint(drinks);
            menuPost(drinks, orders);
            menuCount(orders);
        }

        private static void menuCount(List<order> orders)
        {
            double total = 0.0;
            string message = "";
            double sellPrice = 0.0;

            foreach (order order in orders)
            {
                total += order.subtotal;
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
            Console.WriteLine($"折扣後金額為{sellPrice:C2}"); // C2 意思為 $
        }

        private static void menuPost(List<drink> drinks, List<order> orders)
        {
            int idpoint, id, quantity, subtotal;
            string s;
            while (true)
            {
                Console.WriteLine("請輸入編號:");
                s = Console.ReadLine();
                if (s == "x")
                {
                    Console.WriteLine("歡迎再光臨!");
                    return;
                }
                id = Convert.ToInt32(s);
                if (id < 0 || id >= drinks.Count)
                {
                    Console.WriteLine("請輸入正確編號!");
                    Console.WriteLine("-----------------------------------------------------");
                    continue; // 回到迴圈的開始
                }
                else
                {
                    id = Convert.ToInt32(s);
                }



                Console.WriteLine("請輸入數量");
                s = Console.ReadLine();
                if (s == "x")
                {
                    Console.WriteLine("歡迎再光臨!");
                    return;
                }
                else
                {
                    quantity = Convert.ToInt32(s);
                    subtotal = quantity * drinks[id].price;
                    Console.WriteLine($"您購買了{drinks[id].name}，{quantity}杯，一杯{drinks[id].price}元!");
                    orders.Add(new order { id = id, quantity = quantity, subtotal = subtotal });
                    Console.WriteLine("-----------------------------------------------------");
                }
            }
        }

        private static void menuPrint(List<drink> drinks)
        {
            Console.WriteLine("以下是我們的飲料菜單哦~");
            Console.WriteLine("{0,-5}{1,-7}{2,-5}{3,-5}", "編號", "名稱", "大小", "價錢");
            Console.WriteLine("-----------------------------------------------------");
            int i = 0;
            foreach (drink drink in drinks)
            {
                Console.WriteLine($"{i,-7}{drink.name,-7}{drink.size,-5}{drink.price,-5}");
                Console.WriteLine("-----------------------------------------------------");
                i++;
            }
        }

        private static void menuCreate(List<drink> myDrinkArr)
        {
            myDrinkArr.Add(new drink() { name = "咖啡", size = "大杯", price = 60 });
            myDrinkArr.Add(new drink() { name = "咖啡", size = "中杯", price = 50 });
            myDrinkArr.Add(new drink() { name = "紅茶", size = "大杯", price = 30 });
            myDrinkArr.Add(new drink() { name = "紅茶", size = "中杯", price = 20 });
            myDrinkArr.Add(new drink() { name = "綠茶", size = "大杯", price = 25 });
            myDrinkArr.Add(new drink() { name = "綠茶", size = "中杯", price = 20 });
        }
    }
}