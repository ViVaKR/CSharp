using Discord.Commands;
using Discord.WebSocket;

namespace Blog.ViV.Bot
{

    public class DiscordBot
    {
        public DiscordSocketClient Client { get; set; }
        public CommandService Commands { get; set; }
        private const string token = "토큰번호";

        public DiscordBot()
        {
            Client = new DiscordSocketClient(new DiscordSocketConfig
            {
                LogLevel = Discord.LogSeverity.Verbose
            });

            Commands = new CommandService(new CommandServiceConfig
            {
                LogLevel = Discord.LogSeverity.Info,
                CaseSensitiveCommands = false
            });

            Client.Log += Client_Log;
            Commands.Log += Commands_Log;
        }

        public async void Start()
        {
            await Client.LoginAsync(Discord.TokenType.Bot, token);
            await Client.StartAsync();

            Client.MessageReceived += Client_MessageReceived;

            // Wait infinitely so your bot actually stays connectd
            await Task.Delay(Timeout.Infinite);
        }

        private async Task Client_MessageReceived(SocketMessage arg)
        {
            if (arg is not SocketUserMessage message) return;

            Console.WriteLine($"== {arg.CleanContent} ==");
            int pos = 0;

            if (!message.HasMentionPrefix(Client.CurrentUser, ref pos)
                || message.Author.IsBot) return;

            SocketCommandContext context = new SocketCommandContext(Client, message);

            await context.Channel.SendMessageAsync($"{DateTime.Now} 회신: {message.CleanContent}");

        }

        private Task Commands_Log(Discord.LogMessage arg)
        {
            Console.WriteLine(arg.ToString());
            return Task.CompletedTask;
        }

        private Task Client_Log(Discord.LogMessage arg)
        {
            Console.WriteLine(arg.ToString());
            return Task.CompletedTask;
        }
    }
}
