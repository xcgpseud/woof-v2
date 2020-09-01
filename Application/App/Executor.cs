using System;
using System.Threading.Tasks;

namespace Application.App
{
    public class Executor
    {
        protected async Task Execute(Func<Task> fn)
        {
            try
            {
                await fn();
            }
            catch (Exception ex)
            {
                // TODO: Logging
                Console.Write(ex);
                throw;
            }
        }
    }
}