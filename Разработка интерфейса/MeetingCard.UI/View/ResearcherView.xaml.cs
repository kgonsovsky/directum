using System.Windows;

namespace MeetingCard.UI.View
{
    /// <summary>
    /// Логика взаимодействия для ResearcherView.xaml
    /// </summary>
    public partial class ResearcherView : Window
    {
        public ResearcherView()
        {
            InitializeComponent();
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
