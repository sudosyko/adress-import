using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace adress_import.Data
{
    internal class Ortschaften
    {
        public int OID { get; set; }
        public string Ort { get; set; }
        public int Postleitzahl { get; set; }
        public ICollection<Adressen> Adressen { get; set; }
    }
}
