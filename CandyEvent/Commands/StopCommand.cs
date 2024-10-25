using CommandSystem;
using Exiled.Permissions.Extensions;
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
            if (!sender.CheckPermission($"{MainCommand.Prefix}.{Command}"))
            {
                response = MainCommand.NotPermissionMessage;
                return false;
            }

            if (!Plugin.Singleton._candyCoroutine.IsRunning)
            {
                response = "Ивент не запущен!";
                return false;
            }

            Plugin.Singleton._management.StopCandyEvent(); 
            response = "Ивент остановлен";
            return true;
        }
    }
}
