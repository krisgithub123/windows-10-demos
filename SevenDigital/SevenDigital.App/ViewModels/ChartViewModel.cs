using Caliburn.Micro;
using SevenDigital.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SevenDigital.App.ViewModels
{
    public class ChartViewModel : Screen
    {
        private readonly ISevenDigitalClient sevenDigitalClient;
        private readonly INavigationService navigationService;

        public ChartViewModel(ISevenDigitalClient sevenDigitalClient, INavigationService navigationService)
        {
            this.sevenDigitalClient = sevenDigitalClient;
            this.navigationService = navigationService;

            Items = new BindableCollection<ChartItem>();
        }
        
        protected override async void OnInitialize()
        {
            base.OnInitialize();

            var chart = await sevenDigitalClient.GetReleaseChartAsync();

            Items.AddRange(chart.Items);
        }

        public async void RefreshChart()
        {
            Items.Clear();

            var chart = await sevenDigitalClient.GetReleaseChartAsync();

            Items.AddRange(chart.Items);
        }

        public void ViewReleaseDetails(Release release)
        {
            navigationService.UriFor<ReleaseDetailsViewModel>()
                .WithParam(v => v.ReleaseId, release.Id)
                .WithParam(v => v.ArtistId, release.Artist.Id)
                .Navigate();
        }

        public BindableCollection<ChartItem> Items { get; private set; }
    }
}
