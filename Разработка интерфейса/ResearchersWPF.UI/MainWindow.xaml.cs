using System.Windows;
using ResearchersWPF.UI.View;
using ResearchersWPF.UI.ViewModel;

namespace ResearchersWPF.UI
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = ResearchersListViewModel.Instance();
        }

        private void OpenRequestWindow(object sender, RoutedEventArgs e)
        {
            var dialog = new Request();
            dialog.ShowDialog();
        }
    }
}
