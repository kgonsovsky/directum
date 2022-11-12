using System.Windows;

namespace ResearchersWPF.UI.View
{
    /// <summary>
    /// Логика взаимодействия для MonographView.xaml
    /// </summary>
    public partial class MonographView : Window
    {
        public MonographView()
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
