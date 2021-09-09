using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.EntityFramework
{
    public static class MyInitializer 
    {
        public static void Initialize(DatabaseContext context)
        {
            int i;
            Random rnd = new Random();

            context.Database.EnsureCreated();
            if (context.User.Any())
            {
                return;
            }

            User firstUser = new User()
            {
                Name = "Baris",
                Surname = "Kocaman",
                Username = "baris_kcmn",
                Email = "bariskocaman5592@gmail.com",
                IsActive = true,
                Password = "123",
            };

            context.User.Add(firstUser);
            context.SaveChanges();

            for (i = 0; i < 10; i++)
            {
                User user = new User()
                {
                    Name = FakeData.NameData.GetFirstName(),
                    Surname = FakeData.NameData.GetSurname(),
                    Username = $"user{i}",
                    Email = FakeData.NetworkData.GetEmail(),
                    Password = "123",
                    IsActive = true
                };

                context.User.Add(user);
                context.SaveChanges();
            }

            

            for(i = 0; i < 50; i++)
            {
                Todo todo = new Todo()
                {
                    Description = FakeData.TextData.GetSentence(),
                    IsDone = false,
                    OwnerId = rnd.Next(1, 11),
                };

                context.Todo.Add(todo);
                context.SaveChanges();
            }
        
        }       
    }
}
