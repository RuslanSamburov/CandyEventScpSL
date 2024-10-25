using CommandSystem;
using Exiled.Permissions.Extensions;
using System;

namespace CandyEvent.Commands
{
    [CommandHandler(typeof(RemoteAdminCommandHandler))]
    [CommandHandler(typeof(GameConsoleCommandHandler))]
    public class MainCommand : ParentCommand
    {
        public static string Prefix = "candy";
        public static string NotPermissionMessage = "У вас недостаточно прав";

        public MainCommand()
        {
            LoadGeneratedCommands();
        }

        public override string Command => "candyevent";

        public override string[] Aliases => new string[] { };

        public override string Description => "Управление ивентом с конфетами";

        public override void LoadGeneratedCommands()
        {
            RegisterCommand(new StartCommand());
            RegisterCommand(new StopCommand());
        }

        protected override bool ExecuteParent(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            response = "\n Доступные команды:";

            foreach (ICommand command in AllCommands)
            {
                if (sender.CheckPermission($"{Prefix}.{command.Command}"))
                {
                    response += $"\n\n- {command.Command} ({string.Join(", ", command.Aliases)})\n{command.Description}";
                }
            }

            return false;
        }
    }
}
