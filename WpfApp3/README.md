![image](images\mainwindow.png)

```csharp
string takeout = "";
Dictionary<string, int> drinks = new Dictionary<string, int>();
Dictionary<string, int> orders = new Dictionary<string, int>();

public MainWindow()
{
    InitializeComponent();
    addDrink(drinks);
    showDrink(drinks);
}

```

- `takeout` 是一個字串變數，用於儲存使用者選擇的內用或外帶訊息。
- `drinks` 是一個字典，用於儲存不同飲料的名稱和價格。
- `orders` 是一個字典，用於儲存使用者的訂單資訊。
1. **showDrink 方法**：
    
    ```csharp
    private void showDrink(Dictionary<string, int> myDrinks)
    {
        // 迭代所有的飲料並建立介面元素
        foreach (var drink in myDrinks)
        {
            // 建立一個水平方向的 StackPanel
            var sp = new StackPanel
            {
                Orientation = Orientation.Horizontal
            };
    
            // 建立一個核取方塊
            var cb = new CheckBox
            {
                Content = $"{drink.Key} : {drink.Value}元",
                Width = 200,
                FontFamily = new FontFamily("Consolas"),
                FontSize = 18,
                Foreground = Brushes.Blue,
                Margin = new Thickness(5)
            };
    
            // 建立一個滑塊
            var sl = new Slider
            {
                Width = 100,
                Value = 0,
                Minimum = 0,
                Maximum = 10,
                VerticalAlignment = VerticalAlignment.Center,
                IsSnapToTickEnabled = true
            };
    
            // 建立一個標籤
            var lb = new Label
            {
                Width = 50,
                Content = "0",
                FontFamily = new FontFamily("Consolas"),
                FontSize = 18,
                Foreground = Brushes.Red
            };
    
            // 將元素新增到 StackPanel 中
            sp.Children.Add(cb);
            sp.Children.Add(sl);
            sp.Children.Add(lb);
    
            // 資料繫結，將滑塊的值繫結到標籤的內容
            Binding myBinding = new Binding("Value");
            myBinding.Source = sl;
            lb.SetBinding(ContentProperty, myBinding);
    
            // 將 StackPanel 新增到使用者介面中
            menuShow.Children.Add(sp);
        }
    }
    
    ```
    
    - `showDrink` 方法用於顯示飲料清單。它迭代字典中的飲料，為每個飲料建立介面元素，並設定資料繫結，以便滑塊的值與標籤的內容相關聯。
2. **addDrink 方法**：
    
    ```csharp
    private void addDrink(Dictionary<string, int> myDrinks)
    {
        // 開啟檔案對話方塊以選擇包含飲料資訊的檔案
        OpenFileDialog openFileDialog = new OpenFileDialog();
        openFileDialog.Filter = "CSV檔案|*.csv|文字檔案|*.txt|全部檔案|*.*";
        if (openFileDialog.ShowDialog() == true)
        {
            string filename = openFileDialog.FileName;
            string[] lines = File.ReadAllLines(filename);
            // 解析檔案中的每一行，將飲料名稱和價格新增到字典中
            foreach (var line in lines)
            {
                string[] tokens = line.Split(',');
                string drinkName = tokens[0];
                int price = Convert.ToInt32(tokens[1]);
                myDrinks.Add(drinkName, price);
            }
        }
    }
    
    ```
    
    - `addDrink` 方法允許使用者透過開啟檔案對話方塊選擇包含飲料資訊的檔案。它將檔案中的每一行解析為飲料名稱和價格，並將它們新增到字典中。
3. **check_box 方法**：
    
    ```csharp
    private void check_box(object sender, RoutedEventArgs e)
    {
        var rb = sender as RadioButton;
        if (rb.IsChecked == true) takeout = rb.Content.ToString();
    }
    
    ```
    
    - `check_box` 方法是一個事件處理程序，用於處理 RadioButton 的 Checked 事件。

它根據使用者選擇的 RadioButton 更新 `takeout` 變數，以記錄內用或外帶資訊。

這是 `displayOrder` 函式，它負責顯示訂單和計算價格。

```csharp
private void displayOrder(Dictionary<string, int> myOrders)
{
    orderResult.Inlines.Clear();

```

這裡首先清空名為 `orderResult` 的元素中的內容，這個元素可能是一個 WPF 文本框或其他可顯示文字的 UI 元素。

```csharp
Run titleString = new Run
{
    Text = "您所訂購的訂單為",
    FontSize = 16,
    FontWeight = FontWeights.Bold,
    Foreground = Brushes.Blue,
};

```

在這裡，建立一個 `Run` 對象 `titleString` 用於顯示標題文字 "您所訂購的訂單為"，並設置字體大小、粗體和前景色。

```csharp
Run takeoutString = new Run
{
    Text = $"{takeout}:",
    FontSize = 16,
    FontWeight = FontWeights.Bold,
    Foreground = Brushes.Red,
};

```

接下來，建立一個 `Run` 對象 `takeoutString`，用於顯示內用或外帶選項，根據 `takeout` 變數的值，設置字體大小、粗體和前景色。

```csharp
orderResult.Inlines.Add(titleString);
orderResult.Inlines.Add(takeoutString);
orderResult.Inlines.Add(new Run() { Text = " ，訂購明細如下: \\n", FontSize = 16 });

```

這裡將標題、內用/外帶選項和訂購明細的文字添加到 `orderResult` 元素中，以在界面上顯示這些資訊。

```csharp
double total = 0.0;
double sellPrice = 0.0;
string discountString = "";

```

初始化一些變數，用於計算總價格、售價和打折信息。

```csharp
int i = 1;
foreach (var item in myOrders)
{
    string drinkName = item.Key;
    int quantity = myOrders[drinkName];
    int price = drinks[drinkName];
    total += price * quantity;
    orderResult.Inlines.Add(new Run() { Text = $"飲料品項{i}： {drinkName} X {quantity}杯，每杯{price}元，總共{price * quantity}元\\n" });
    i++;
}

```

這裡遍歷 `myOrders` 字典，計算每種飲料的價格和總價格，同時將每種飲料的訂購明細添加到 `orderResult` 中。

```csharp
if (total >= 500)
{
    discountString = "訂購滿500元以上者打8折";
    sellPrice = total * 0.8;
}
else if (total >= 300)
{
    discountString = "訂購滿300元以上者打85折";
    sellPrice = total * 0.85;
}
else if (total >= 200)
{
    discountString = "訂購滿200元以上者打9折";
    sellPrice = total * 0.9;
}
else
{
    discountString = "訂購未滿200元以上者不打折";
    sellPrice = total;
}

```

根據總價格的值，確定打折信息和最終的售價。

```csharp
Italic summaryString = new Italic(new Run
{
    Text = $"本次訂購總共{myOrders.Count}項，{discountString}，售價{sellPrice}元",
    FontSize = 16,
    FontWeight = FontWeights.Bold,
    Foreground = Brushes.Red
});
orderResult.Inlines.Add(summaryString);

```

最後，建立一個 `Italic` 文字樣式，用於顯示訂購總結信息，包括項目數、打折信息和售價，然後將它添加到 `orderResult` 中。

這個函式的作用是顯示訂單詳細信息，包括選擇的飲料、數量、總價格和打折信息。
