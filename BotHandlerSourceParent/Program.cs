using BotHandlerSourceParent.App;
using BotHandlerSourceParent.Queue;
using System.Threading.Tasks;

namespace BotHandlerSourceParent
{
    class Program
    {
        static async Task Main(string[] args)
        {
            //new BotApp().Start();

            var cronJopApp = new CronJopApp();
            await cronJopApp.Run();

            //new MyQueue().TestSender("hello Nguyen");
        }
    }
}
