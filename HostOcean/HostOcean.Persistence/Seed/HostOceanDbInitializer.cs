using HostOcean.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HostOcean.Persistence.Seed
{
    public class HostOceanDbInitializer
    {
        private readonly List<Group> Groups = new List<Group>();
        private readonly List<User> Users = new List<User>();
        private readonly List<LaboratoryWork> LaboratoryWorks = new List<LaboratoryWork>();
        private readonly List<Queue> Queues = new List<Queue>();

        public static void Initialize(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetRequiredService<HostOceanDbContext>();
            context.Database.Migrate();

            new HostOceanDbInitializer().Seed(context);
        }

        public void Seed(HostOceanDbContext context)
        {
            SeedGroups(context);
            SeedLabworks(context);
            SeedUsers(context);
            SeedQueues(context);
            SeedPlaces(context);

            context.SaveChanges();
        }

        public void SeedGroups(HostOceanDbContext context)
        {
            if (!context.Groups.Any())
            {
                var groups = new[]
                {
                    new Group()
                    {
                        Name = "650505",
                    }
                };

                Groups.AddRange(groups);
                context.Groups.AddRange(groups);
            }
        }

        public void SeedLabworks(HostOceanDbContext context)
        {
            if (!context.LaboratoryWorks.Any())
            {
                var group = Groups.First();

                var labworks = new[]
                {
                    new LaboratoryWork()
                    {
                        Title = "admin",
                        Group = group
                    }
                };

                LaboratoryWorks.AddRange(labworks);
                context.LaboratoryWorks.AddRange(labworks);
            }
        }

        public void SeedUsers(HostOceanDbContext context)
        {
            if (!context.Users.Any())
            {
                var group = Groups.First();

                var users = new[]
                {
                    new User()
                    {
                        UserName = "admin",
                        Group = group
                    }
                };

                Users.AddRange(users);
                context.Users.AddRange(users);
            }
        }

        public void SeedQueues(HostOceanDbContext context)
        {
            if (!context.Queues.Any())
            {
                var labwork = LaboratoryWorks.First();

                var queues = new[]
                {
                    new Queue()
                    {
                        LaboratoryWork = labwork
                    }
                };

                Queues.AddRange(queues);
                context.Queues.AddRange(queues);
            }
        }

        public void SeedPlaces(HostOceanDbContext context)
        {
            if (!context.UserQueues.Any())
            {
                var queue = Queues.First();
                var user = Users.First();

                var places = new[]
                {
                    new UserQueue()
                    {
                        Order = 1,
                        Queue = queue,
                        User = user
                    }
                };

                context.UserQueues.AddRange(places);
            }
        }
    }
}