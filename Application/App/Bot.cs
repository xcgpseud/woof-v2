using System.Threading.Tasks;
using Application.App.Controllers;
using Application.App.Database;
using DSharpPlus;
using DSharpPlus.CommandsNext;

namespace Application.App
{
    public class Bot
    {
        private DiscordClient _client;
        private CommandsNextModule _commandsNext;
        private readonly Config.Config _config;

        public Bot()
        {
            _config = Config.Config.Make();

            // TODO: Ensure Created DB
            using (var db = new SqliteContext())
            {
                db.Database.EnsureCreated();
            }
        }

        public static Bot Make()
        {
            return new Bot();
        }

        public async Task Start()
        {
            _client = new DiscordClient(GetDiscordConfiguration());
            _commandsNext = _client.UseCommandsNext(GetCommandsNextConfiguration());

            _commandsNext.RegisterCommands<TestController>();

            await _client.ConnectAsync();
            await Task.Delay(-1);
        }

        public DiscordConfiguration GetDiscordConfiguration()
        {
            return new DiscordConfiguration
            {
                Token = _config.Get().Bot.Token,
                TokenType = TokenType.Bot,
                UseInternalLogHandler = true,
                LogLevel = LogLevel.Debug,
            };
        }

        public CommandsNextConfiguration GetCommandsNextConfiguration()
        {
            return new CommandsNextConfiguration
            {
                StringPrefix = _config.Get().Bot.CommandPrefix,
            };
        }
    }
}