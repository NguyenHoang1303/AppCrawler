using BotHandlerSourceParent.App;
using BotHandlerSourceParent.Queue;
using BotHandlerSourceParent.Repository;
using System.Threading.Tasks;

namespace BotHandlerSourceParent
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var cronJopApp = new CronJopApp();
            await cronJopApp.Run();
        }
    }
}
