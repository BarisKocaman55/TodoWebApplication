using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.EntityFramework
{
    public class DatabaseContext : DbContext
    {
       public DbSet<User> User { get; set; }
       public DbSet<Todo> Todo { get; set; }

       public DatabaseContext()
       {
            
       }

       public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
       {

       }
    }
}
