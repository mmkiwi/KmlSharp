// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at https://mozilla.org/MPL/2.0/.

using Microsoft.UI.Xaml.Controls;

using MMKiwi.KMZipper.Uno.ViewModels;
using MMKiwi.KMZipper.Uno.ViewModels.Icons;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace MMKiwi.KMZipper.Uno;

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
