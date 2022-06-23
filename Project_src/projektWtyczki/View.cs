using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projektWtyczki
{
    class View
    {
        public string pluginID { get; set; }
        public string Name { get; set; }
        public string Link { get; set; }
        public string Description { get; set; }
        public string Maker { get; set; }

  public View()
        {

        }

        public View(string plID, string Name, string Link, string Desc , string Mak)
        {
            this.pluginID = plID;
            this.Name = Name;
            this.Link = Link;
            this.Description = Desc;
            this.Maker = Mak;
        }
}
}
