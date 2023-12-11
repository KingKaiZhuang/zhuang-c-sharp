﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace WebBug
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string url = "https://data.moenv.gov.tw/api/v2/aqx_p_432?api_key=e8dd42e6-9b8b-43f8-991e-b3dee723a52d&limit=1000&sort=ImportDate desc&format=JSON";

        AQIdata aqidata = new AQIdata();
        List<Field> fields = new List<Field>();
        List<Record> records = new List<Record>();

        public MainWindow()
        {
            InitializeComponent();
            UrlTextBox.Text = url;
        }

        private async void GetWebDataButton_Click(object sender, RoutedEventArgs e)
        {
            ContentTextBox.Text = "正在抓取網路資料...";
            string jsontext = await FetchContentAsync(url);
            ContentTextBox.Text = jsontext;
            aqidata = JsonSerializer.Deserialize<AQIdata>(jsontext);
            fields = aqidata.fields.ToList();
            records = aqidata.records.ToList();
            StatusTextBlock.Text = $"共有 {records.Count} 筆資料";
            DisplayAQIData();
        }

        private void DisplayAQIData()
        {
            RecordDataGrid.ItemsSource = records;
            DataWrapPanel.Children.Clear();

            foreach(var field in fields)
            {
                var propertyInfo = typeof(Record).GetProperty(field.id);
                if(propertyInfo != null)
                {
                    string value = propertyInfo.GetValue(records[0]) as string;
                    if(double.TryParse(value, out double v))
                    {
                        CheckBox cb = new CheckBox
                        {
                            Content = field.info.label,
                            Tag = field.id,
                            Margin = new Thickness(5),
                            Width = 120,
                            FontSize = 14,
                            FontWeight = FontWeights.Bold
                        };                      
                        

                        DataWrapPanel.Children.Add(cb);
                    }
                }
            }
        }

        private async Task<string> FetchContentAsync(string url)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    return await client.GetStringAsync(url);
                }
            }
            catch (Exception ex)
            {
                return $"發生錯誤: {ex.Message}";
            }
        }
    }
}
