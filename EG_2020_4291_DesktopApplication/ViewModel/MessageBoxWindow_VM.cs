using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace EG_2020_4291_DesktopApplication.ViewModel
{
    public partial class MessageBoxWindow_VM : ObservableObject
    {
        [ObservableProperty]
        public string title ;
        [ObservableProperty]
        public string message;
        [ObservableProperty]
        public string buttonContent;

        public MessageBoxWindow_VM() { }
        public MessageBoxWindow_VM(string titlE,string messagE,string buttonContenT)
        {
            title = titlE;
            message = messagE;
            buttonContent = buttonContenT;
        }
        [RelayCommand]
        public void MessageBox_Button() {
            Close_Button();
        }
        [RelayCommand]
        public void Close_Button() {
            foreach (Window item in Application.Current.Windows)
                if (item.DataContext == this) item.Close();
        }

    }

}
