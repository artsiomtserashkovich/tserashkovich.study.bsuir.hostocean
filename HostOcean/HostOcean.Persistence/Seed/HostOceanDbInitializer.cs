using AutoMapper;
using HostOcean.Domain.Entities;
using HostOcean.Infrastructure.BsuirGroupService;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace HostOcean.Persistence.Seed
{
    public class HostOceanDbInitializer
    {
        private readonly List<Group> Groups = new List<Group>();
        private readonly List<User> Users = new List<User>();
        private readonly List<LaboratoryWork> LaboratoryWorks = new List<LaboratoryWork>();
        private readonly List<Queue> Queues = new List<Queue>();

        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IISHttpClient _iisClient;
        private readonly IMapper _mapper;

        public static void Initialize(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetRequiredService<HostOceanDbContext>();
            var iisClient = serviceProvider.GetRequiredService<IISHttpClient>();
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var mapper = serviceProvider.GetRequiredService<IMapper>();

            try
            {
                context.Database.Migrate();
                new HostOceanDbInitializer(roleManager, iisClient, mapper).Seed(context);
            }
            catch (SqlException sqlException) when (sqlException.Number == 1801)
            {
                //Ignored. Reason: Database already exist.
            }
        }

        public HostOceanDbInitializer(RoleManager<IdentityRole> roleManager, IISHttpClient iisClient, IMapper mapper)
        {
            _roleManager = roleManager;
            _iisClient = iisClient;
            _mapper = mapper;
        }

        public void Seed(HostOceanDbContext context)
        {
//            SeedRoles(context);
//            SeedLabworks(context);
//            SeedUsers(context);
//            SeedQueues(context);
//            SeedPlaces(context);
//
//            context.SaveChanges();
        }

        public void SeedRoles(HostOceanDbContext context)
        {
            if (!context.Roles.Any())
            {
                _roleManager.CreateAsync(new IdentityRole("Admin")).Wait();
                _roleManager.CreateAsync(new IdentityRole("User")).Wait();
            }
        }

        public void SeedGroups(HostOceanDbContext context)
        {
            IReadOnlyCollection<IISGroup> groups;
            try
            {
                groups = _iisClient.GetGroups().Result;
            }
            catch (Exception ex)
            {
                groups = new List<IISGroup>();
            }

            var mappedGroups = _mapper.Map<IReadOnlyCollection<IISGroup>, IEnumerable<Group>>(groups);

            var newGroups = mappedGroups.Where(g => !context.Groups.Any(e => e.Name == g.Name)).ToList();
            var updatedGroups = mappedGroups.Where(g => context.Groups.Any(e => e.Name == g.Name)).ToList();

            Groups.AddRange(mappedGroups);
            context.Groups.AddRange(newGroups);
            context.Groups.UpdateRange(updatedGroups);
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
                        CreatedOn = DateTime.Now,
                        Queue = queue,
                        User = user
                    }
                };

                context.UserQueues.AddRange(places);
            }
        }
    }
}