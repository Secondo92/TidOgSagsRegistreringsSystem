using BLL;
using DTO.Models;
using System.Windows;

namespace WPFApp
{
    /// <summary>
    /// Interaction logic for EditCaseWindow.xaml
    /// </summary>
    public partial class EditCaseWindow : Window
    {
        public CaseDTO CurrentCase { get; private set; }
        public EditCaseWindow(int caseToEditId)
        {
            InitializeComponent();

            CurrentCase = CaseBLL.GetCaseById(caseToEditId);

            HeadlineTextBox.Text = CurrentCase.Headline;
            DescriptionTextBox.Text = CurrentCase.Description;

            CaseDepartmentDropDown.Text = CurrentCase.DepartmentName;
        }
        private void EditCaseOk_Click(object sender, RoutedEventArgs e)
        {

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

            CurrentCase.Headline = HeadlineTextBox.Text;
            CurrentCase.Description = DescriptionTextBox.Text;
            CurrentCase.DepartmentName = CaseDepartmentDropDown.Text;

            CaseBLL.UpdateCase(CurrentCase);

            this.DialogResult = true;
            this.Close();
        }

        private void EditCaseCancel_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }
    }
}
