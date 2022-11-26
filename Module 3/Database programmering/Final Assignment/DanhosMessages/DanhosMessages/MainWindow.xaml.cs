using DanhosMessages.Entitties;
using DanhosMessages.Pages;
using System.Windows;

namespace DanhosMessages
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //public DanhosMessagesContext Context { get; set; }
        //public DBAccess DBAccess { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            //Context = new DanhosMessagesContext("(localdb)\\MSSQLLocalDB");
            //DBAccess = new DBAccess(DanhosMessagesContext.Context);
            
            MainFrame.Content = new LoginPage(this);
        }
    }
}
