using System;
using System.Threading.Tasks;

using Microsoft.UI.Xaml;

using MMKiwi.KMZipper.GUI.Contracts.Services;
using MMKiwi.KMZipper.GUI.ViewModels;

namespace MMKiwi.KMZipper.GUI.Activation
{
    public class DefaultActivationHandler : ActivationHandler<LaunchActivatedEventArgs>
    {
        private readonly INavigationService _navigationService;

        public DefaultActivationHandler(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        protected override async Task HandleInternalAsync(LaunchActivatedEventArgs args)
        {
            _navigationService.NavigateTo(typeof(MainViewModel).FullName ?? string.Empty, args.Arguments);
            await Task.CompletedTask;
        }

        protected override bool CanHandleInternal(LaunchActivatedEventArgs args)
        {
            // None of the ActivationHandlers has handled the app activation
            return _navigationService.Frame.Content == null;
        }
    }
}
