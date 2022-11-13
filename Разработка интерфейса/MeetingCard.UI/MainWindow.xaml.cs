using System.Windows;
using MeetingCard.UI.View;
using MeetingCard.UI.ViewModel;

namespace MeetingCard.UI
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
