using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace projektWtyczki
{
    
    /// <summary>
    /// Logika interakcji dla klasy WindowViews.xaml
    /// </summary>
    public partial class WindowViews : Window
    {
        public WindowViews()
        {
            InitializeComponent();
            FillDataGrids();
        }
        private void FillDataGrids()

        {

            Database.FillDataGrid(dgInst, "dbo.ViewTest", "SELECT * FROM dbo.ViewTest");
            
            Database.FillDataGrid(dgEff, "dbo.ViewTest2", "SELECT * FROM dbo.ViewTest2");
            }

        private void Serialize_Views(object sender, RoutedEventArgs e)
        {

            //List<View> listOfInstruments = new List<View>();
            //listOfInstruments.Add(dgInst.);
            //foreach (DataGridViewRow row in dgInst)
            //{
            //    //currQty += row.Cells["qty"].Value;
            //    //More code here
            //}
            //Serializacja.SerializeToXml<List<View>>(listOfInstruments, "D://instrumenty.xml");

            //List<View> listOfEffects = dgEff.ItemsSource as List<View>;

            //Serializacja.SerializeToXml<List<View>>(listOfEffects, "D://Efekty.xml");
        }
    }
}
