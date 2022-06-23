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
using System.Windows.Shapes;

namespace projektWtyczki
{
    /// <summary>
    /// Logika interakcji dla klasy WindowMakers.xaml
    /// </summary>
    public partial class WindowMakers : Window
    {

        string id;
        string name;
        int startingSize = Database.countRows("Makers");
        public WindowMakers()
        {
            InitializeComponent();
            
            Database.FillDataGrid(dgAutorzy, "Makers", "SELECT * FROM dbo.Makers");
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            int counter = 0;
            foreach (System.Data.DataRowView dr in dgAutorzy.ItemsSource)
            {
                if (dr[0] != null && dr[1] != null)
                {
                    counter++;
                    id = dr[0].ToString();
                    name = dr[1].ToString();
                   
                    if (counter > startingSize)
                    {
                        id = (counter).ToString();
                        string queryInsert =
                        "INSERT INTO dbo.Makers (Name) VALUES "
                        + "('" + name +  "');";
                        Database.AddRow(dgAutorzy, "Makers", queryInsert);
                        Database.FillDataGrid(dgAutorzy, "Makers", "SELECT * FROM dbo.Makers");
                    }
                    else
                    {
                        string queryUpdate =
                            "UPDATE dbo.Plugins SET " +
                            "Name='" + name + "'" +
                            "WHERE PluginID='" + id + "'";
                        Database.UpdateRow("Makers", queryUpdate);
                        Database.FillDataGrid(dgAutorzy, "Makers", "SELECT * FROM dbo.Makers");
                    }
                }
            }
            startingSize = Database.countRows("Makers");

        }
    }
}
