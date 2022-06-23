using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using System.Xml.Serialization;
using static System.Net.Mime.MediaTypeNames;

namespace projektWtyczki
{
    public class Wtyczka
    {
        public string name { get; set; }
        public string maker { get; set; }
        public string type { get; set; }
        public string link { get; set; }

        public string description { get; set; }
    
        public Wtyczka()
        {

        }

        public Wtyczka(string nazwa,string producent,string typ,string link,string opis)
        {
            this.name = nazwa;
            this.maker = producent;
            this.type = typ;
            this.link = link;
            this.description = opis;
        }

        public Wtyczka(Wtyczka wtyczka)
        {
            this.name = wtyczka.name;
            this.maker = wtyczka.maker;
            this.type = wtyczka.type;
            this.link = wtyczka.link;
            this.description = wtyczka.description;
        }
    }
}
