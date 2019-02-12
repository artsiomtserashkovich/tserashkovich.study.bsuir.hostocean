using HostOcean.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HostOcean.Data.Seed
{
    public class HostOceanDbInitializer
    {
        private readonly List<University> Universities = new List<University>();
        private readonly List<Faculty> Faculties = new List<Faculty>();
        private readonly List<Speciality> Specialities = new List<Speciality>();
        private readonly List<Group> Groups = new List<Group>();
        private readonly List<User> Users = new List<User>();
        private readonly List<Labwork> Labworks = new List<Labwork>();
        private readonly List<Queue> Queues = new List<Queue>();

        public static void Initialize(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetRequiredService<HostOceanDbContext>();
            context.Database.Migrate();

            new HostOceanDbInitializer().Seed(context);
        }

        public void Seed(HostOceanDbContext context)
        {
            SeedUniversities(context);
            SeedFaculties(context);
            SeedSpecialities(context);
            SeedGroups(context);
            SeedLabworks(context);
            SeedUsers(context);
            SeedQueues(context);
            SeedPlaces(context);

            context.SaveChanges();
        }

        public void SeedUniversities(HostOceanDbContext context)
        {
            if (!context.Universities.Any())
            {
                var universities = new[]
                {
                    new University()
                };

                Universities.AddRange(universities);

                context.Universities.AddRange(universities);
            }
        }

        public void SeedFaculties(HostOceanDbContext context)
        {
            if (!context.Faculties.Any())
            {
                var university = Universities.First();

                var faculties = new[]
                {
                    new Faculty()
                    {
                        Name = "FKSIS",
                        University = university
                    }
                };

                Faculties.AddRange(faculties);
                context.Faculties.AddRange(faculties);
            }
        }

        public void SeedSpecialities(HostOceanDbContext context)
        {
            if (!context.Specialities.Any())
            {
                var faculty = Faculties.First();

                var specialities = new[]
                {
                    new Speciality()
                    {
                        Name = "VMSIS",
                        Faculty = faculty
                    }
                };

                Specialities.AddRange(specialities);
                context.Specialities.AddRange(specialities);
            }
        }

        public void SeedGroups(HostOceanDbContext context)
        {
            if (!context.Groups.Any())
            {
                var speciality = Specialities.First();

                var groups = new[]
                {
                    new Group()
                    {
                        Name = "650505",
                        Speciality = speciality
                    }
                };

                Groups.AddRange(groups);
                context.Groups.AddRange(groups);
            }
        }

        public void SeedLabworks(HostOceanDbContext context)
        {
            if (!context.Labworks.Any())
            {
                var group = Groups.First();

                var labworks = new[]
                {
                    new Labwork()
                    {
                        Name = "admin",
                        Group = group
                    }
                };

                Labworks.AddRange(labworks);
                context.Labworks.AddRange(labworks);
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
                var labwork = Labworks.First();

                var queues = new[]
                {
                    new Queue()
                    {
                        Labwork = labwork
                    }
                };

                Queues.AddRange(queues);
                context.Queues.AddRange(queues);
            }
        }

        public void SeedPlaces(HostOceanDbContext context)
        {
            if (!context.Places.Any())
            {
                var queue = Queues.First();
                var user = Users.First();

                var places = new[]
                {
                    new Place()
                    {
                        Order = 1,
                        Queue = queue,
                        User = user
                    }
                };

                context.Places.AddRange(places);
            }
        }
    }
}