using System.Threading.Tasks;

namespace MMKiwi.KMLZipper.GUI.Activation
{
    public interface IActivationHandler
    {
        bool CanHandle(object args);

        Task HandleAsync(object args);
    }
}
