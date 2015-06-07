using Caliburn.Micro;
using SevenDigital.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SevenDigital.App.ViewModels
{
    public class ReleaseDetailsViewModel : Screen
    {
        private readonly ISevenDigitalClient sevenDigitalClient;
        private readonly INavigationService navigationService;

        private Artist artist;
        private Release release;

        public ReleaseDetailsViewModel(ISevenDigitalClient sevenDigitalClient, INavigationService navigationService)
        {
            this.sevenDigitalClient = sevenDigitalClient;
            this.navigationService = navigationService;
        }

        protected override async void OnInitialize()
        {
            base.OnInitialize();

            Artist = await sevenDigitalClient.GetArtistDetailsAsync(ArtistId);
            Release = await sevenDigitalClient.GetReleaseDetailsAsync(ReleaseId);
        }

        public void GoBack()
        {
            navigationService.GoBack();
        }

        public int ReleaseId { get; set; }
        public int ArtistId { get; set; }

        public Artist Artist
        {
            get { return artist; }
            set
            {
                artist = value;
                NotifyOfPropertyChange(nameof(Artist));
            } 
        }

        public Release Release
        {
            get { return release; }
            set
            {
                release = value;
                NotifyOfPropertyChange(nameof(Release));
            }
        }
    }
}
