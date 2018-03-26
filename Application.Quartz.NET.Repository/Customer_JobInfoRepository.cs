using Application.Quartz.NET.DB;
using Application.Quartz.NET.Interface;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace Application.Quartz.NET.Repository
{
    public class Customer_JobInfoRepository: ICustomer_JobInfoRepository
    {
        private readonly QuartzDBEntities _dbContext;
        public Customer_JobInfoRepository()
        {
            _dbContext = DbContextFactory.DbContext;
        }

        public int AddCustomerJobInfo(Customer_JobInfo entity)
        {
            var customerJobInfoModel = _dbContext.Customer_JobInfo.Add(new Customer_JobInfo
            {
                CreateTime = DateTimeOffset.Now,
                Cron = entity.Cron,
                Description = entity.Description,
                JobGroupName = entity.JobGroupName,
                JobName = entity.JobName,
                TriggerState = -1,
                TriggerName = entity.TriggerName,
                TriggerGroupName = entity.TriggerGroupName,
                DLLName = "Application.Quartz.NET.Base.dll",
                FullJobName = "Application.Quartz.NET.Base.UrlBaseJob",
                RequestUrl = entity.RequestUrl,
                Deleted = false
            });
            _dbContext.SaveChanges();
            return customerJobInfoModel.Id;
        }

        public int UpdateCustomerJobInfo(Customer_JobInfo customerJobInfoModel)
        {

            _dbContext.SaveChanges();
            return customerJobInfoModel.Id;
        }

        public Tuple<IQueryable<Customer_JobInfo>, int> LoadCustomerInfoes<K>(Expression<Func<Customer_JobInfo, bool>> whereLambda, Expression<Func<Customer_JobInfo, K>> orderByLambda, bool isAsc, int pageIndex, int pageSize)
        {
            int totalCount = 0;
            var customerJobInfoModelQueryable = _dbContext.Customer_JobInfo.Where(whereLambda);

            totalCount = customerJobInfoModelQueryable.Count();
            return new Tuple<IQueryable<Customer_JobInfo>, int>(isAsc ? customerJobInfoModelQueryable.OrderBy(orderByLambda).Skip(pageIndex - 1).Take(pageSize) : customerJobInfoModelQueryable.OrderByDescending(orderByLambda).Skip((pageIndex - 1) * pageSize).Take(pageSize), totalCount);

        }
        public Customer_JobInfo LoadCustomerInfo(Expression<Func<Customer_JobInfo, bool>> whereLambda)
        {
            return _dbContext.Customer_JobInfo.SingleOrDefault(whereLambda);
        }
    }
}
