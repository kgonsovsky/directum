using System.Windows;

namespace MeetingCard.UI.View
{
    /// <summary>
    /// Логика взаимодействия для PresentationView.xaml
    /// </summary>
    public partial class PresentationView : Window
    {
        public PresentationView()
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
