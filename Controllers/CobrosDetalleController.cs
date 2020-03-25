using Aplicada2ProyectoFinal.Data;
using Aplicada2ProyectoFinal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Aplicada2ProyectoFinal.Controllers
{
    public class CobrosDetalleController
    {
        public static List<CobrosDetalle> GetList(Expression<Func<CobrosDetalle, bool>> expression)
        {
            List<CobrosDetalle> detalles = new List<CobrosDetalle>();
            Contexto contexto = new Contexto();
            try
            {
                detalles = contexto.CobrosDetalles.Where(expression).ToList();
                detalles.ToList().Count();
            }
            catch (Exception) { throw; }
            return detalles;
        }
    }
}
