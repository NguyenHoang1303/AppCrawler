using Quartz;
using Quartz.Impl;
using System;
using System.Threading.Tasks;

namespace BotHandlerSourceSub.App
{
    class CronJopApp
    {
        private StdSchedulerFactory factory;
        private IScheduler scheduler;
        private IJobDetail job;
        private ITrigger trigger;


        public CronJopApp()
        {
            factory = new StdSchedulerFactory();
        }
         
        public async Task Run()
        {
            // Grab the Scheduler instance from the Factory
            scheduler = await factory.GetScheduler();
            // and start it off
            await scheduler.Start();

            // define the job and tie it to our HelloJob class
            job = JobBuilder.Create<BotArticle>()
                                        .WithIdentity("JobHandlerSource", "groupSource")
                                        .Build();

            // Trigger the job to run now, and then repeat every 5 seconds
            trigger = TriggerBuilder.Create()
                                        .WithIdentity("trigger1", "groupSource")
                                        .StartNow()
                                        .WithSimpleSchedule(x => x
                                            .WithIntervalInSeconds(5)
                                            .RepeatForever())
                                        .Build();

            // Tell quartz to schedule the job using our trigger
            await scheduler.ScheduleJob(job, trigger);

            //some sleep to show what's happening
            await Task.Delay(TimeSpan.FromSeconds(5));

            // and last shut down the scheduler when you are ready to close your program
            await scheduler.Shutdown();
        }

    }
}
