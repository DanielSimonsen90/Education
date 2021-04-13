using DanhosMessages.Pages;
using System.Windows;

namespace DanhosMessages
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ProgramContext Context { get; set; } = new ProgramContext("(localdb)\\MSSQLLocalDB");
        public MainWindow()
        {
            InitializeComponent();
            var context = new ProgramContext("(localdb)\\MSSQLLocalDB");
            
            MainFrame.Content = new Login(this);
        }
    }
}
