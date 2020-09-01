using System.Linq;
using System.Threading.Tasks;
using Application.App.Services;
using DSharpPlus.CommandsNext;
using DSharpPlus.Entities;

namespace Application.App.Handlers
{
    public class TestHandler
    {
        private readonly TestService _service;

        public TestHandler() => _service = new TestService();

        public async Task<DiscordEmbed> GetWorkingEmbed()
        {
            var message = _service.GetTestMessage();

            return new DiscordEmbedBuilder
                {
                    Color = DiscordColor.Cyan,
                    Title = "Response",
                    Description = message,
                }
                .Build();
        }

        public async Task<DiscordEmbed> CreateTest(string title, string desc)
        {
            var test = await _service.CreateTest(title, desc);

            return new DiscordEmbedBuilder
                {
                    Color = DiscordColor.Gold,
                    Title = $"{test.Id}: {test.Title}",
                    Description = test.Description,
                }
                .Build();
        }

        public async Task<DiscordEmbed> GetTestsWhereTitleContains(string contains)
        {
            var tests = await _service.GetTestsWhereTitleContains(contains);
            var list = tests.ToList();

            var embedBuilder = new DiscordEmbedBuilder
            {
                Color = DiscordColor.Gold,
                Title = $"Found: {list.Count}",
            };

            list.ForEach(test =>
            {
                embedBuilder.AddField($"{test.Id}: {test.Title}", test.Description);
            });

            return embedBuilder.Build();
        }
    }
}