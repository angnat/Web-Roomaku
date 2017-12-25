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
using System.Net.Mail;
using CaptchaMvc.Models;
using CaptchaMvc.HtmlHelpers;

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
                sendMailNotification(tblT_Roomaku);                
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

       

        public void sendMailHtml( String ToAddr, String MailSubject, String MailBody)
        {
           MailMessage mailMessage = new MailMessage();
           mailMessage.From = new MailAddress("sales@roomaku.id");
           String[] ToList = ToAddr.Split(',');
           foreach(String toMail in ToList)
           {
                mailMessage.To.Add(new MailAddress(toMail));
           }

            //Text/HTML
            mailMessage.IsBodyHtml = true;

            //Set the subjet and body text
            mailMessage.Subject = MailSubject;
            mailMessage.Body = MailBody;

            //SmtpClient smtpClient = new SmtpClient();
            //smtpClient.Send(mailMessage);

            using (var smtp = new SmtpClient())
            {
                var credential = new NetworkCredential
                {
                    UserName = "sales@roomaku.id",  // replace with valid value
                    Password = "password.1"  // replace with valid value
                };
                smtp.Credentials = credential;
                smtp.Host = "mail.roomaku.id";
                smtp.Port = 587;
                smtp.EnableSsl = false;
                smtp.Send(mailMessage);                
            }

        }

        public void sendMailNotification(tblT_Roomaku item)
        {
            String email = "angnat05@yahoo.com,arielsk@roomaku.id,parhan@roomaku.id";
            String isiemail = "<html><head><title></title>";
            isiemail += "<style>body {color:#000000; font-family:Callibri,arial,verdana; font-size:14px; text-align:left;}</style>";
            isiemail += "</head><body style='text-align:justify'>";
            isiemail += "Terdapat Request Pemesanan Material : " + item.Material + " <br> ";
            isiemail += "Oleh : " + item.Nama + " <br> ";
            isiemail += "Lokasi : " + item.Lokasi + " <br> ";
            isiemail += "Telp : " + item.Telp + " <br> ";
            isiemail += "</body></html>";
            this.sendMailHtml(email, "Pemesanan Material", isiemail);
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
