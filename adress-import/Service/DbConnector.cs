using adress_import.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace adress_import.Service
{
    internal class DbConnector
    {
        public DbConnector() { }

        public void create(string vorname, string name, string strasse, int hausnummer, string firmenname, string ort, int postleitzahl)
        {
            using (Context context = new Context())
            {
                Firmen firma = new Firmen();
                firma.Firmenname = firmenname;

                Ortschaften ortschaft = new Ortschaften();
                ortschaft.Ort = ort;

                Adressen adresse = new Adressen();
                adresse.Vorname = vorname;
                adresse.Name = name;
                adresse.Strasse = strasse;
                adresse.Hausnummer = hausnummer;
                adresse.Firma = firma;
                adresse.Ortschaft = ortschaft;

                context.Add(firma);
                context.Add(ortschaft);
                context.Add(adresse);
                
                context.SaveChanges();
            }
        }

        public void read()
        {

        }

        public void update()
        {

        }

        public void delete()
        {

        }
    }
}
