using MeetingOrganizer.Models.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace MeetingOrganizer.Models.Context
{
    public class MeetingOrganizerContext : DbContext
    {
        //if you wanna use standard security your connection string like this
        //Server=myServerAddress;Database=myDataBase;User Id=myUsername;Password=myPassword;

        private static string cs = "server=ONURPC;database=MeetingOrganizerDatabase;Trusted_Connection=true;";
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public MeetingOrganizerContext()
        {
            Database.Connection.ConnectionString = cs;
        }

        public DbSet<Meeting> Meeting { get; set; }
    }
}