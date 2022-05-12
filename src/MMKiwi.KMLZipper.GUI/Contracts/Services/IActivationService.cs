using System.Threading.Tasks;

namespace MMKiwi.KMLZipper.GUI.Contracts.Services
{
    public interface IActivationService
    {
        Task ActivateAsync(object activationArgs);
    }
}
