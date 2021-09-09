using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.EntityFramework
{
    public class RepositoryBase
    {
        protected static DatabaseContext db;
        private static object _lockSync = new object();

        protected RepositoryBase() //constructor tekrar new lenemez
        {
            db = CreateContext();
        }

        private static DatabaseContext CreateContext()
        {
            if (db == null)
            {
                lock (_lockSync) //Multi thread kontrol. Tek tek çalışması için
                {
                    if (db == null)
                    {
                        db = new DatabaseContext();
                    }
                }
            }

            return db;
        }
    }
}
