using BLL;
using DTO.Models;
using System;
using System.Collections.ObjectModel;
using System.Windows;

namespace WPFApp
{
    public partial class MainWindow : Window
    {
        public ObservableCollection<EmployeeDTO> Employees { get; set; } = new ObservableCollection<EmployeeDTO>();
        public ObservableCollection<CaseDTO> Cases { get; set; } = new ObservableCollection<CaseDTO>();
        public ObservableCollection<TimeRegistrationDTO> TimeRegistrations { get; set; } = new ObservableCollection<TimeRegistrationDTO>();

        public MainWindow()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            Employees = new ObservableCollection<EmployeeDTO>(EmployeeBLL.GetAllEmployees());
            Cases = new ObservableCollection<CaseDTO>(CaseBLL.GetAllCases());
            DataContext = this;

            EmployeeDropDown.ItemsSource = Employees;
            OverviewEmployeeDropDown.ItemsSource = Employees;
            CaseDropDown.ItemsSource = Cases;
        }

        private void AddEmployee_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(CprTextBox.Text))
            {
                MessageBox.Show("CPR-nummer må ikke være tomt.", "Advarsel", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(NameTextBox.Text))
            {
                MessageBox.Show("Navn må ikke være tomt.", "Advarsel", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (DepartmentDropDown.SelectedIndex < 0)
            {
                MessageBox.Show("Vælg en gyldig afdeling.", "Advarsel", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            try
            {
                var employee = new EmployeeDTO
                {
                    CprNumber = CprTextBox.Text,
                    Name = NameTextBox.Text,
                    DepartmentName = DepartmentDropDown.Text
                };

                EmployeeBLL.CreateEmployee(employee);
                LoadData();

                MessageBox.Show("Medarbejder tilføjet!", "Succes", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Der opstod en fejl: {ex.Message}\n{ex.InnerException?.Message}", "Fejl", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


        private void AddTimeRegistration_Click(object sender, RoutedEventArgs e)
        {
            if (EmployeeDropDown.SelectedItem == null)
            {
                MessageBox.Show("Please select an employee.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (CaseDropDown.SelectedItem == null)
            {
                MessageBox.Show("Please select a case.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            var timeRegistration = new TimeRegistrationDTO
            {
                StartTime = DateTime.Parse(StartTimeTextBox.Text),
                EndTime = DateTime.Parse(EndTimeTextBox.Text),
                EmployeeId = ((EmployeeDTO)EmployeeDropDown.SelectedItem)?.CprNumber,
                CaseNumber = ((CaseDTO)CaseDropDown.SelectedItem)?.CaseNumber
            };

            TimeRegistrationBLL.CreateTimeRegistration(timeRegistration);
            TimeRegistrations.Add(timeRegistration);
        }

        private void AddCase_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(CaseNumberTextBox.Text))
            {
                MessageBox.Show("Case number must not be empty.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(HeadlineTextBox.Text))
            {
                MessageBox.Show("Headline must not be empty.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(DescriptionTextBox.Text))
            {
                MessageBox.Show("Description must not be empty.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (CaseDepartmentDropDown.SelectedIndex < 0)
            {
                MessageBox.Show("Please select a valid department.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            try
            {
                var caseItem = new CaseDTO
                {
                    CaseNumber = int.Parse(CaseNumberTextBox.Text),
                    Headline = HeadlineTextBox.Text,
                    Description = DescriptionTextBox.Text,
                    DepartmentNumber = CaseDepartmentDropDown.SelectedIndex + 1
                };

                CaseBLL.CreateCase(caseItem);
                LoadData();

                MessageBox.Show("Case added successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}\n{ex.InnerException?.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ShowWeeklyReport_Click(object sender, RoutedEventArgs e)
        {
            var selectedEmployee = (EmployeeDTO)OverviewEmployeeDropDown.SelectedItem;
            if (selectedEmployee != null)
            {
                var report = TimeRegistrationBLL.GetWeeklySummary(selectedEmployee.CprNumber);
                ReportListView.ItemsSource = report;
            }
            else
            {
                MessageBox.Show("Please select an employee from the dropdown.");
            }
        }


        private void ShowMonthlyReport_Click(object sender, RoutedEventArgs e)
        {
            var selectedEmployee = (EmployeeDTO)OverviewEmployeeDropDown.SelectedItem;
            if (selectedEmployee != null)
            {
                var report = TimeRegistrationBLL.GetMonthlySummary(selectedEmployee.CprNumber);
                ReportListView.ItemsSource = report;
            }
            else
            {
                MessageBox.Show("Please select an employee from the dropdown.");
            }
        }

        private void ShowTotalReport_Click(object sender, RoutedEventArgs e)
        {
            var selectedEmployee = (EmployeeDTO)OverviewEmployeeDropDown.SelectedItem;
            if (selectedEmployee != null)
            {
                var report = TimeRegistrationBLL.GetTotalReport(selectedEmployee.CprNumber);
                ReportListView.ItemsSource = report;
            }
            else
            {
                MessageBox.Show("Please select an employee from the dropdown.");
            }
        }

    }
}
