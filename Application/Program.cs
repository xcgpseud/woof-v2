using System;
using Application.App;

namespace Application
{
    class Program
    {
        static void Main(string[] args)
        {
            Bot.Make().Start().ConfigureAwait(false).GetAwaiter().GetResult();
        }
    }
}