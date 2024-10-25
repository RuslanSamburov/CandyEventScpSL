using CommandSystem;
using System;

namespace CandyEvent.Commands
{
    public class StopCommand : ICommand
    {
        public string Command => "stop";
        public string[] Aliases => new string[] { };
        public string Description => "Останавливает ивент с конфетами";

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            Plugin.Singleton._management.StopCandyEvent(); 
            response = "Ивент остановлен";
            return true;
        }
    }
}
