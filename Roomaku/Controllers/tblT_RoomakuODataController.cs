using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using System.Web.Http.OData;
using System.Web.Http.OData.Routing;
using RoomakuRepository;

namespace Roomaku.Controllers
{
    /*
    The WebApiConfig class may require additional changes to add a route for this controller. Merge these statements into the Register method of the WebApiConfig class as applicable. Note that OData URLs are case sensitive.

    using System.Web.Http.OData.Builder;
    using System.Web.Http.OData.Extensions;
    using RoomakuRepository;
    ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
    builder.EntitySet<tblT_Roomaku>("tblT_RoomakuOData");
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    public class tblT_RoomakuODataController : ODataController
    {
        private RoomakuDBEntities db = new RoomakuDBEntities();

        // GET: odata/tblT_RoomakuOData
        [EnableQuery]
        public IQueryable<tblT_Roomaku> GettblT_RoomakuOData()
        {
            return db.tblT_Roomaku;
        }

        // GET: odata/tblT_RoomakuOData(5)
        [EnableQuery]
        public SingleResult<tblT_Roomaku> GettblT_Roomaku([FromODataUri] long key)
        {
            return SingleResult.Create(db.tblT_Roomaku.Where(tblT_Roomaku => tblT_Roomaku.ID == key));
        }

        // PUT: odata/tblT_RoomakuOData(5)
        public IHttpActionResult Put([FromODataUri] long key, Delta<tblT_Roomaku> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            tblT_Roomaku tblT_Roomaku = db.tblT_Roomaku.Find(key);
            if (tblT_Roomaku == null)
            {
                return NotFound();
            }

            patch.Put(tblT_Roomaku);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tblT_RoomakuExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(tblT_Roomaku);
        }

        // POST: odata/tblT_RoomakuOData
        public IHttpActionResult Post(tblT_Roomaku tblT_Roomaku)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.tblT_Roomaku.Add(tblT_Roomaku);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (tblT_RoomakuExists(tblT_Roomaku.ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return Created(tblT_Roomaku);
        }

        // PATCH: odata/tblT_RoomakuOData(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public IHttpActionResult Patch([FromODataUri] long key, Delta<tblT_Roomaku> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            tblT_Roomaku tblT_Roomaku = db.tblT_Roomaku.Find(key);
            if (tblT_Roomaku == null)
            {
                return NotFound();
            }

            patch.Patch(tblT_Roomaku);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tblT_RoomakuExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(tblT_Roomaku);
        }

        // DELETE: odata/tblT_RoomakuOData(5)
        public IHttpActionResult Delete([FromODataUri] long key)
        {
            tblT_Roomaku tblT_Roomaku = db.tblT_Roomaku.Find(key);
            if (tblT_Roomaku == null)
            {
                return NotFound();
            }

            db.tblT_Roomaku.Remove(tblT_Roomaku);
            db.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool tblT_RoomakuExists(long key)
        {
            return db.tblT_Roomaku.Count(e => e.ID == key) > 0;
        }
    }
}
