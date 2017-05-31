using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaunchPad.Data.Infrastructure
{
    //public interface IDbFactory : IDisposable
    //{
    //    ClientDataContext Init();
    //}
    public interface IDbFactory<U> where U : DbContext, IDisposable
    {
        U Init();
    }
}
