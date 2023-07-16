using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using EG_2020_4291_DesktopApplication.Model;
using EG_2020_4291_DesktopApplication.View;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace EG_2020_4291_DesktopApplication.ViewModel
{
    public partial class AddAndEditWIndow_VM : ObservableObject
    {
        [ObservableProperty]
        public string firstName;
        [ObservableProperty]
        public string lastName;
        [ObservableProperty]
        public int age;
        [ObservableProperty]
        public string dateOfBirth;
        [ObservableProperty]
        public double gpa;
        [ObservableProperty]
        public Student tempStudent;
        //[ObservableProperty]
        //public BitmapImage SeletedImage;
        public BitmapImage _selectedImg;
        public BitmapImage SeletedImage
        {
            get
            {
                return _selectedImg;
            }

            set
            {
                if (_selectedImg == value)
                {

                    return;
                }

                _selectedImg = value;

                OnPropertyChanged(nameof(SeletedImage));

            }
        }

        public AddAndEditWIndow_VM()
        {


            firstName = null;
            lastName = null;
            age = 0;
            gpa = 0.00;
            dateOfBirth = null;
            SeletedImage = null;


        }
        public AddAndEditWIndow_VM(Student editingStudent)
        {



            firstName = editingStudent.First_Name;
            lastName = editingStudent.Last_Name;
            age = editingStudent.Age;
            gpa = editingStudent.GPA;
            dateOfBirth = editingStudent.Date_Of_Birth;
            SeletedImage = editingStudent.Image_Of_Student;


        }
        [RelayCommand]
        public void PhotoSelect_Button() {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Image files | *.bmp; *.png; *.jpg";
            dialog.FilterIndex = 1;
            if (dialog.ShowDialog() == true)
            {
                
                SeletedImage = new BitmapImage(new Uri(dialog.FileName));
                ShowMessageBox("SUCCESSFULL", "Image was Uploaded Suscessfully", "OK");
     
            }
        }
        [RelayCommand]
        public void Save_Button()
        {
            if (gpa < 0 || gpa > 4)
            {
                ShowMessageBox("ERROR !", "GPA value should be between 0 and 4", "OK");

            }
            else
            {
                Student t = new Student();
                t.First_Name = firstName;
                t.Last_Name = lastName;
                t.Age = age;
                t.Date_Of_Birth = dateOfBirth;
                t.GPA = gpa;
                t.Image_Of_Student = SeletedImage;
                tempStudent = t;

                if (tempStudent.First_Name == null && tempStudent.Last_Name == null)
                {

                    ShowMessageBox("WARNING", "Both first name and last name \n can not be empty", "Ok");

                }

                else foreach (Window item in Application.Current.Windows)
                        if (item.DataContext == this) item.Close();
            }
        }
        [RelayCommand]
        public void Minimize_Button() {
            foreach (Window item in Application.Current.Windows)
                if (item.DataContext == this) item.WindowState = WindowState.Minimized;
        }
        [RelayCommand]
        public void Close_Button() {
            tempStudent = null;
            foreach (Window item in Application.Current.Windows)
                if (item.DataContext == this) item.Close();
        }
        public void ShowMessageBox(string topic, string message, string buttonText)
        {
            MessageBoxWindow_VM msg_vm = new MessageBoxWindow_VM(topic, message, buttonText);
            MessageBox_Window msgWindow = new MessageBox_Window(msg_vm);
            msgWindow.ShowDialog();
        }

    }
}
