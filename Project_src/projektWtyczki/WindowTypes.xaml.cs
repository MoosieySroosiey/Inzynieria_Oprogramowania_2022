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
    /// Logika interakcji dla klasy WindowTypes.xaml
    /// </summary>
    public partial class WindowTypes : Window
    {
        string name;
        string id;
        string instOrEff;

        int startingSize = Database.countRows("Types");
        public WindowTypes()
        {
            InitializeComponent();
            Database.FillDataGrid(dgTypy,"Types","SELECT * FROM dbo.Types");
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int counter = 0;
            foreach (System.Data.DataRowView dr in dgTypy.ItemsSource)
            {
                if (dr[0] != null && dr[1] != null && dr[2] != null)
                {
                    id = dr[0].ToString();
                    name = dr[1].ToString();
                    instOrEff = Database.validateInstOrEff(dr[2].ToString());
                    if (counter > startingSize)
                    {
                        id = (counter).ToString();
                        string queryInsert =
                        "INSERT INTO dbo.Types (Name,InstrumentOrEffect) VALUES "
                        + "('" + name + "','" + instOrEff + "');";
                        Database.AddRow(dgTypy, "Types", queryInsert);
                        Database.FillDataGrid(dgTypy, "Plugins", "SELECT * FROM dbo.Plugins");
                    }
                    else
                    {
                        string queryUpdate =
                        "UPDATE dbo.Types SET " +
                        "Name='" + name + "'," +
                        "InstrumentOrEffect='" + instOrEff + "'" +
                        "WHERE TypeID='" + id + "'";
                        Database.UpdateRow("Types", queryUpdate);
                        Database.FillDataGrid(dgTypy, "Types", "SELECT * FROM dbo.Types");
                    }
                }
            }
            startingSize = Database.countRows("Types");
        }
    }
}
