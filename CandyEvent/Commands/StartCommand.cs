using CommandSystem;
using Exiled.Permissions.Extensions;
using System;

namespace CandyEvent.Commands
{
    public class StartCommand : ICommand
    {
        public string Command => "start";
        public string[] Aliases => new string[] { };
        public string Description => "Запускает ивент с конфетами: интервал по умолчанию " + Plugin.Singleton.Config.CandyInterval + " сек";

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            if (!sender.CheckPermission($"{MainCommand.Prefix}.{Command}"))
            {
                response = MainCommand.NotPermissionMessage;
                return false;
            }

            if (Plugin.Singleton._candyCoroutine.IsRunning)
            {
                response = "Таймер запущен!";
                return false;
            }

            int? interval = null;

            if (arguments.Count > 0 && int.TryParse(arguments.At(0), out int parsedInterval))
            {
                interval = parsedInterval;
            }

            Plugin.Singleton._management.StartCandyEvent(interval);
            response = $"Ивент запущен с интервалом {interval ?? Plugin.Singleton.Config.CandyInterval} сек";
            return true;
        }
    }
}
