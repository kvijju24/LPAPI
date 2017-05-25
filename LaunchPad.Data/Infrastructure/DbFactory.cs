using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaunchPad.Data.Infrastructure
{
    public class DbFactory : Disposable, IDbFactory
    {
        LPDataContext dbContext;
        public LPDataContext Init()
        {
            return dbContext ?? (dbContext = new LPDataContext());
        }
        protected override void DisposeCore()
        {
            if (dbContext != null)
                dbContext.Dispose();
        }
    }
}
