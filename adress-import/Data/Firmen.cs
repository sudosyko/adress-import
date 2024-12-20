using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace adress_import.Data
{
    internal class Firmen
    {
        public int FID { get; set; }
        public string Firmenname { get; set; }
        public ICollection<Adressen> Adressen { get; set; }
    }
}
