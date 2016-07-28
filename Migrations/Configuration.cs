namespace Console1.Migrations
{
    using Models;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<Console1.Models.Context>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(Console1.Models.Context context)
        {

            context.Users.AddOrUpdate(x => x.Id,
              new User { Id = 1, Name = "aaa", Age = 30, Type = UserType.Admin },
              new User { Id = 2, Name = "bbb", Age = 20, Type = UserType.Ordinary },
              new User { Id = 3, Name = "ccc", Age = 25, Type = UserType.Ordinary }
            );

            context.Posts.AddOrUpdate(x => x.Id,
                new Post { Context = "ccc 1", UserId = 3 },
                new Post { Context = "bbb 1", UserId = 2 },
                new Post { Context = "bbb 2", UserId = 2 },
                new Post { Context = "aaa 1", UserId = 1 },
                new Post { Context = "bbb 3", UserId = 2 },
                new Post { Context = "ccc 2", UserId = 3 },
                new Post { Context = "ccc 3", UserId = 3 }
            );

            context.SaveChanges();
        }
    }
}
