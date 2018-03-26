using Quartz;
using System;
using System.Threading.Tasks;
using System.Threading;

namespace Application.Quartz.NET.Base
{
    /// <summary>
    /// Job监听器
    /// </summary>
    public class MyJobListener : IJobListener
    {
        public string Name
        {
            get
            {
                return "Jobs_Listener";
            }
        }
        /// <summary>
        /// 一般不调用
        /// </summary>
        /// <param name="context"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task JobExecutionVetoed(IJobExecutionContext context, CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// job执行前，调用
        /// </summary>
        /// <param name="context"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task JobToBeExecuted(IJobExecutionContext context, CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// job执行完，调用
        /// </summary>
        /// <param name="context"></param>
        /// <param name="jobException"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task JobWasExecuted(IJobExecutionContext context, JobExecutionException jobException, CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }
    }
}
