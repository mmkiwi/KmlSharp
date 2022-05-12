using Microsoft.UI.Xaml.Controls;

using MMKiwi.KMZipper.GUI.ViewModels;
using MMKiwi.KMZipper.GUI.ViewModels.Icons;

namespace MMKiwi.KMZipper.GUI.Views;

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
