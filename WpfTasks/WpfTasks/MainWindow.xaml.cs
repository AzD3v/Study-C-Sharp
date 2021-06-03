using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfTasks
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static readonly DependencyProperty HtmlProperty ?=

        public MainWindow()
        {
            InitializeComponent();
        }

        private void myButton_Click(object sender, RoutedEventArgs e)
        {
            Task.Run(() =>
            {
                Debug.WriteLine($"Thread nr. {Thread.CurrentThread.ManagedThreadId}");
                HttpClient webClient = new HttpClient();
                string html = webClient.GetStringAsync("https://google.com").Result;

                myButton.Dispatcher.Invoke(() =>
                {
                    Debug.WriteLine($"Thread nr. {Thread.CurrentThread.ManagedThreadId} owns MyButton");
                    myButton.Content = "Done";
                });
            });
        }

        private async void myButton_Click2(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine($"Thread nr. {Thread.CurrentThread.ManagedThreadId}");

            await Task.Run(async () =>
            {
                Debug.WriteLine($"Thread nr. {Thread.CurrentThread.ManagedThreadId} during awaiting task");
                HttpClient webClient = new HttpClient();
                string html = webClient.GetStringAsync("https://google.com").Result;
            });

            Debug.WriteLine($"Thread nr. {Thread.CurrentThread.ManagedThreadId} after await task");
            myButton.Content = "Done downloading";
            MyWebBrowser.SetValue();
        }   

        static void OnHtmlChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs e)
        {
            WebBrowser webBrowser = dependencyObject as WebBrowser;

            if (webBrowser != null)
                webBrowser.NavigateToString(e.NewValue as string);
        }
    }
}
