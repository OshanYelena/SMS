using Attempt11.Models;
using Attempt11.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Attempt11.ViewModels
{
    public partial class MainWindowVM : ObservableObject
    {
        [ObservableProperty]
        public ObservableCollection<Student> students;

        [ObservableProperty]
        public Student selectedStudent;

        public MainWindowVM() {
            Students = new ObservableCollection<Student>();
        }

        [RelayCommand]
        public void AddStudent()
        {
            var viewModel = new AddEditStudentWindowVM();
            var window = new AddEditWindow {
                Title = "Add Student",
                DataContext = viewModel,
            };

            if(window.ShowDialog() == true)
            {
                var student = new Student
                {
                    FirstName = viewModel.FirstName,
                    LastName = viewModel.LastName,
                    Image = viewModel.Image,
                    DateofBirth = viewModel.DateOfBirth,
                    GPA = viewModel.GPA
                };

                if(student.FirstName != null && student.LastName != null) {
                    Students.Add(student);
                }
            }
        }

        [RelayCommand]
        public void EditStudent()
        {
            if(SelectedStudent == null)
            {
                MessageBox.Show(" Please Select a Student.", "Warning", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            else
            {
                var viewModel = new AddEditStudentWindowVM
                {
                    FirstName = SelectedStudent.FirstName,
                    LastName = SelectedStudent.LastName,
                    Image = SelectedStudent.Image,
                    DateOfBirth = SelectedStudent.DateofBirth,
                    GPA = SelectedStudent.GPA
                };
                var window = new AddEditWindow
                {
                    Title = "Edit Student",
                    DataContext = viewModel,
                };
                if (window.ShowDialog() == true)
                {
                    SelectedStudent.FirstName = viewModel.FirstName;
                    SelectedStudent.LastName = viewModel.LastName;
                    SelectedStudent.Image = viewModel.Image;
                    SelectedStudent.DateofBirth = viewModel.DateOfBirth;
                    SelectedStudent.GPA = viewModel.GPA;

                    Students = new ObservableCollection<Student>(Students);
                }
            }
        }

        [RelayCommand]
        public void DeleteStudent()
        {
            if (SelectedStudent == null)
            {
                MessageBox.Show(" Please Select a Student.", "Warning", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            else
            {

                var dialogResult = MessageBox.Show($"Do you want to delete {SelectedStudent.FirstName} ?", "Warning", MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (dialogResult == MessageBoxResult.Yes)
                    Students.Remove(SelectedStudent);
            }
        }
    }
}
