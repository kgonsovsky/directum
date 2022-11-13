using MeetingCard.UI.Interface;

namespace MeetingCard.UI.Service
{
    public class ServiceProvider
    {
        public static IServiceLocator Instance { get; private set; }

        public static void RegisterServiceLocator(IServiceLocator s)
        {
            Instance = s;
        }
    }
}