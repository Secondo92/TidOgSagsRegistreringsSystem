using BLL;
using DAL.Models;
using DTO.Models;
using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace WPFApp
{
    public partial class MainWindow : Window
    {
        public ObservableCollection<EmployeeDTO> Employees { get; set; } = new ObservableCollection<EmployeeDTO>();
        public ObservableCollection<CaseDTO> Cases { get; set; } = new ObservableCollection<CaseDTO>();

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

            OverviewEmployeeDropDown.ItemsSource = Employees;
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

        private void AddCase_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(CaseNumberTextBox.Text))
            {
                MessageBox.Show("Sagsnummer må ikke være tomt.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(HeadlineTextBox.Text))
            {
                MessageBox.Show("Overskrift må ikke være tom.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(DescriptionTextBox.Text))
            {
                MessageBox.Show("Beskrivelse må ikke være tom.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (CaseDepartmentDropDown.SelectedIndex < 0)
            {
                MessageBox.Show("Vælg en gyldig afdeling.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            try
            {
                var caseItem = new CaseDTO
                {
                    CaseNumber = int.Parse(CaseNumberTextBox.Text),
                    Headline = HeadlineTextBox.Text,
                    Description = DescriptionTextBox.Text,
                    DepartmentName = CaseDepartmentDropDown.Text
                };

                CaseBLL.CreateCase(caseItem);
                LoadData();

                MessageBox.Show("Sag er blevet tilføjet", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Der opståd en fejl: {ex.Message}\n{ex.InnerException?.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
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
                MessageBox.Show("Vælg venligst en medarbejder fra listen.");
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
                MessageBox.Show("Vælg venligst en medarbejder fra listen.");
            }
        }

        private void OpenEditCaseWindow_Click(object sender, RoutedEventArgs e)
        {

            var button = sender as Button;
            var selectedCase = button?.Tag as CaseDTO;

            if (selectedCase == null)
            {
                MessageBox.Show("Kunne ikke finde den valgte case.", "Fejl", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            var editCaseWindow = new EditCaseWindow(selectedCase.CaseNumber);
            if (editCaseWindow.ShowDialog() == true)
            {;
                selectedCase.Headline = editCaseWindow.CurrentCase.Headline;
                selectedCase.Description = editCaseWindow.CurrentCase.Description;

                Cases = new ObservableCollection<CaseDTO>(Cases);
                DataContext = this;
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
                MessageBox.Show("Vælg venligst en medarbejder fra listen.");
            }
        }
    }
}
