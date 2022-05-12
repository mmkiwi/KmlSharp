using System.Threading.Tasks;

namespace MMKiwi.KMZipper.GUI.Activation
{
    public interface IActivationHandler
    {
        bool CanHandle(object args);

        Task HandleAsync(object args);
    }
}
