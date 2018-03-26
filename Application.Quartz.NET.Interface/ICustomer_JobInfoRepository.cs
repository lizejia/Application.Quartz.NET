﻿

using Application.Quartz.NET.DB;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace Application.Quartz.NET.Interface
{
    public interface ICustomer_JobInfoRepository
    {
        /// <summary>
        /// 添加任务
        /// </summary>
        /// <param name="jobName">任务名称</param>
        /// <param name="jobGroupName">任务所在组名称</param>
        /// <param name="triggerName">触发器名称</param>
        /// <param name="triggerGroupName">触发器所在的组名称</param>
        /// <param name="cron">执行周期表达式</param>
        /// <param name="jobDescription">任务描述</param>
        /// <param name="requestUrl">请求地址</param>
        /// <returns>添加后任务编号</returns>
        int AddCustomerJobInfo(Customer_JobInfo customerJobInfoModel);
        /// <summary>
        /// 更新任务
        /// </summary>
        /// <param name="whereLambda">新的任务模型</param>
        /// <returns>更新的任务编号</returns>
        int UpdateCustomerJobInfo(Customer_JobInfo customerJobInfoModel);
        /// <summary>
        /// 加载任务列表
        /// </summary>
        /// <typeparam name="K">排序表达式返回值类型</typeparam>
        /// <param name="whereLambda">条件表达式</param>
        /// <param name="orderByLambda">排序表达式</param>
        /// <param name="isAsc">是否升序</param>
        /// <param name="pageIndex">索引页</param>
        /// <param name="pageSize">页数量</param>
        /// <returns>查询数据集和总条数</returns>
        Tuple<IQueryable<Customer_JobInfo>, int> LoadCustomerInfoes<K>(Expression<Func<Customer_JobInfo, bool>> whereLambda, Expression<Func<Customer_JobInfo, K>> orderByLambda, bool isAsc, int pageIndex, int pageSize);
        /// <summary>
        /// 加载单个任务
        /// </summary>
        /// <param name="whereLambda">条件表达式</param>
        /// <returns>单个任务</returns>
        Customer_JobInfo LoadCustomerInfo(Expression<Func<Customer_JobInfo, bool>> whereLambda);
    }
}
