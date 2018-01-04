using System;
using EASolution.Domain;
using FluentMigrator;
using FluentMigrator.Runner.Extensions;

namespace EASolution.DataMigration
{
    internal static class SeedDataExtension
    {

        public static void SeedUseCaseCategory(this Migration migrator)
        {
            string tableName = "UseCaseCategory";
            migrator.Insert.IntoTable(tableName)
                .WithIdentityInsert()
                .Row(new
                {
                    Id = 1,
                    Type = (int)CategoryName.Simple,
                    Description = "Simple user interface. Touches only a single database entity. Its success scenario has three steps or less. Its implementation involves less than five classes.",
                    Weight = 5,
                    ProjectId = 1
                });
            migrator.Insert.IntoTable(tableName)
                .WithIdentityInsert()
                .Row(new
                {
                    Id = 2,
                    Type = (int)CategoryName.Average,
                    Description = "More interface design. Touches two or more database entities. Between four and seven steps. Its implementation involves between five and 10 classes.",
                    Weight = 10,
                    ProjectId = 1
                });
            migrator.Insert.IntoTable(tableName)
                .WithIdentityInsert()
                .Row(new
                {
                    Id = 3,
                    Type = (int)CategoryName.Complex,
                    Description = "Complex user interface or processing. Touches three or more database entities. More than seven steps. Its implementation involves more than 10 classes.",
                    Weight = 15,
                    ProjectId = 1
                });
        }
        public static void SeedActorCategory(this Migration migrator)
        {
            string tableName = "ActorCategory";
            migrator.Insert.IntoTable(tableName)
                .WithIdentityInsert()
                .Row(new
                {
                    Id = 1,
                    Type = (int)CategoryName.SimpleActor,
                    Description = "The actor represents another system with a defined application programming interface",
                    Weight = 1,
                    ProjectId = 1
                });
            migrator.Insert.IntoTable(tableName)
                .WithIdentityInsert()
                .Row(new
                {
                    Id = 2,
                    Type = (int)CategoryName.AverageActor,
                    Description = "Average actors are recognized if they have the following properties: Actors who are interacting with the system through some protocol (HTTP, FTP, or probably some user defined protocol) or Actors which are data stores (Files, RDBMS).",
                    Weight = 2,
                    ProjectId = 1
                });
            migrator.Insert.IntoTable(tableName)
                .WithIdentityInsert()
                .Row(new
                {
                    Id = 3,
                    Type = (int)CategoryName.ComplexActor,
                    Description = "Complex actor is interacting normally through GUI.",
                    Weight = 3,
                    ProjectId = 1
                });
        }
        public static void SeedFactoryCategory(this Migration migrator)
        {
            string tableName = "Factory";
            migrator.Insert.IntoTable(tableName).WithIdentityInsert().Row(new { Id = 1, Type = (int)FactoryType.Technical, Name = "Distributed System", Description = "Is the system having distributed architecture or centralized architecture?", Weight = 2, Value = 0, WeightedValue = 0, ProjectId = 1 });
﻿migrator.Insert.IntoTable(tableName).WithIdentityInsert().Row(new { Id = 2, Type = (int)FactoryType.Technical, Name = "Response time", Description = "Does the client need the system to fast? Is time response one of the important criteria?", Weight = 1, Value = 1, WeightedValue = 1, ProjectId = 1 });
﻿migrator.Insert.IntoTable(tableName).WithIdentityInsert().Row(new { Id = 3, Type = (int)FactoryType.Technical, Name = "End user efficiency", Description = "How's the end user's efficiency?", Weight = 1, Value = 1, WeightedValue = 1, ProjectId = 1 });
﻿migrator.Insert.IntoTable(tableName).WithIdentityInsert().Row(new { Id = 4, Type = (int)FactoryType.Technical, Name = "Complex Internal Processing", Description = "Is the business process very complex? Like complicated accounts closing, inventory tracking, heavy tax calculation etc.", Weight = 1, Value = 4, WeightedValue = 4, ProjectId = 1 });
﻿migrator.Insert.IntoTable(tableName).WithIdentityInsert().Row(new { Id = 5, Type = (int)FactoryType.Technical, Name = "Reusable Code", Description = "Do we intend to keep the reusability high? So will increase the design complexity.", Weight = 1, Value = 1, WeightedValue = 1, ProjectId = 1 });
﻿migrator.Insert.IntoTable(tableName).WithIdentityInsert().Row(new { Id = 6, Type = (int)FactoryType.Technical, Name = "Installation Ease", Description = "Is client looking for installation ease? By default, we get many installers which create packages. But the client might be looking for some custom installation, probably depending on modules. One of our client has a requirement that when the client wants to install, he can choose which modules he can install. Is the requirement such that when there is a new version there should be auto installation? These factors will count when assigning value to this factor.", Weight = 0.5, Value = 0, WeightedValue = 0, ProjectId = 1 });
﻿migrator.Insert.IntoTable(tableName).WithIdentityInsert().Row(new { Id = 7, Type = (int)FactoryType.Technical, Name = "Easy use", Description = "Is user friendliness a top priority?", Weight = 0.5, Value = 2, WeightedValue = 1, ProjectId = 1 });
﻿migrator.Insert.IntoTable(tableName).WithIdentityInsert().Row(new { Id = 8, Type = (int)FactoryType.Technical, Name = "Portable", Description = "Is the customer also looking for cross platform implementation?", Weight = 2, Value = 0, WeightedValue = 0, ProjectId = 1 });
﻿migrator.Insert.IntoTable(tableName).WithIdentityInsert().Row(new { Id = 9, Type = (int)FactoryType.Technical, Name = "Easy to change", Description = "Is the customer looking for high customization in the future? That also increases the architecture design complexity and hence this factor.", Weight = 1, Value = 0, WeightedValue = 0, ProjectId = 1 });
﻿migrator.Insert.IntoTable(tableName).WithIdentityInsert().Row(new { Id = 10, Type = (int)FactoryType.Technical, Name = "Concurrent", Description = "Is the customer looking at large number of users working with locking support? This will increase the architecture complexity and hence this value.", Weight = 1, Value = 0, WeightedValue = 0, ProjectId = 1 });
﻿migrator.Insert.IntoTable(tableName).WithIdentityInsert().Row(new { Id = 11, Type = (int)FactoryType.Technical, Name = "Security objectives", Description = "Is the customer looking at having heavy security like SSL? Or do we have to write custom code logic for encryption?", Weight = 1, Value = 0, WeightedValue = 0, ProjectId = 1 });
﻿migrator.Insert.IntoTable(tableName).WithIdentityInsert().Row(new { Id = 12, Type = (int)FactoryType.Technical, Name = "Direct access to third parties", Description = "Does the project depend in using third party controls? For understanding the third-party controls and studying its pros and cons, considerable effort will be required. So, this factor should be rated accordingly.", Weight = 1, Value = 3, WeightedValue = 3, ProjectId = 1 });
﻿migrator.Insert.IntoTable(tableName).WithIdentityInsert().Row(new { Id = 13, Type = (int)FactoryType.Technical, Name = "User training facilities", Description = "Will the software from user perspective be so complex that separate training has to be provided? So this factor will vary accordingly.", Weight = 1, Value = 0, WeightedValue = 0, ProjectId = 1 });
 migrator.Insert.IntoTable(tableName).WithIdentityInsert().Row(new { Id = 14, Type = (int)FactoryType.Environment, Name = "Familiarity with project", Description = "It’s a simple project, so familiarity with project is not so much needed.", Weight = 5, Value = 1.5, WeightedValue = 7.5, ProjectId = 1 });
﻿migrator.Insert.IntoTable(tableName).WithIdentityInsert().Row(new { Id = 15, Type = (int)FactoryType.Environment, Name = "Application experience", Description = "It's a simple application.", Weight = 5, Value = 0.5, WeightedValue = 2.5, ProjectId = 1 });
﻿migrator.Insert.IntoTable(tableName).WithIdentityInsert().Row(new { Id = 16, Type = (int)FactoryType.Environment, Name = "Object-oriented programming experience", Description = "Every one has good OOP knowledge.", Weight = 5, Value = 1, WeightedValue = 5, ProjectId = 1 });
﻿migrator.Insert.IntoTable(tableName).WithIdentityInsert().Row(new { Id = 17, Type = (int)FactoryType.Environment, Name = "Lead analyst capability", Description = "It's a simple project; no lead analyst needed till now.", Weight = 5, Value = 0.5, WeightedValue = 2.5, ProjectId = 1 });
﻿migrator.Insert.IntoTable(tableName).WithIdentityInsert().Row(new { Id = 18, Type = (int)FactoryType.Environment, Name = "Motivation", Description = "Motivation is little down as programmers are reluctant to work on the project because of its simplicity.", Weight = 1, Value = -1, WeightedValue = -1, ProjectId = 1 });
﻿migrator.Insert.IntoTable(tableName).WithIdentityInsert().Row(new { Id = 19, Type = (int)FactoryType.Environment, Name = "Stable requirements", Description = "Client is very clear with what he wants?", Weight = 4, Value = 0, WeightedValue = 0, ProjectId = 1 });
﻿migrator.Insert.IntoTable(tableName).WithIdentityInsert().Row(new { Id = 20, Type = (int)FactoryType.Environment, Name = "Part-time Staff", Description = "No part time staff.", Weight = 0, Value = -1, WeightedValue = 0, ProjectId = 1 });
﻿migrator.Insert.IntoTable(tableName).WithIdentityInsert().Row(new { Id = 21, Type = (int)FactoryType.Environment, Name = "Difficult programming language.", Description = "C# will be used. And most of the programming guys are new to C# and .NET technology.", Weight = 3, Value = -1, WeightedValue = -3, ProjectId = 1 });
        }
    }
}