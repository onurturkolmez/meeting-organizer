using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using MeetingOrganizer.Models.Context;

namespace MeetingOrganizer.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<MeetingOrganizer.Models.Context.MeetingOrganizerContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(MeetingOrganizerContext context)
        {
            base.Seed(context);
        }
    }
}