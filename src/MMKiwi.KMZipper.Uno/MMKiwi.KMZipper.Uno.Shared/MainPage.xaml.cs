using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using MMKiwi.KMZipper.Uno.ViewModels.Icons;
using MMKiwi.KMZipper.Uno.ViewModels;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace MMKiwi.KMZipper.Uno
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainViewModel ViewModel { get; }

        public MainPage()
        {
            ViewModel = App.GetService<MainViewModel>() ?? throw new InvalidOperationException($"Could not get {nameof(MainViewModel)}");

            InitializeComponent();
            if (Resources.TryGetValue("Icons", out object iconObj) && iconObj is IDictionary<object, object> icons)
            {
                foreach ((object key, object value) in icons)
                {
                    if (value is IIconInfo iconValue)
                    {
                        ViewModel.IconList.Add(iconValue);
                    }
                }
            }
            else
            {
                throw new Exception();
            }
        }
    }
}