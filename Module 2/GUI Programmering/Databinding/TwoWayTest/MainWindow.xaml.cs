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

namespace TwoWayTest
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Person Person => DataGridThing.SelectedItem as Person;

        public MainWindow()
        {
            InitializeComponent();
            DataContext = new List<Person>()
            {
                new Person(1, "Kippy", "Bae", 120),
                new Person(0, "Daniel", "Simonsen", 100),
                new Person(2, "Shankie", "Wankie", 150)
            };
        }

        private void btnVisData_Click(object sender, RoutedEventArgs e) => MessageBox.Show(Person.GetFormue());
        private void btnOpdaterFormue_Click(object sender, RoutedEventArgs e) => Person.Formue++;
    }
}
