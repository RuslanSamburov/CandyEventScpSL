using Exiled.API.Interfaces;

namespace CandyEvent
{
    public class Config : IConfig
    {
        public bool IsEnabled { get; set; } = true;
        public bool Debug { get; set; } = false;

        public int CandyInterval { get; set; } = 60;
        public int CountCandy { get; set; } = 1;
    }
}
