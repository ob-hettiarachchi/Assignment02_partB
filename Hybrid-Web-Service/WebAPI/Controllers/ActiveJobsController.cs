using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using WebAPI.Models;

//OB Hettiarachchi - 20908883 || KAD Miththaka - 20907819  || Assignment 02 - part B

namespace WebAPI.Controllers
{
    public class ActiveJobsController : ApiController
    {
        private LocalDBEntities2 db = new LocalDBEntities2();

        [Route("api/activeJobs/search")]
        [HttpGet]
        public IHttpActionResult GetJobs(int id)
        {
            List<ActiveJob> activeJobs = db.ActiveJobs.Where(d => d.jobId == id).ToList();
            if (activeJobs == null)
            {
                return NotFound();
            }

            return Ok(activeJobs);
        }


        // GET: api/ActiveJobs
        public IQueryable<ActiveJob> GetActiveJobs()
        {
            return db.ActiveJobs;
        }

        // GET: api/ActiveJobs/5
        [ResponseType(typeof(ActiveJob))]
        public IHttpActionResult GetActiveJob(int id)
        {
            ActiveJob activeJob = db.ActiveJobs.Find(id);
            if (activeJob == null)
            {
                return NotFound();
            }

            return Ok(activeJob);
        }

        // PUT: api/ActiveJobs/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutActiveJob(int id, ActiveJob activeJob)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != activeJob.Id)
            {
                return BadRequest();
            }

            db.Entry(activeJob).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ActiveJobExists(id))
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

        // POST: api/ActiveJobs
        [ResponseType(typeof(ActiveJob))]
        public IHttpActionResult PostActiveJob(ActiveJob activeJob)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ActiveJobs.Add(activeJob);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (ActiveJobExists(activeJob.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = activeJob.Id }, activeJob);
        }

        // DELETE: api/ActiveJobs/5
        [ResponseType(typeof(ActiveJob))]
        public IHttpActionResult DeleteActiveJob(int id)
        {
            ActiveJob activeJob = db.ActiveJobs.Find(id);
            if (activeJob == null)
            {
                return NotFound();
            }

            db.ActiveJobs.Remove(activeJob);
            db.SaveChanges();

            return Ok(activeJob);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ActiveJobExists(int id)
        {
            return db.ActiveJobs.Count(e => e.Id == id) > 0;
        }
    }
}