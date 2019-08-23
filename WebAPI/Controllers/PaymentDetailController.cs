using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class PaymentDetailController : ApiController
    {
        private WebAPIContext db = new WebAPIContext();

        // GET: api/PaymentDetail
        public IQueryable<PaymentDetail> GetPaymentDetails()
        {
            return db.PaymentDetails;
        }

        // GET: api/PaymentDetail/5
        [ResponseType(typeof(PaymentDetail))]
        public IHttpActionResult GetPaymentDetail(int id)
        {
            PaymentDetail paymentDetail = db.PaymentDetails.Find(id);
            if (paymentDetail == null)
            {
                return NotFound();
            }

            return Ok(paymentDetail);
        }

        // PUT: api/PaymentDetail/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPaymentDetail(int id, PaymentDetail paymentDetail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != paymentDetail.PMId)
            {
                return BadRequest();
            }

            db.Entry(paymentDetail).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PaymentDetailExists(id))
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

        // POST: api/PaymentDetail
        [ResponseType(typeof(PaymentDetail))]
        public IHttpActionResult PostPaymentDetail(PaymentDetail paymentDetail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.PaymentDetails.Add(paymentDetail);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = paymentDetail.PMId }, paymentDetail);
        }

        // DELETE: api/PaymentDetail/5
        [ResponseType(typeof(PaymentDetail))]
        public IHttpActionResult DeletePaymentDetail(int id)
        {
            PaymentDetail paymentDetail = db.PaymentDetails.Find(id);
            if (paymentDetail == null)
            {
                return NotFound();
            }

            db.PaymentDetails.Remove(paymentDetail);
            db.SaveChanges();

            return Ok(paymentDetail);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PaymentDetailExists(int id)
        {
            return db.PaymentDetails.Count(e => e.PMId == id) > 0;
        }
    }
}