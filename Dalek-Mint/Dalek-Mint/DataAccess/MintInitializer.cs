namespace Dalek_Mint.DataAccess
{
    using Dalek_Mint.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;

    /// <summary>
    /// Defines the <see cref="MintInitializer" />
    /// </summary>
    public class MintInitializer : CreateDatabaseIfNotExists<MintContext>
    {
        /// <summary>
        /// Used to populate the database whenever the model changes. Used for testing.
        /// </summary>
        /// <param name="context">The information being used for testing.</param>
        protected override void Seed(MintContext context)
        {
            var permissionSets = new List<PermissionSet>
            {
                new PermissionSet { PermissionSetId=1, RequiresApprovalToEdit=false, RequiresApprovalToPublish=false, CanEdit=true, CanPublish=true, CanEditUsers=true },
                new PermissionSet { PermissionSetId=2, RequiresApprovalToEdit=true, RequiresApprovalToPublish=true, CanEdit=true, CanPublish=true, CanEditUsers=false },
                new PermissionSet { PermissionSetId=3, RequiresApprovalToEdit=true, RequiresApprovalToPublish=true, CanEdit=false, CanPublish=false, CanEditUsers=false }
            };

            permissionSets.ForEach(p => context.PermissionSet.Add(p));
            context.SaveChanges();

            var userGroups = new List<UserGroup>
            {
                new UserGroup { UserGroupId=1, UserGroupPermissionSetId=1 },
                new UserGroup { UserGroupId=2, UserGroupPermissionSetId=2 },
                new UserGroup { UserGroupId=3, UserGroupPermissionSetId=3 }
            };

            permissionSets.ForEach(p => context.PermissionSet.Add(p));
            context.SaveChanges();

            var users = new List<User>
            {
                new User { FirstName="Asher", LastName="Smith", UserId=1, Email="asher1234@my.mstc.edu", UserGroupId=3 },
                new User { FirstName="Breanne", LastName="Yusten", UserId=2, Email="12345678@mstc.edu", UserGroupId=2 },
                new User { FirstName="Bryce", LastName="Menandue", UserId=3, Email="menandue0000@my.mstc.edu", UserGroupId=2 },
                new User { FirstName="Matt", LastName="Skifton", UserId=4, Email="11223344@mstc.edu", UserGroupId=3 },
                new User { FirstName="Asher2", LastName="Smith2", UserId=5, Email="asher1234@my.mstc.edu", UserGroupId=3 },
                new User { FirstName="Breanne2", LastName="Yusten2", UserId=6, Email="12345678@mstc.edu", UserGroupId=2 },
                new User { FirstName="Bryce2", LastName="Menandue2", UserId=7, Email="menandue0000@my.mstc.edu", UserGroupId=1 },
                new User { FirstName="Matt2", LastName="Skifton2", UserId=8, Email="11223344@mstc.edu", UserGroupId=3 },
                new User { FirstName="Asher3", LastName="Smith3", UserId=9, Email="asher1234@my.mstc.edu", UserGroupId=3 },
                new User { FirstName="Breanne3", LastName="Yusten3", UserId=10, Email="12345678@mstc.edu", UserGroupId=2 },
                new User { FirstName="Bryce3", LastName="Menandue3", UserId=11, Email="menandue0000@my.mstc.edu", UserGroupId=1 },
                new User { FirstName="Matt3", LastName="Skifton3", UserId=12, Email="11223344@mstc.edu", UserGroupId=3 },
                new User { FirstName="Asher4", LastName="Smith4", UserId=13, Email="asher1234@my.mstc.edu", UserGroupId=3 },
                new User { FirstName="Breanne4", LastName="Yusten4", UserId=14, Email="12345678@mstc.edu", UserGroupId=2 },
                new User { FirstName="Bryce4", LastName="Menandue4", UserId=15, Email="menandue0000@my.mstc.edu", UserGroupId=1 },
                new User { FirstName="Matt4", LastName="Skifton4", UserId=16, Email="11223344@mstc.edu", UserGroupId=3 },
                new User { FirstName="Natasha", LastName="Miller", UserId=5, Email="miller0000@my.mstc.edu", Password="FHIcGX5reAFPSvKseMpYIOHZGJg+oU1aWNZMDJ0aG3w1Cg4ewX2FYaHqpnhSaptAauVezg==", UserGroupId=1 }
            };

            users.ForEach(u => context.User.Add(u));
            context.SaveChanges();

            var campuses = new List<Campus>
            {
                new Campus { CampusId=1, Address="1001 Center Point Drive", City="Stevens Point", Zip=54481, PhoneNumber=7153443063 },
                new Campus { CampusId=2, Address="500 32nd Street North", City="Wisconsin Rapids", Zip=54494, PhoneNumber=7154225300 },
                new Campus { CampusId=3, Address="2600 W 5th Street", City="Marshfield", Zip=54449, PhoneNumber=7153872538 },
                new Campus { CampusId=4, Address="401 N Main Street", City="Adams", Zip=53910, PhoneNumber=6083393379 }
            };

            campuses.ForEach(c => context.Campus.Add(c));
            context.SaveChanges();

            var events = new List<Event>
            {
                new Event { EventId=1, Name="Capture the Campus", Description="Insert what that is here.", Date=DateTime.Now.AddDays(1), Address="123 Main Street", City="Stevens Point", Zip=54481, State="WI",Category = 1, FreeFood=false, FreeStuff=true, RSVPCapable=true },
                new Event { EventId=2, Name="CRU Khalahari Trip", Description="Go to the Kalahari with the CRU club!", Date=DateTime.Today.AddDays(1), Address="444 Kalahari Drive", City="Wisconsin Dells", Zip=53111, State="WI",Category = 4, FreeFood=false, FreeStuff=false, RSVPCapable=true },
                new Event { EventId=3, Name="Pizza Party", Description="Who doesn't like FREE PIZZA!!", Date=DateTime.Today.AddDays(1), Address="123 Main Street", City="Stevens Point", Zip=53111, State="WI",Category = 2, FreeFood=true, FreeStuff=false, RSVPCapable=true },
                new Event { EventId=4, Name="Building a Rhaspberry Pi Cabinet", Description="We are building a raspberry pi cabinet!", Date=DateTime.Today.AddDays(2), Address="500 32nd Street North", City="Wisconsin Rapids", Zip=54494, State="WI",Category = 5, FreeFood=true, FreeStuff=false, RSVPCapable=true },
                new Event { EventId=5, Name="Capture the Campus", Description="Insert what that is here.", Date=DateTime.Now.AddDays(2), Address="123 Main Street", City="Stevens Point", Zip=54481, State="WI",Category = 3, FreeFood=false, FreeStuff=true, RSVPCapable=true },
                new Event { EventId=6, Name="CRU Khalahari Trip", Description="Go to the Kalahari with the CRU club!", Date=DateTime.Today.AddDays(2), Address="444 Kalahari Drive", City="Wisconsin Dells", Zip=53111, State="WI",Category = 1, FreeFood=false, FreeStuff=false, RSVPCapable=true },
                new Event { EventId=7, Name="Pizza Party", Description="Who doesn't like FREE PIZZA!!", Date=DateTime.Today.AddDays(3), Address="123 Main Street", City="Stevens Point", Zip=53111, State="WI",Category = 4, FreeFood=true, FreeStuff=false, RSVPCapable=true },
                new Event { EventId=8, Name="Building a Rhaspberry Pi Cabinet", Description="We are building a raspberry pi cabinet!", Date=DateTime.Today.AddDays(3), Address="500 32nd Street North", City="Wisconsin Rapids", Zip=54494, State="WI",Category = 3, FreeFood=true, FreeStuff=false, RSVPCapable=true },
                new Event { EventId=9, Name="Capture the Campus", Description="Insert what that is here.", Date=DateTime.Now.AddDays(3), Address="123 Main Street", City="Stevens Point", Zip=54481, State="WI",Category = 5, FreeFood=false, FreeStuff=true, RSVPCapable=true },
                new Event { EventId=10, Name="CRU Khalahari Trip", Description="Go to the Kalahari with the CRU club!", Date=DateTime.Today.AddDays(4), Address="444 Kalahari Drive", City="Wisconsin Dells", Zip=53111, State="WI",Category = 1, FreeFood=false, FreeStuff=false, RSVPCapable=true },
                new Event { EventId=11, Name="Pizza Party", Description="Who doesn't like FREE PIZZA!!", Date=DateTime.Today.AddDays(5), Address="123 Main Street", City="Stevens Point", Zip=53111, State="WI",Category = 6, FreeFood=true, FreeStuff=false, RSVPCapable=true },
                new Event { EventId=12, Name="Building a Rhaspberry Pi Cabinet", Description="We are building a raspberry pi cabinet!", Date=DateTime.Today.AddDays(5), Address="500 32nd Street North", City="Wisconsin Rapids", Zip=54494, State="WI",Category = 6, FreeFood=true, FreeStuff=false, RSVPCapable=true },
                new Event { EventId=13, Name="Capture the Campus", Description="Insert what that is here.", Date=DateTime.Now.AddDays(6), Address="123 Main Street", City="Stevens Point", Zip=54481, State="WI",Category = 4, FreeFood=false, FreeStuff=true, RSVPCapable=true },
                new Event { EventId=14, Name="CRU Khalahari Trip", Description="Go to the Kalahari with the CRU club!", Date=DateTime.Today.AddDays(7), Address="444 Kalahari Drive", City="Wisconsin Dells", Zip=53111, State="WI",Category = 6, FreeFood=false, FreeStuff=false, RSVPCapable=true },
                new Event { EventId=15, Name="Pizza Party", Description="Who doesn't like FREE PIZZA!!", Date=DateTime.Today.AddDays(7), Address="123 Main Street", City="Stevens Point", Zip=53111, State="WI",Category = 1, FreeFood=true, FreeStuff=false, RSVPCapable=true },
                new Event { EventId=16, Name="Building a Rhaspberry Pi Cabinet", Description="We are building a raspberry pi cabinet!", Date=DateTime.Today.AddDays(8), Address="500 32nd Street North", City="Wisconsin Rapids", Zip=54494, State="WI",Category = 3, FreeFood=true, FreeStuff=false, RSVPCapable=true }

            };

            events.ForEach(e => context.Event.Add(e));
            context.SaveChanges();

            //var eventAttendances = new List<EventAttendance>
            //{
            //    new EventAttendance { UserId=1, EventId=1 },
            //    new EventAttendance { UserId=2, EventId=2 },
            //    new EventAttendance { UserId=3, EventId=1},
            //    new EventAttendance { UserId=1, EventId=2 }
            //};

            //eventAttendances.ForEach(ea => context.EventAttendance.Add(ea));
            //context.SaveChanges();

            var campusEvents = new List<CampusEvent>
            {
                new CampusEvent { CampusEventId=1, CampusId=1, EventId=1 },
                new CampusEvent { CampusEventId=2, CampusId=2, EventId=3 }
            };

            campusEvents.ForEach(ce => context.CampusEvent.Add(ce));
            context.SaveChanges();

            var clubs = new List<Club>
            {
                new Club { ClubId=1, Name="Security Club", Description="Have fun learning ways to prevent cyber-attacks and learn more about computer security.", Contact="123456@mstc.edu" },
                new Club { ClubId=2, Name="CRU", Description="Encourage each other to grow in Christ and have fun learning from the Bible.", Contact="456789@mstc.edu" },
                new Club { ClubId=3, Name="Technology Club", Description="Have fun with different types of technology projects and building technology.", Contact="987654@mstc.edu" },
                new Club { ClubId=4, Name="Security Club", Description="Have fun learning ways to prevent cyber-attacks and learn more about computer security.", Contact="Bryce@mstc.edu" },
                new Club { ClubId=5, Name="CRU", Description="Encourage each other to grow in Christ and have fun learning from the Bible.", Contact="Asher@mstc.edu" },
                new Club { ClubId=6, Name="Technology Club", Description="Have fun with different types of technology projects and building technology.", Contact="Matt@mstc.edu" }
            };

            clubs.ForEach(c => context.Club.Add(c));
            context.SaveChanges();

            var eventHosts = new List<EventHost>
            {
                new EventHost { ClubId=1, EventId=1 },
                new EventHost { ClubId=2, EventId=2 },
                new EventHost { ClubId=3, EventId=3 },
                new EventHost { ClubId=4, EventId=4 },
                new EventHost { ClubId=5, EventId=5 },
                new EventHost { ClubId=6, EventId=6 },
                new EventHost { ClubId=1, EventId=7 },
                new EventHost { ClubId=2, EventId=8 },
                new EventHost { ClubId=3, EventId=9 },
                new EventHost { ClubId=4, EventId=10 },
                new EventHost { ClubId=5, EventId=11 },
                new EventHost { ClubId=6, EventId=12 },
                new EventHost { ClubId=1, EventId=13 },
                new EventHost { ClubId=2, EventId=14 },
                new EventHost { ClubId=3, EventId=15 },
                new EventHost { ClubId=1, EventId=16 }
            };

            eventHosts.ForEach(eh => context.EventHost.Add(eh));
            context.SaveChanges();

            var clubMembers = new List<ClubMember>
            {
                new ClubMember { ClubMemberId=1, ClubId=1, IsOfficer=false, Title="Club member", UserId=1 },
                new ClubMember { ClubMemberId=2, ClubId=2, IsOfficer=false, Title="Club member", UserId=2 },
                new ClubMember { ClubMemberId=3, ClubId=3, IsOfficer=true, Title="Treasurer", UserId=4 }
            };

            clubMembers.ForEach(cm => context.ClubMember.Add(cm));
            context.SaveChanges();

            var news = new List<News>
            {
                new News { NewsId=1, Title="Join the New Technology Club", Article="Enter text here", Description="Wisconsin Rapids campus has a new club to join!", PostedDate=DateTime.Now.AddHours(-1) },
                new News { NewsId=2, Title="Capture the Campus Begins Once Again", Article="Information about capture the campus starting up again", Description="The Security Club is hosting another Capture the Campus event!", PostedDate=DateTime.Now.AddDays(-1) },
                new News { NewsId=3, Title="Kalahari Trip Hosted by CRU", Article="Information about Kalahari trip", Description="CRU will be taking a group to the Kalahari!", PostedDate=DateTime.Now }
            };

            news.ForEach(n => context.News.Add(n));
            context.SaveChanges();

            var clubNews = new List<ClubNews>
            {
                new ClubNews { ClubNewsId=1, ClubId=1, NewsId=1 },
                new ClubNews { ClubNewsId=1, ClubId=2, NewsId=3 },
                new ClubNews { ClubNewsId=1, ClubId=3, NewsId=2 }
            };

            clubNews.ForEach(cn => context.ClubNews.Add(cn));
            context.SaveChanges();

            // I know this is not ideal it is just here until the migrations get working.
            //CreateProcs(context);

            context.SaveChanges();
        }

        /// <summary>
        /// Creates all the procs for the DB
        /// </summary>
        /// <param name="context">The context<see cref="MintContext"/></param>
        private void CreateProcs(MintContext context)
        {
            context.Database.ExecuteSqlCommand("create procedure [Event By ID] ( @EventID int ) as select* from events where EventId = @EventID");

            context.Database.ExecuteSqlCommand("create procedure [Club By ID] ( @ClubID int ) as select* from clubs where ClubId = @ClubID");

            context.Database.ExecuteSqlCommand("create procedure [Event Hosts] ( @EventID int ) as  select c.* from EventHosts h inner join Clubs c on c.ClubId = h.ClubId where h.EventId = @EventID");

            // Used to find the user that matches the inputted email on sign-in.
            context.Database.ExecuteSqlCommand("create procedure [Find User] ( @Email varchar(40) ) as select * from users where Email = @Email");

            // This one makes me the most sad
            context.Database.ExecuteSqlCommand("create procedure [Similar Events] ( @ClubList varchar(20) ) as Declare @SQL varchar(200) set @SQL = 'select top 4 e.* from EventHosts h inner join Events e on e.EventId = h.EventId where ClubId in (' + @ClubList + ') order by e.Date'exec(@SQL)");

            context.Database.ExecuteSqlCommand("Create procedure [All Clubs] ( @search varchar(50) = null)  as select top 15 * from Clubs e where @search = null or (Name like '%'+@search+'%') order by Name ");

            context.Database.ExecuteSqlCommand("create procedure [Upcoming Events] ( @search varchar(50) = null) as select top 15 * from Events e where (GETDATE() < e.Date) and (@search = null or (@search = Name)) order by e.Date asc");

            context.Database.ExecuteSqlCommand("create procedure [Upcoming Club Events] ( @ClubId int ) as select top 4 e.* from EventHosts h inner join Events e on e.EventId = h.EventId where h.ClubId = @ClubId and GetDate() < e.Date order by e.Date asc");

            context.Database.ExecuteSqlCommand("create procedure [Club Officers] ( @ClubId int ) as select u.FirstName, u.LastName, m.Title from Users u inner join ClubMembers m on m.UserId = u.UserId where m.IsOfficer = 1 and m.ClubId = @ClubId");

            context.Database.ExecuteSqlCommand("create procedure [Recent News] ( @search varchar(50) = null) as select top 8 * from news where @search = null or (Title like '%'+@search+'%') order by PostedDate desc");

            context.Database.ExecuteSqlCommand("create procedure [News By Id] (@NewsId int) as select  c.Name, n.* from ClubNews cn inner join news n on cn.NewsId = n.NewsId inner join Clubs c on cn.ClubId = c.ClubId where n.NewsId = @NewsId");

            context.Database.ExecuteSqlCommand("Create procedure [Hosts]  as select clubid, name from clubs");
        }
    }
}
