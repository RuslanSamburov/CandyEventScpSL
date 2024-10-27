using CommandSystem;
using Exiled.Permissions.Extensions;
using System;

namespace CandyEvent.Commands
{
    public class StartCommand : ICommand
    {
        public string Command => "start";
        public string[] Aliases => new string[] { };
        public string Description => $"Запускает ивент с конфетами: {{time:{Plugin.Singleton.Config.CandyInterval}}} {{candyCount:{Plugin.Singleton.Config.CountCandy}}}";

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            if (!sender.CheckPermission($"{MainCommand.Prefix}.{Command}"))
            {
                response = MainCommand.NotPermissionMessage;
                return false;
            }

            if (Plugin.Singleton._candyCoroutine.IsRunning)
            {
                response = "Ивент запущен!";
                return false;
            }

            int interval = Plugin.Singleton.Config.CandyInterval;
            int countCandy = Plugin.Singleton.Config.CountCandy;

            if (arguments.Count > 0 && int.TryParse(arguments.At(0), out int parsedInterval))
            {
                interval = parsedInterval;
            }

            if (arguments.Count > 1 && int.TryParse(arguments.At(1), out int parsedCountCandy))
            {
                countCandy = parsedCountCandy;
            }

            Plugin.Singleton._management.StartCandyEvent(interval, countCandy);
            response = $"Ивент запущен\n- Интервал: {interval} сек\n- Количество конфет: {countCandy} шт";
            return true;
        }
    }
}
