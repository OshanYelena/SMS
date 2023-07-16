using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace Attempt11.Models
{
    public class Student
    {
        public string FirstName { get; set; }   
        public string LastName { get; set; }
        public DateOnly DateofBirth { get; set; }
        public BitmapImage Image { get; set; }
        public double GPA { get; set; }

        public Student(string firstName, string lastName, DateOnly dateofBirth, BitmapImage image, double gPA)
        {
            FirstName = firstName;
            LastName = lastName;
            DateofBirth = dateofBirth;
            Image = image;
            GPA = gPA;
        }

        public Student() { }
    }
}
