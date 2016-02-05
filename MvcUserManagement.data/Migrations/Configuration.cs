using MvcDataManager.Model;

namespace MvcUserManagement.data.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<MvcUserManagementDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(MvcUserManagementDbContext context)
        {
            //  This method will be called after migrating to the latest version.
            context.SecurityQuestion.AddOrUpdate(
                p => p.Question,
                new SecurityQuestion { Question = "What is your name?" },
                new SecurityQuestion { Question = "What is your childhood name?" }
            );
        }
    }
}
