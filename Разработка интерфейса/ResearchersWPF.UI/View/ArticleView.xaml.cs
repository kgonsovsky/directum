using System.Windows;

namespace ResearchersWPF.UI.View
{
    /// <summary>
    /// Логика взаимодействия для ArticleView.xaml
    /// </summary>
    public partial class ArticleView : Window
    {
        public ArticleView()
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
