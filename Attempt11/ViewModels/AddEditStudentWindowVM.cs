using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;

namespace Attempt11.ViewModels
{
    public partial class AddEditStudentWindowVM : ObservableObject
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateOnly DateOfBirth { get; set; }
        public BitmapImage Image { get; set; }
        public double GPA { get; set; }

        public AddEditStudentWindowVM()
        {
            
        }
        [RelayCommand]
        public void UploadPhoto()
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Image files | *.bmp; *.png; *.jpg";
            dialog.FilterIndex = 1;
            if(dialog.ShowDialog() == true)
            {
                Image = new BitmapImage(new Uri(dialog.FileName));
                MessageBox.Show("Image uploaded successfully !", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        [RelayCommand]
        public void Save()
        {
            double number = GPA;
            string GpaString = number.ToString();

            if (string.IsNullOrWhiteSpace(FirstName))
            {
                MessageBox.Show("Plz Enter First Name");
            }
            else


            if (string.IsNullOrWhiteSpace(LastName))
            {
                MessageBox.Show("Plz Enter Last Name");
            }
            else


            if (string.IsNullOrWhiteSpace(GpaString))
            {
                MessageBox.Show("Plz Enter  Student GPA");
            }
            else

            {
                MessageBox.Show("Student saved successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

            }
            CloseWindow();
        }

        [RelayCommand]
        public void Cancel()
        {
            CloseWindow();
        }

        private void CloseWindow()
        {
            foreach (Window window in Application.Current.Windows)
            {
                if (window.DataContext == this)
                {
                    window.DialogResult = true;
                    window.Close();
                }
            }
        }
    }
}
