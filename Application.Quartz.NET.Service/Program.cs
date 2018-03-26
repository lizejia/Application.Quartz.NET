using Application.Quartz.NET.Base;
using Quartz;
using Quartz.Impl;
using Quartz.Impl.Matchers;
using Quartz.Logging;
using System.Collections.Specialized;
using System.Threading.Tasks;

namespace Application.Quartz.NET.Service
{
    public class Program
    {
        //ILog log = LogProvider.GetLogger(typeof(Program));
        private static void Main(string[] args)
        {
            RunProgram().GetAwaiter().GetResult();
        }


        private static async Task RunProgram()
        {
            var properties = new NameValueCollection();
            properties["quartz.scheduler.instanceName"] = "RemoteServer";
            properties["quartz.scheduler.exporter.type"] = "Quartz.Simpl.RemotingSchedulerExporter, Quartz";
            //端口号
            properties["quartz.scheduler.exporter.port"] = "555";
            //名称
            properties["quartz.scheduler.exporter.bindName"] = "QuartzScheduler";
            //通道类型
            properties["quartz.scheduler.exporter.channelType"] = "tcp";
            properties["quartz.scheduler.exporter.channelName"] = "httpQuartz";
            properties["quartz.scheduler.exporter.rejectRemoteRequests"] = "true";

            properties["quartz.serializer.type"] = "binary";
            properties["quartz.threadPool.type"] = "Quartz.Simpl.SimpleThreadPool, Quartz";
            properties["quartz.threadPool.threadCount"] = "10";
            properties["quartz.threadPool.threadPriority"] = "Normal";
            //集群配置
            properties["quartz.jobStore.clustered"] = "true";
            //存储类型
            properties["quartz.jobStore.type"] = "Quartz.Impl.AdoJobStore.JobStoreTX, Quartz";
            //数据库驱动类型
            properties["quartz.jobStore.driverDelegateType"] = "Quartz.Impl.AdoJobStore.SqlServerDelegate, Quartz";
            //表名前缀
            properties["quartz.jobStore.tablePrefix"] = "QRTZ_";
            //配置AdoJobStore以使用字符串作为JobDataMap值
            properties["quartz.jobStore.useProperties"] = "true";
            //
            properties["quartz.jobStore.misfireThreshold"] = "60000";
            //数据源名称
            properties["quartz.jobStore.dataSource"] = "myDS";
            //连接字符串
            properties["quartz.dataSource.myDS.connectionString"] = @"Data Source=localhost;Initial Catalog=QuartzDB;User ID=sa;Password=123456";
            //版本
            properties["quartz.dataSource.myDS.provider"] = "SqlServer";
            //集群中的每个节点必须具有唯一的instanceId
            properties["quartz.scheduler.instanceId"] = "AUTO";
            

            ISchedulerFactory sf = new StdSchedulerFactory(properties);
            IScheduler sched = await sf.GetScheduler();
            sched.ListenerManager.AddJobListener(new MyJobListener(), GroupMatcher<JobKey>.AnyGroup());
            await sched.Start();
        }
    }
}
