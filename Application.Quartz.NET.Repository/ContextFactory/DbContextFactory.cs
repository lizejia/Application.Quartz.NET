using Application.Quartz.NET.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Application.Quartz.NET.Repository
{
    internal class DbContextFactory
    {
        public static QuartzDBEntities DbContext
        {
            get
            {
                var _dbContext = CallContext.GetData("DbContext") as QuartzDBEntities;
                if (_dbContext == null)
                {
                    _dbContext = new QuartzDBEntities();
                    CallContext.SetData("DbContext", _dbContext);
                }
                return _dbContext;
            }

        }
    }
}
