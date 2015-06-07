using SevenDigital.App.ViewModels;
using SevenDigital.Client;

namespace SevenDigital.App.Views
{
    public sealed partial class ChartView
    {
        public ChartView()
        {
            InitializeComponent();
        }

        private ChartViewModel ViewModel
        {
            get { return (ChartViewModel)DataContext; }
        }

        private void OnReleaseClicked(object sender, Windows.UI.Xaml.Controls.ItemClickEventArgs e)
        {
            var chartItem = (ChartItem) e.ClickedItem;

            ViewModel.ViewReleaseDetails(chartItem.Release);
        }
    }
}
