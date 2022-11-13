using System;
using System.Windows;
using MeetingCard.Service.Services;

namespace MeetingCard.UI.View
{
    /// <summary>
    /// Логика взаимодействия для Request.xaml
    /// </summary>
    public partial class Request : Window
    {
        public Request()
        {
            InitializeComponent();
        }

        private void Search1_Click(object sender, RoutedEventArgs e)
        {
            var requestServiceClient = new RequestService();
            SearchResult1.Text = requestServiceClient.GetPresentationRequest(DateTime1.Value ?? DateTime.Now).ToString();
        }

        private void Search2_Click(object sender, RoutedEventArgs e)
        {
            var requestServiceClient = new RequestService();
            SearchResult2.Text = requestServiceClient.GetReportRequest(Convert.ToInt32(Updown.Text)).ToString();
        }
    }
}
