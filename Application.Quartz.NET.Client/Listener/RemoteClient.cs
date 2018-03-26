using Quartz;
using Quartz.Impl;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Quartz.NET.Client.Listener
{
    public class RemoteClient
    {
        static readonly object Locker = new object();
        static IScheduler _scheduler;
        static readonly ConcurrentDictionary<string, IScheduler> ConnectionCache = new ConcurrentDictionary<string, IScheduler>();
        const string channelType = "tcp";
        const string localIp = "127.0.0.1";
        const string port = "555";
        const string bindName = "QuartzScheduler";
        public static IScheduler Instance
        {
            get
            {
                if (_scheduler == null)
                {
                    lock (Locker)
                    {
                        if (_scheduler == null)
                        {
                            GetScheduler(localIp).Wait();
                            _scheduler =  GetScheduler(localIp).GetAwaiter().GetResult();
                        }
                    }
                }
                return _scheduler;
            }
        }
        public static async Task<IScheduler> GetScheduler(string ip)
        {
            if (!ConnectionCache.ContainsKey(ip))
            {
                var properties = new NameValueCollection();
                properties["quartz.scheduler.proxy"] = "true";
                properties["quartz.scheduler.proxy.address"] = $"{channelType}://{localIp}:{port}/{bindName}";
                ISchedulerFactory sf = new StdSchedulerFactory(properties);
                IScheduler sched = await sf.GetScheduler();
                ConnectionCache[ip] = sched;
            }
            return ConnectionCache[ip];
        }

    }
}
