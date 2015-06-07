using Caliburn.Micro;
using System;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using System.Collections.Generic;
using SevenDigital.Client;
using SevenDigital.App.ViewModels;
using SevenDigital.App.Views;
using Windows.UI.ViewManagement;
using Windows.ApplicationModel.Core;
using Windows.UI;
using Windows.UI.Core;
using Windows.Phone.UI.Input;
using Windows.Foundation.Metadata;

namespace SevenDigital.App
{
    public sealed partial class App
    {
        private WinRTContainer container;
        private INavigationService navigationSerivce;

        public App()
        {
            InitializeComponent();
        }

        protected override void Configure()
        {
            container = new WinRTContainer();

            container.RegisterWinRTServices();

            container.Singleton<ISevenDigitalClient, SevenDigitalClient>();

            container
                .PerRequest<ChartViewModel>()
                .PerRequest<ReleaseDetailsViewModel>();

            ConfigureWindow();
            ConfigureHardware();
        }

        private void ConfigureWindow()
        {
            var applicationView = ApplicationView.GetForCurrentView();
            var coreApplicationView = CoreApplication.GetCurrentView();
        }

        private void ConfigureHardware()
        {
            if (ApiInformation.IsTypePresent(typeof(HardwareButtons).FullName))
            {
                HardwareButtons.BackPressed += (s, e) =>
                {
                    if (navigationSerivce.CanGoBack)
                    {
                        e.Handled = true;
                        navigationSerivce.GoBack();
                    }
                };
            }
        }

        protected override void PrepareViewFirst(Frame rootFrame)
        {
            navigationSerivce = container.RegisterNavigationService(rootFrame);
        }

        protected override void OnLaunched(LaunchActivatedEventArgs args)
        {
            DisplayRootView<ChartView>();
        }

        protected override object GetInstance(Type service, string key)
        {
            return container.GetInstance(service, key);
        }

        protected override IEnumerable<object> GetAllInstances(Type service)
        {
            return container.GetAllInstances(service);
        }

        protected override void BuildUp(object instance)
        {
            container.BuildUp(instance);
        }
    }
}
