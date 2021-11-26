using MicrosoftToDoEventMonitor;
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

namespace UnitTest
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            EventMonitor monitor = new EventMonitor(
                @"C:\Users\Admin\AppData\Local\Packages\Microsoft.Todos_8wekyb3d8bbwe\LocalState\AccountsRoot\13aba0884a1c48269340f4065e0fc67b\todosqlite.db",
                "MsToDoSnapshot.db");

            monitor.OnTaskAdded += Monitor_OnTaskAdded;
        }

        private void Monitor_OnTaskAdded1(List<MicrosoftToDoEventMonitor.Modules.Task> obj)
        {
            throw new NotImplementedException();
        }
    }
}
