using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace EG_2020_4291_DesktopApplication.Model
{
    public class Student
    {
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public string Image_Location { get { return $"/Model/Icons/{Image_Of_Student}"; } }
        public BitmapImage Image_Of_Student { get; set; }
        public int Age { get; set; }
        public string Date_Of_Birth { get; set; }
        public Double GPA { get; set; }

        public Student() { // defalt constructor
            First_Name = null;
            Last_Name = null;
            Age = 0;
            Date_Of_Birth = null;
            GPA = 0.00;
        }
        public Student(BitmapImage imageOfStudent, string firstName, string lastName, int age, string dateOfBirth, double gPA)
        {
            First_Name = firstName;
            Last_Name = lastName;
            Age = age;
            Date_Of_Birth = dateOfBirth;
            GPA = gPA;
            Image_Of_Student = imageOfStudent;
        }

    }
}
