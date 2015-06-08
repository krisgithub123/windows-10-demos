using Caliburn.Micro;
using SevenDigital.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Data.Xml.Dom;
using Windows.Storage;
using Windows.UI;
using Windows.UI.Notifications;
using Windows.UI.StartScreen;

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

        public async void Pin()
        {
            var tileId = Artist.Id.ToString();

            var tile = new SecondaryTile(tileId)
            {
                DisplayName = Artist.Name,
                VisualElements =
                {
                    BackgroundColor = Color.FromArgb(255, 7, 96, 110),
                    Square150x150Logo = new Uri("ms-appx:///Assets/Logo.png"),
                    ShowNameOnSquare150x150Logo = true,
                    Wide310x150Logo = new Uri("ms-appx:///Assets/WideLogo.png"),
                    ShowNameOnWide310x150Logo = true,
                    ForegroundText = ForegroundText.Light
                },
                Arguments = Artist.Id.ToString()
            };

            await tile.RequestCreateAsync();

            var updater = TileUpdateManager.CreateTileUpdaterForSecondaryTile(tileId);
            var template = await GetTemplateDocumentAsync();

            var notification = new TileNotification(template);

            updater.Update(notification);
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

        private async Task<XmlDocument> GetTemplateDocumentAsync()
        {
            var uri = new Uri("ms-appx:///assets/adaptivetemplate.xml");
            var file = await StorageFile.GetFileFromApplicationUriAsync(uri);
            var xml = await FileIO.ReadTextAsync(file);

            xml = String.Format(xml, Artist.Image, Artist.Name, "Lorem ipsum dolor sit amet, consectetur adipiscing elit.");

            var document = new XmlDocument();

            document.LoadXml(xml);

            return document;
        }
    }
}
