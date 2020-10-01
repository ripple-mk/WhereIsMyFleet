using Lamar;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhereIsMyFleet.Core;

namespace WhereIsMyFleet.Infrastructure
{
    public class SeedData
    {

        [SetterProperty]
        public WhereIsMyFleetDbContext Context { private get; set; }

        public void Initialize()
        {
            Context.Database.Migrate();
            Context.Database.EnsureCreated();

            if (!Context.Drones.Any())
                Context.Database.ExecuteSqlRaw(SeedDrones);

            Context.SaveChanges();
        }

        static readonly string SeedDrones = @"
        INSERT [dbo].[Drones] ([Id], [Name], [Latitude], [Longitude], [CreatedOn], [LastModifiedOn], [CreatedBy], [LastModifiedBy]) VALUES (N'445588d2-0fd2-49b7-c8dc-08d86645bd13', N'4X-XNV', 32.15837, 34.94426, CAST(N'2020-10-01T20:08:18.3738681+00:00' AS DateTimeOffset), CAST(N'2020-10-01T20:08:18.3738681+00:00' AS DateTimeOffset), N'00000000-0000-0000-0000-000000000000', N'00000000-0000-0000-0000-000000000000')
        INSERT [dbo].[Drones] ([Id], [Name], [Latitude], [Longitude], [CreatedOn], [LastModifiedOn], [CreatedBy], [LastModifiedBy]) VALUES (N'a1afbc74-bc0f-41d6-c8dd-08d86645bd13', N'4X-XNX', 32.15086, 34.94292, CAST(N'2020-10-01T20:08:40.3069104+00:00' AS DateTimeOffset), CAST(N'2020-10-01T20:08:40.3069104+00:00' AS DateTimeOffset), N'00000000-0000-0000-0000-000000000000', N'00000000-0000-0000-0000-000000000000')
        INSERT [dbo].[Drones] ([Id], [Name], [Latitude], [Longitude], [CreatedOn], [LastModifiedOn], [CreatedBy], [LastModifiedBy]) VALUES (N'9f71190f-f4de-41af-c8de-08d86645bd13', N'4X-XNY', 32.54803, 34.93203, CAST(N'2020-10-01T20:08:56.4815732+00:00' AS DateTimeOffset), CAST(N'2020-10-01T20:08:56.4815732+00:00' AS DateTimeOffset), N'00000000-0000-0000-0000-000000000000', N'00000000-0000-0000-0000-000000000000')
        INSERT [dbo].[Drones] ([Id], [Name], [Latitude], [Longitude], [CreatedOn], [LastModifiedOn], [CreatedBy], [LastModifiedBy]) VALUES (N'e12a33a2-f26c-4127-c8df-08d86645bd13', N'4X-XNP', 32.15828, 34.94448, CAST(N'2020-10-01T20:09:14.9981761+00:00' AS DateTimeOffset), CAST(N'2020-10-01T20:09:14.9981761+00:00' AS DateTimeOffset), N'00000000-0000-0000-0000-000000000000', N'00000000-0000-0000-0000-000000000000')
        INSERT [dbo].[Drones] ([Id], [Name], [Latitude], [Longitude], [CreatedOn], [LastModifiedOn], [CreatedBy], [LastModifiedBy]) VALUES (N'b51c2202-c1d6-4832-c8e0-08d86645bd13', N'4X-XIJ', 32.11302, 34.84884, CAST(N'2020-10-01T20:09:31.2586312+00:00' AS DateTimeOffset), CAST(N'2020-10-01T20:09:31.2586312+00:00' AS DateTimeOffset), N'00000000-0000-0000-0000-000000000000', N'00000000-0000-0000-0000-000000000000')
        INSERT [dbo].[Drones] ([Id], [Name], [Latitude], [Longitude], [CreatedOn], [LastModifiedOn], [CreatedBy], [LastModifiedBy]) VALUES (N'6307787b-97b6-4e02-c8e1-08d86645bd13', N'4X-XFI', 32.1465, 34.94875, CAST(N'2020-10-01T20:09:49.0080772+00:00' AS DateTimeOffset), CAST(N'2020-10-01T20:09:49.0080772+00:00' AS DateTimeOffset), N'00000000-0000-0000-0000-000000000000', N'00000000-0000-0000-0000-000000000000')
        ";
    }
}
