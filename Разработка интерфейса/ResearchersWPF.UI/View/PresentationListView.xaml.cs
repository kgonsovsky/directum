using System.Windows;
using System.Windows.Controls;
using ResearchersWPF.UI.ViewModel;

namespace ResearchersWPF.UI.View
{
    /// <summary>
    /// Логика взаимодействия для PresentationListView.xaml
    /// </summary>
    public partial class PresentationListView : UserControl
    {
        public PresentationListView()
        {
            InitializeComponent();
        }

        private void btnAddPresentation_Click(object sender, RoutedEventArgs e)
        {
            var view = new PresentationView();
            var presentationViewModel = new PresentationViewModel()
            {
                Researcher = (ResearcherViewModel)DataContext,
                Mode = Mode.Add
            };

            view.DataContext = presentationViewModel;
            view.ShowDialog();
        }

        private void btnEditPresentation_Click(object sender, RoutedEventArgs e)
        {
            var view = new PresentationView();
            var presentationViewModel = (PresentationViewModel)((Button)sender).DataContext;
            presentationViewModel.Mode = Mode.Edit;
            view.DataContext = presentationViewModel;
            view.ShowDialog();
        }
    }
}
