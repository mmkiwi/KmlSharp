using Microsoft.UI.Xaml.Controls;

using MMKiwi.KMZipper.GUI.ViewModels;

using System;

namespace MMKiwi.KMZipper.GUI.Views
{
    public sealed partial class ProgressPage : Page
    {
        public ProgressViewModel ViewModel { get; }

        public ProgressPage()
        {
            ViewModel = App.GetService<ProgressViewModel>() ?? throw new InvalidOperationException($"Could not get {nameof(ProgressViewModel)}");
            InitializeComponent();
        }
    }
}
