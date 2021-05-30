using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

namespace Checkbox
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void cbAllCheckedChanged(object sender, RoutedEventArgs e)
        {
            bool newVal = (todoItems.IsChecked == true);
            cbDoThis.IsChecked = newVal;
            cbDoThat.IsChecked = newVal;
            cbDoAnother.IsChecked = newVal;
        }

        private void cbSingleCheckedChanged(object sender, RoutedEventArgs e)
        {
            todoItems.IsChecked = null;
            if ((cbDoThis.IsChecked == true) && (cbDoThat.IsChecked == true) && (cbDoAnother.IsChecked == true)) {
                todoItems.IsChecked = true;
            } 
            if ((cbDoThis.IsChecked == false) && (cbDoThat.IsChecked == false) && (cbDoAnother.IsChecked == false))
            {
                todoItems.IsChecked = false;
            }
        }
    }
}
