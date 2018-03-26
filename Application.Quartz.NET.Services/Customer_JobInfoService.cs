using Application.Quartz.NET.DB;
using Application.Quartz.NET.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Application.Quartz.NET.Services
{
    public class Customer_JobInfoService
    {
        private readonly ICustomer_JobInfoRepository _repository;
        public Customer_JobInfoService(ICustomer_JobInfoRepository repository)
        {
            _repository = repository;
        }

        public int AddCustomerJobInfo(Customer_JobInfo customerJobInfoModel)
        {
            return _repository.AddCustomerJobInfo(customerJobInfoModel);
        }

        public int UpdateCustomerJobInfo(Customer_JobInfo customerJobInfoModel)
        {
            return _repository.UpdateCustomerJobInfo(customerJobInfoModel);
        }

        public Tuple<IQueryable<Customer_JobInfo>, int> LoadCustomerInfoes<K>(Expression<Func<Customer_JobInfo, bool>> whereLambda, Expression<Func<Customer_JobInfo, K>> orderByLambda, bool isAsc, int pageIndex, int pageSize)
        {
            return _repository.LoadCustomerInfoes<K>(whereLambda, orderByLambda, isAsc, pageIndex, pageSize);
        }
        public Customer_JobInfo LoadCustomerInfo(Expression<Func<Customer_JobInfo, bool>> whereLambda)
        {
            return _repository.LoadCustomerInfo(whereLambda);
        }
    }
}
