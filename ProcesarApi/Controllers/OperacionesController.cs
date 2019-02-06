using ProcesarApi.Models;
using System.Net;
using System.Web.Http;

namespace ProcesarApi.Controllers
{
    public class OperacionesController : ApiController
    {
        public IHttpActionResult Post(Operacion op)
        {
            if (op.TipoOperacion == null)
            {
                return NotFound();
            }

            double resultado = op.Procesar(op);

            return Content(HttpStatusCode.OK, resultado);
        }
    }
}
