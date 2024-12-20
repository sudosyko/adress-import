using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace adress_import.Data
{
    internal class Adressen
    {
        public int AID { get; set; }
        public string Vorname { get; set; }
        public string Name { get; set; }
        public Firmen Firma { get; set; }
        public int FK_FID { get; set; }
        public string Strasse { get; set; }
        public int Hausnummer { get; set; }
        public Ortschaften Ortschaft { get; set; }
        public int FK_OID { get; set; }
    }
}
