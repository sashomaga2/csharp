using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Entity;

namespace Mvc5.Models
{
    public interface ICalcDb : IDisposable
    {
        IQueryable<T> Query<T>() where T : class;
    }
    public class CalcDb : DbContext, ICalcDb
    {
        public CalcDb() : base("name=DefaultConnection")
        {
        }

        public DbSet<Calculation> Calculations { get; set; }

        public IQueryable<T> Query<T>() where T : class
        {
            return Set<T>();
        }
    }

    
}