using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using MeetingOrganizer.Models;
using MeetingOrganizer.Models.Models;
using MeetingOrganizer.Models.Context;

namespace MeetingOrganizer.Controllers
{
    public class MeetingsController : ApiController
    {
        private MeetingOrganizerContext db = new MeetingOrganizerContext();

        // GET: api/Meetings
        public IQueryable<Meeting> GetMeetings()
        {
            return db.Meeting;
        }

        // GET: api/Meetings/5
        [ResponseType(typeof(Meeting))]
        public async Task<IHttpActionResult> GetMeeting(int id)
        {
            Meeting meeting = await db.Meeting.FindAsync(id);
            if (meeting == null)
            {
                return NotFound();
            }

            return Ok(meeting);
        }
        

        // PUT: api/Meetings/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutMeeting(int id, Meeting meeting)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != meeting.MeetingId)
            {
                return BadRequest();
            }

            meeting.UpdateTime = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
            db.Entry(meeting).State = System.Data.Entity.EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MeetingExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Meetings
        [ResponseType(typeof(Meeting))]
        public async Task<IHttpActionResult> PostMeeting(Meeting meeting)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            meeting.UpdateTime = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
            db.Meeting.Add(meeting);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = meeting.MeetingId }, meeting);
        }

        // DELETE: api/Meetings/5
        [ResponseType(typeof(Meeting))]
        public async Task<IHttpActionResult> DeleteMeeting(int id)
        {
            Meeting meeting = await db.Meeting.FindAsync(id);
            if (meeting == null)
            {
                return NotFound();
            }

            db.Meeting.Remove(meeting);
            await db.SaveChangesAsync();

            return Ok(meeting);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MeetingExists(int id)
        {
            return db.Meeting.Count(e => e.MeetingId == id) > 0;
        }
    }
}