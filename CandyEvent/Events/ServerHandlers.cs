namespace CandyEvent.Events
{
    public class ServerHandlers
    {       
        public void OnRestartingRound()
        {
            Plugin.Singleton._management.StopCandyEvent();
        }
    }
}
