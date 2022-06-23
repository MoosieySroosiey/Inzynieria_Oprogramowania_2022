using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
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

namespace projektWtyczki
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
           // Database WtyczkiBaza = new Database();
        }

     
     

        private void Button_Click2(object sender, RoutedEventArgs e)
        {
           
        }

        private void Button_Click3(object sender, RoutedEventArgs e)
        {
            WindowViews wv = new WindowViews();
            wv.ShowDialog();
        }
        private void Button_OpenSmthng(object sender, RoutedEventArgs e)
        {
            WindowIdkSomethingForTest wisft = new WindowIdkSomethingForTest();
            wisft.ShowDialog();
        }

        private void Button_OpenSmthng2(object sender, RoutedEventArgs e)
        {
            WindowMakers wm = new WindowMakers();
            wm.ShowDialog();
        }
        private void Button_OpenSmthng3(object sender, RoutedEventArgs e)
        {
            WindowTypes wt = new WindowTypes();
            wt.ShowDialog();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }
    }
}
