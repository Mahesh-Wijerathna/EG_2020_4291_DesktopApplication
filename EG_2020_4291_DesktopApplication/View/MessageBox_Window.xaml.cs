using EG_2020_4291_DesktopApplication.ViewModel;
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
using System.Windows.Shapes;

namespace EG_2020_4291_DesktopApplication.View
{
    /// <summary>
    /// Interaction logic for MessageBox_Window.xaml
    /// </summary>
    public partial class MessageBox_Window : Window
    {
        public MessageBox_Window(MessageBoxWindow_VM vm_datacontext)
        {
            
            InitializeComponent();
            DataContext = vm_datacontext;
        }
    }
}
