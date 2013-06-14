namespace IdeablogClear.Migrations
{
    using IdeablogClear.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<IdeablogClear.Models.IbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(IdeablogClear.Models.IbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            context.Users.AddOrUpdate(
                u => u.Name,
                new User { Name = "Jan Testowy", Language = "he" }
            );

            context.Topics.AddOrUpdate(
                t => t.TopicId,
                new Topic { Title = "Seeded topic", Content = "Seeded content", CreatedBy = context.Users.FirstOrDefault() }
                );

            context.Replies.AddOrUpdate(
                r => r.ReplyId,
                new Reply { Topic = context.Topics.FirstOrDefault(), Content = "Seeded reply", CreatedBy = context.Users.FirstOrDefault() }
                );
        }
    }
}
