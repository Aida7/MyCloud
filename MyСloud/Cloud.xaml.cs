using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MyСloud
{
    /// <summary>
    /// Логика взаимодействия для Cloud.xaml
    /// </summary>
    public partial class Cloud : Page
    {
        public Cloud()
        {
            InitializeComponent();
        }

        private void DeletedItem_Clik(object sender, RoutedEventArgs e)
        {
           
            List<Files> file = new List<Files>();

        }
        private void OpenItem_Clik(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            List<Files> file = new List<Files>();
         

            openFileDialog.Multiselect = true;
            openFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            if (openFileDialog.ShowDialog() == true)
            {
                foreach (string filename in openFileDialog.FileNames)
                {
                    listB.Items.Add(System.IO.Path.GetFileName(filename));
                    file.Add(new Files
                    {
                        Name = System.IO.Path.GetFileName(filename),
                        Way = System.IO.Path.GetFullPath(filename),
                        Format = System.IO.Path.GetExtension(filename),
                    });
                }
                 
            }

        }
    }
}
