using System.Linq;
using System.Threading.Tasks;
using Application.App.Handlers;
using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;

namespace Application.App.Controllers
{
    [RequirePermissions(Permissions.Administrator)]
    [Group("test")]
    public class TestController : Executor
    {
        private readonly TestHandler _handler;

        public TestController() => _handler = new TestHandler();

        [Command("working")]
        public async Task Working(CommandContext ctx)
        {
            await Execute(async () => await ctx.RespondAsync(embed: await _handler.GetWorkingEmbed()));
        }

        [Command("create")]
        public async Task Create(CommandContext ctx, string title, string desc)
        {
            await Execute(async () => await ctx.RespondAsync(embed: await _handler.CreateTest(title, desc)));
        }

        [Command("find")]
        public async Task Find(CommandContext ctx, string contains)
        {
            await Execute(async () =>
                await ctx.RespondAsync(embed: await _handler.GetTestsWhereTitleContains(contains))
            );
        }
    }
}