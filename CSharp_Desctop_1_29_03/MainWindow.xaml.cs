using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace CSharp_Desctop_1_29_03
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void FirstName_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(FirstName.Text))
            {
                FirstName.BorderBrush = System.Windows.Media.Brushes.Red;
                FirstName.ToolTip = "The field cannot be empty.";
            }
            else
            {
                FirstName.ClearValue(TextBox.BorderBrushProperty);
                FirstName.ToolTip = null;
            }
        }

        private void LastName_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(LastName.Text))
            {
                LastName.BorderBrush = System.Windows.Media.Brushes.Red;
                LastName.ToolTip = "The field cannot be empty.";
            }
            else
            {
                LastName.ClearValue(TextBox.BorderBrushProperty);
                LastName.ToolTip = null;
            }
        }

        private void SaveCVButton_Click(object sender, RoutedEventArgs e)
        {
            string firstName = FirstName.Text;
            string lastName = LastName.Text;
            string phoneNumber = PhoneTextBox.Text;
            string email = EmailTextBox.Text;
            DateTime? dateOfBirth = DatePicker.SelectedDate;
            string shortInfo = ShortInfoTextBox.Text;
            string experience = ExperienceTextBox.Text;

            if (string.IsNullOrWhiteSpace(firstName) || string.IsNullOrWhiteSpace(lastName) ||
                string.IsNullOrWhiteSpace(phoneNumber) || string.IsNullOrWhiteSpace(email) ||
                !dateOfBirth.HasValue || string.IsNullOrWhiteSpace(shortInfo) || string.IsNullOrWhiteSpace(experience))
            {
                MessageBox.Show("Please fill in all fields before saving.");
                return;
            }

            string cvData = $"First Name: {firstName}\n" +
                            $"Last Name: {lastName}\n" +
                            $"Phone Number: {phoneNumber}\n" +
                            $"Email: {email}\n" +
                            $"Date of Birth: {dateOfBirth.Value.ToShortDateString()}\n" +
                            $"Short Info: {shortInfo}\n" +
                            $"Experience: {experience}";

            try
            {
                string filePath = "CV_Data.txt";
                File.WriteAllText(filePath, cvData);
                MessageBox.Show("CV data has been saved successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while saving CV data: {ex.Message}");
            }
        }
    }
}
