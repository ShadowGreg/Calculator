using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Windows;
using System.Windows.Controls;

namespace Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly ObservableCollection<string> _history = new ObservableCollection<string>();
        public MainWindow()
        {
            InitializeComponent();

            foreach (UIElement el in MinRoot.Children)
            {
                if (el is Button)
                {
                    ((Button)el).Click += ButtonClick;
                }
            }

        }
        public IEnumerable<string> History => _history;
        private void AddToHistory(string item)
        {
            if (!_history.Contains(item))
                _history.Add(item);
        }

        private void ButtonClick(object sender, RoutedEventArgs e)
        {
            string content = (string)((Button)e.OriginalSource).Content;
            if (content == "AC")
            {
                TextBlock.Text = "";
                LoadTextBlock.Text = "";
            }
            if (content == "DEL")
            {
                string? value = new DataTable().Compute(TextBlock.Text, null).ToString();
                value = value.Substring(0, value.Length - 1);
                TextBlock.Text = value;
            }
            else if (content == "=")
            {
                string? value = new DataTable().Compute(TextBlock.Text, null).ToString();
                LoadTextBlock.Text = TextBlock.Text + "=";
                TextBlock.Text = value;
                AddToHistory(TextBlock.Text + "="+ value);
            }
            else if (content != "MR")
            {
                TextBlock.Text += content;
            }
            else if (content != "AC")
            {
                TextBlock.Text += content;
            }


        }
    }
}
