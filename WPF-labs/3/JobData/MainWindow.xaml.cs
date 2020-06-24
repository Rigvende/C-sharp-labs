using System.Collections.ObjectModel;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows;

namespace JobData
{
    public partial class MainWindow : Window
    {
        readonly Entry entry;
        readonly BinaryFormatter formatter;
        readonly ObservableCollection<Entry> results;
        public MainWindow()
        {
            InitializeComponent();
            entry = new Entry();
            grid.DataContext = entry;
            formatter = new BinaryFormatter();
            results = new ObservableCollection<Entry>();
            lResult.ItemsSource = results;
        }

        private void Btn_Submit_Click(object sender, RoutedEventArgs e)
        {
            if (entry.IsFilled())
            {
                using (FileStream fstream = new FileStream("data.txt", FileMode.Append))
                {

                    formatter.Serialize(fstream, entry);
                }
                MessageBox.Show("Информация записана в файл.");
                entry.Clear();
            }
            else
            {
                MessageBox.Show("Все поля должны быть заполнены!");
            }

        }

        private void Btn_Show_Click(object sender, RoutedEventArgs e)
        {
            results.Clear();
            using (FileStream fstream = new FileStream("data.txt", FileMode.OpenOrCreate))
            {
                int k = 1;
                while (fstream.Position != fstream.Length)
                {
                    Entry entry = (Entry)formatter.Deserialize(fstream);
                    entry.Index = k;
                    results.Add(entry);
                    k += 1;
                }
            }
        }
    }
}
