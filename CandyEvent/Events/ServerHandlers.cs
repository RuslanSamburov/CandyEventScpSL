using Exiled.Events.EventArgs.Server;

namespace CandyEvent.Events
{
    public class ServerHandlers
    {
        public void OnRoundEnded(RoundEndedEventArgs ev)
        {
            Plugin.Singleton._management.StopCandyEvent();
        }
    }
}
