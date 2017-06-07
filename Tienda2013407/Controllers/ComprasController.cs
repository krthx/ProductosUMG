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
using Tienda2013407.Models;

namespace Tienda2013407.Controllers
{
    public class ComprasController : ApiController
    {
        private Tienda2013407Context db = new Tienda2013407Context();

        // GET: api/Compras
        public IQueryable<Compra> GetCompras()
        {
            return db.Compras
                .Include(pr => pr.Producto)
                .Include(us => us.Usuario);
        }

        // GET: api/Compras/5
        [ResponseType(typeof(Compra))]
        public async Task<IHttpActionResult> GetCompra(int id)
        {
            Compra compra = await db.Compras.FindAsync(id);
            if (compra == null)
            {
                return NotFound();
            }

            return Ok(compra);
        }

        // PUT: api/Compras/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutCompra(int id, Compra compra)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != compra.ID)
            {
                return BadRequest();
            }

            db.Entry(compra).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CompraExists(id))
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

        // POST: api/Compras
        [ResponseType(typeof(Compra))]
        public async Task<IHttpActionResult> PostCompra(Compra compra)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Compras.Add(compra);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = compra.ID }, compra);
        }

        // DELETE: api/Compras/5
        [ResponseType(typeof(Compra))]
        public async Task<IHttpActionResult> DeleteCompra(int id)
        {
            Compra compra = await db.Compras.FindAsync(id);
            if (compra == null)
            {
                return NotFound();
            }

            db.Compras.Remove(compra);
            await db.SaveChangesAsync();

            return Ok(compra);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CompraExists(int id)
        {
            return db.Compras.Count(e => e.ID == id) > 0;
        }
    }
}