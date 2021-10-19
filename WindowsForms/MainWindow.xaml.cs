using System;
using System.Collections.Generic;
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

namespace WindowsForms
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //DataGridColumn dataGridColumn = new DataGridColumn();
            //dataGridView1.Columns.Add();

            //dataGridView1.Columns.
               /* = 
                new List<Customer>
        {
            new Customer { Id = 1, Name = "The Very Big Corporation of America" },
            new Customer { Id = 2, Name = "Old Accountants Ltd" }
        };*/

        }
    }
}