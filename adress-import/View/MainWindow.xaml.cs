using Microsoft.Win32;
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
        private List<string[]> adresses;

        public MainWindow()
        {
            InitializeComponent();
        }

        public void importAdress_click(object sender, RoutedEventArgs e)
        {
            string csvFilePath = getFilePath();
            try 
            {
                adresses = importCSV(csvFilePath);
            } catch (Exception ex) 
            {
                return;
            }

            CsvDataGrid.Columns.Clear();
            

            for (int i = 0; i < adresses[0].Count(); i++)
            {
                CsvDataGrid.Columns.Add(new DataGridTextColumn
                {
                    Header = adresses[0][i],
                    Binding = new Binding($"[{i}]")
                });
            }

            for (int i = 1; i < adresses.Count; i++)
            {
                CsvDataGrid.Items.Add(adresses[i]);
            }
        }

        public string getFilePath()
        {
            string filePath = "";

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = "c:\\";
            openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog.FilterIndex = 2;
            openFileDialog.RestoreDirectory = true;

            openFileDialog.ShowDialog();
            filePath = openFileDialog.FileName;

            return filePath;
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
        public List<string[]> importCSV(string csvFilePath)
        {
            List<string[]> csv = new List<string[]>();

            string[] rows = File.ReadAllLines(csvFilePath);

            int columns = 0;

            foreach (string row in rows.Take(1))
            {
                string[] values = row.Split(";");
                columns = values.Count();
            }

            foreach (string row in rows)
            {
                string[] values = row.Split(";");
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