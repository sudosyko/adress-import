using System.Diagnostics;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace adress_import
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        /*
         * args: filepath to csv, nmb of columns
         * generates 2 dimensanional array
         * first dimension -> row
         * second dimension -> column
         * Array[3][2] -> 3rd row, 2nd column
         * 
         * filtering
        */
        public List<string[]> importCSV(string csvFilePath, int columns)
        {
            List<string[]> csv = new List<string[]>();

            string[] rows = File.ReadAllLines(csvFilePath);

            foreach (string row in rows)
            {
                string[] values = row.Split(",");
                bool empty = false;

                if (values.Length > 0)
                {
                    foreach (string value in values)
                    {
                        if (value == "")
                        {
                            empty = true;
                        }
                    }
                }
                else
                {
                    empty = true;
                }

                if (values.Length < columns)
                {
                    empty = true;
                }

                if (!empty)
                {
                    csv.Add(values);
                }
            }
            return csv;
        }
    }
}