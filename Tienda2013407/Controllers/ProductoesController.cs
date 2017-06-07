using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Tienda2013407.Models;

namespace Tienda2013407.Controllers
{
    public class ProductoesController : ApiController
    {
        private Tienda2013407Context db = new Tienda2013407Context();

        // GET: api/Productoes
        public IQueryable<Producto> GetProductoes()
        {
            return db.Productoes;
        }

        // GET: api/Productoes/5
        [ResponseType(typeof(Producto))]
        public async Task<IHttpActionResult> GetProducto(int id)
        {
            Producto producto = await db.Productoes.FindAsync(id);
            if (producto == null)
            {
                return NotFound();
            }

            return Ok(producto);
        }

        // PUT: api/Productoes/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutProducto(int id, Producto producto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != producto.ID)
            {
                return BadRequest();
            }

            db.Entry(producto).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductoExists(id))
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

        // POST: api/Productoes
        [ResponseType(typeof(Producto))]
        public async Task<IHttpActionResult> PostProducto(Producto producto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Productoes.Add(producto);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = producto.ID }, producto);
        }

        // DELETE: api/Productoes/5
        [ResponseType(typeof(Producto))]
        public async Task<IHttpActionResult> DeleteProducto(int id)
        {
            Producto producto = await db.Productoes.FindAsync(id);
            if (producto == null)
            {
                return NotFound();
            }

            db.Productoes.Remove(producto);
            await db.SaveChangesAsync();

            return Ok(producto);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ProductoExists(int id)
        {
            return db.Productoes.Count(e => e.ID == id) > 0;
        }

        [HttpGet]
        public IHttpActionResult DownloadFile()
        {
            XLWorkbook wsBook = new XLWorkbook();
            var ws = wsBook.Worksheets.Add(db.Productoes.CastTo<DataTable>());
            ws.Columns().AdjustToContents();

            using (MemoryStream memoryStream = new MemoryStream())
            {
                System.Web.HttpResponse Res = System.Web.HttpContext.Current.Response;
                ws.Workbook.SaveAs(memoryStream);

                memoryStream.WriteTo(Res.OutputStream);
                memoryStream.Close();

                Res.Clear();
                Res.Buffer = true;
                Res.Charset = "";
                Res.ContentType = "application/ms-excel";
                Res.AddHeader("Content-Disposition", "attachment;filename=Products.xlsx;");
                Res.AddHeader("Content-Length", memoryStream.ToArray().Length.ToString());
                //Res.ContentEncoding = Encoding.UTF8;

                Res.BinaryWrite(memoryStream.ToArray());

                Res.Flush();
                Res.SuppressContent = true;
                System.Web.HttpContext.Current.ApplicationInstance.CompleteRequest();
                Res.Close();
                Res.End();

                return Ok();
            }
        }
    }
}