using Quartz;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Net.Http;

namespace Application.Quartz.NET.JobBase
{
    public class UrlBaseJob : IJob
    {
        public async Task Execute(IJobExecutionContext context)
        {
            try
            {
                HttpClient hc = new HttpClient();
                HttpResponseMessage responsemessage =  await hc.GetAsync(context.JobDetail.JobDataMap["requestUrl"].ToString());
                //写日志
                //responsemessage.Content
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
    }
}
