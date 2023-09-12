
namespace orderPractice
{
    class Program
    {
        static void Main(string[] args)
        {
            // 列出飲料清單
            // 輸出飲料清單
            // 新增飲料清單
            // 計算打折後價錢
            List<drinks> drinkArr = new List<drinks>();
            List<order> orderArr = new List<order>();
            drinkMenu(drinkArr);
            drinkMenuPrint(drinkArr);
            drinkMenuPost(drinkArr, orderArr);
            drinkCalculate(orderArr);
        }

        private static void drinkCalculate(List<order> orderArr)
        {
            double total = 0.0;
            string message = "";
            double sellPrice = 0.0;

            foreach (order orderItem in orderArr)
            {
                total += orderItem.total;
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
            Console.WriteLine($"您總共訂購了{orderArr.Count}個品項，總金額為{total}元，{message}");
            Console.WriteLine(message);
            Console.WriteLine($"折扣後金額為{sellPrice:C2}"); // C2 意思為 $
        }

        private static void drinkMenuPost(List<drinks> drinkArr, List<order> orderArr)
        {
            string number;
            int quantity,Id = 0,total;
            while (true)
            {
                Console.WriteLine("請輸入飲料編號:");
                number = Console.ReadLine();
                if (number == "x")
                {
                    Console.WriteLine("謝謝光臨~");
                    return;
                }
                else
                {
                    Id = Convert.ToInt32(number);
                }

                Console.WriteLine("請輸入飲料數量:");
                number = Console.ReadLine();
                if (number == "x")
                {
                    Console.WriteLine("謝謝光臨~");
                    return;
                }
                else
                {
                    quantity = Convert.ToInt32(number);
                    total = drinkArr[Id].price * quantity;
                    Console.WriteLine($"您買了{drinkArr[Id].Name}{drinkArr[Id].Size}{quantity}杯，每杯{drinkArr[Id].price}元。");
                    orderArr.Add(new order { Id = Id, quantity = quantity, total = total });
                }
            }
        }

        private static void drinkMenuPrint(List<drinks> myDrinkArr)
        {
            Console.WriteLine("以下是我們的飲料菜單哦~");
            Console.WriteLine("{0,-5}{1,-7}{2,-5}{3,-5}", "編號", "名稱", "大小", "價錢");
            int i = 0;
            foreach (drinks drink in myDrinkArr)
            {
                Console.WriteLine($"{i,-7}{drink.Name,-7}{drink.Size,-5}{drink.price,-5}");
                i++;
            }
        }

        private static void drinkMenu(List<drinks> myDrinkArr)
        {
            myDrinkArr.Add(new drinks() { Name = "綠茶", Size = "大杯", price = 50 });
            myDrinkArr.Add(new drinks() { Name = "抹茶", Size = "中杯", price = 55 });
            myDrinkArr.Add(new drinks() { Name = "奶茶", Size = "大杯", price = 60 });
            myDrinkArr.Add(new drinks() { Name = "紅茶", Size = "大杯", price = 58 });
            myDrinkArr.Add(new drinks() { Name = "烏龍", Size = "中杯", price = 30 });
        }
    }
}
