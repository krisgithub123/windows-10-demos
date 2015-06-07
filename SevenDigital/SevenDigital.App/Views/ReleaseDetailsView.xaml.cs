using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace SevenDigital.App.Views
{
    public sealed partial class ReleaseDetailsView
    {
        public ReleaseDetailsView()
        {
            InitializeComponent();

            Loaded += (s, e) => Window.Current.SizeChanged += OnWindowSizeChanged;
            Unloaded += (s, e) => Window.Current.SizeChanged -= OnWindowSizeChanged;
        }

        private void OnWindowSizeChanged(object sender, WindowSizeChangedEventArgs e)
        {
            var size = e.Size;

            var stateName = size.Width <= 500 ? "NarrowState" : "WideState";

            VisualStateManager.GoToState(this, stateName, true);
        }
    }
}
