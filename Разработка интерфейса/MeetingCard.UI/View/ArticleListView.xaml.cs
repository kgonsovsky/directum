using System.Windows;
using System.Windows.Controls;
using MeetingCard.UI.ViewModel;

namespace MeetingCard.UI.View
{
    /// <summary>
    /// Логика взаимодействия для ArticleListView.xaml
    /// </summary>
    public partial class ArticleListView : UserControl
    {
        public ArticleListView()
        {
            InitializeComponent();
        }

        private void btnAddArticle_Click(object sender, RoutedEventArgs e)
        {
            var view = new ArticleView();
            var articleViewModel = new ArticleViewModel()
            {
                Researcher = (ResearcherViewModel)DataContext,
                Mode = Mode.Add
            };

            view.DataContext = articleViewModel;
            view.ShowDialog();
        }

        private void btnEditArticle_Click(object sender, RoutedEventArgs e)
        {
            var view = new ArticleView();
            var articleViewModel = (ArticleViewModel)((Button)sender).DataContext;
            articleViewModel.Mode = Mode.Edit;
            view.DataContext = articleViewModel;
            view.ShowDialog();
        }
    }
}
