using BotHandlerSourceSub.App;
using System.Threading.Tasks;

namespace BotHandlerSourceSub
{
    class Program
    {
        static async Task Main(string[] args)
        {
            CronJopApp cronJob = new();
            await cronJob.Run();

        }
    }
}
