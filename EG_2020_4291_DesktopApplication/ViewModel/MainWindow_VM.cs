using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using EG_2020_4291_DesktopApplication.Model;
using EG_2020_4291_DesktopApplication.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;

namespace EG_2020_4291_DesktopApplication.ViewModel
{
    public partial class MainWindow_VM : ObservableObject
    {
        [ObservableProperty]
        public ObservableCollection<Student>? students;
        [ObservableProperty]
        public Student? selectedStudent = null;
        public MainWindow_VM()
        {
            students = new ObservableCollection<Student>();
            BitmapImage image1 = new BitmapImage(new Uri("/Model/Icons/2.jpg", UriKind.Relative));
            students.Add(new Student(image1, "Mahesh", "Wijerathna", 22, "12/02/2000", 1.2));
            BitmapImage image2 = new BitmapImage(new Uri("/Model/Icons/6.jpg", UriKind.Relative));
            students.Add(new Student(image2, "Anjalee", "Witharana", 23, "10/04/2000", 3.8));


        }
        [RelayCommand]
        public void AddStudent() {
            AddAndEditWIndow_VM tempStudent_vm = new AddAndEditWIndow_VM();

            // graphical part
            AddAndEdit_Window window = new AddAndEdit_Window(tempStudent_vm);
            window.ShowDialog();





            // funtional part

            if (tempStudent_vm.tempStudent == null)
            {
                ShowMessageBox("Oparetion Failed", "Student adding was failed", "OK");

            }


            //else return;
            if (tempStudent_vm.tempStudent != null) students.Add(tempStudent_vm.tempStudent);
            else
            {

                return;
            }
        }
        [RelayCommand]
        public void EditStudent() {
            if (students.Count == 0)
            {
                ShowMessageBox("Oparetion Failed", "Students List is Empty", "OK");

            }
            else
            {
                if (selectedStudent == null)
                {
                    ShowMessageBox("Oparetion Failed", "Select student First", "OK");

                }
                else
                {
                    
                    AddAndEditWIndow_VM tempStudent_vm = new AddAndEditWIndow_VM(selectedStudent);
                    tempStudent_vm.tempStudent = selectedStudent;

                    Student check = new Student();
                    check = selectedStudent;


                    // graphical part
                    AddAndEdit_Window window = new AddAndEdit_Window(tempStudent_vm);
                    window.ShowDialog();

                    if (tempStudent_vm.tempStudent == check)
                    {
                        ShowMessageBox("CLOSED ", "No changes were Saved", "OK");

                    }
                    //    // funtional part
                    else if (tempStudent_vm.tempStudent != null)
                    {
                        
                        int IndexOfSelected = students.IndexOf(selectedStudent);
                        students.Insert(IndexOfSelected, tempStudent_vm.tempStudent);
                        students.RemoveAt(IndexOfSelected + 1);
                        ShowMessageBox("SUCCESSFULL ", "Changes were saved successfully", "OK");

                        
                    }

                }
            }
        }
        [RelayCommand]
        public void DeleteStudent() {
            if (students.Count == 0)
            {
                ShowMessageBox("Oparetion Failed", "Students List is Empty", "Ok");

            }
            else
            {
                if (selectedStudent != null)
                {
                    students.Remove(selectedStudent);
                    ShowMessageBox("Deleted ! ", " Student was deleted Successfully", "Ok");
                    

                }
                else
                {
                    ShowMessageBox("Oparetion Failed", "Select student First", "Ok");
                    
                }
            }
        }
        [RelayCommand]
        public void Minimize_Button() {
            foreach (Window item in Application.Current.Windows)
                if (item.DataContext == this) item.WindowState = WindowState.Minimized;
        }
        [RelayCommand]
        public void Close_Button() {
            foreach (Window item in Application.Current.Windows)
                if (item.DataContext == this) item.Close();
        }
        
        public  void ShowMessageBox(string topic, string message, string buttonText)
        {
            MessageBoxWindow_VM msg_vm = new(topic, message, buttonText);
            MessageBox_Window msgWindow = new(msg_vm);
            msgWindow.ShowDialog();
        }
    }
}
