using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Tienda2013407.Models;

namespace Tienda2013407.Controllers
{
    public class AutenticarController : ApiController
    {
        private Tienda2013407Context db = new Tienda2013407Context();

        //Post: api/Autenticar
        [ResponseType(typeof(Usuario))]
        public async Task<IHttpActionResult> PostAutenticar(Usuario usuario)
        {
            Usuario usr = await db.Usuarios.FirstOrDefaultAsync(us => us.nick == usuario.nick && us.pass == usuario.pass);
            if (usr == null)
            {
                return NotFound();
            }
            usr.pass = "none";
            usr.nick = "none";
            return Ok();
        }

         protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UsuarioExists(int id)
        {
            return db.Usuarios.Count(e => e.ID == id) > 0;
        }
    }
    }
