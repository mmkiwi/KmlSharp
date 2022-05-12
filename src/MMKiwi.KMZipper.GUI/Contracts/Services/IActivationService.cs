using System.Threading.Tasks;

namespace MMKiwi.KMZipper.GUI.Contracts.Services
{
    public interface IActivationService
    {
        Task ActivateAsync(object activationArgs);
    }
}
