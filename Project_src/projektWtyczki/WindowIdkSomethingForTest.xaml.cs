using System;
using System.Collections.Generic;
using System.Configuration;
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
    /// Logika interakcji dla klasy WindowIdkSomethingForTest.xaml
    /// </summary>  

    public partial class WindowIdkSomethingForTest : Window
    {
       
        string id;
        string name;
        string type;
        string maker;
        string link;
        string desc;
       
        int startingSize=Database.countRows("Plugins");
        public WindowIdkSomethingForTest()
        {

            InitializeComponent();
            Database.FillDataGrid(dgWtyczki, "Plugins", "SELECT * FROM dbo.Plugins");
          
        }

     

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int counter = 0;
            foreach (System.Data.DataRowView dr in dgWtyczki.ItemsSource)
            {
                if (dr[0] != null)
                {
                    counter++;
                    id = dr[0].ToString();
                    name = dr[1].ToString();
                    type = Database.validateMorT(dr[2].ToString());
                    maker = Database.validateMorT(dr[3].ToString());
                    link = dr[4].ToString();
                    desc = dr[5].ToString();
                    if (counter > startingSize)
                    {
                        id = (counter).ToString();
                        string queryInsert =
                        "INSERT INTO dbo.Plugins (Name,Type,Maker,Link,Description) VALUES " 
                        + "('" + name + "','" + type + "','" + maker + "','" + link + "','" + desc + "');";
                        Database.AddRow(dgWtyczki,"Plugins",queryInsert);
                        Database.FillDataGrid(dgWtyczki, "Plugins", "SELECT * FROM dbo.Plugins");
                    }
                    else
                    {
                        string queryUpdate =
                            "UPDATE dbo.Plugins SET " +
                            "Name='" + name + "'," +
                            "Type ='" + type + "'," +
                            "Maker = '" + maker + "'," +
                            "Link = '" + link + "'," +
                            "Description ='" + desc + "'" +
                            "WHERE PluginID='" + id + "'";
                        Database.UpdateRow("Plugins", queryUpdate);
                        Database.FillDataGrid(dgWtyczki, "Plugins", "SELECT * FROM dbo.Plugins");
                    }
                }      
            }
            startingSize = Database.countRows("Plugins");

        }

        private void dgWtyczki_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
