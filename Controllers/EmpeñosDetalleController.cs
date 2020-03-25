using Aplicada2ProyectoFinal.Data;
using Aplicada2ProyectoFinal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Aplicada2ProyectoFinal.Controllers
{
    public class EmpeñosDetalleController
    {
        public static List<EmpeñosDetalle> GetList(Expression<Func<EmpeñosDetalle, bool>> expression)
        {
            List<EmpeñosDetalle> detalles = new List<EmpeñosDetalle>();
            Contexto contexto = new Contexto();
            try
            {
                detalles = contexto.EmpeñosDetalles.Where(expression).ToList();
                detalles.ToList().Count();
            }
            catch (Exception) { throw; }
            return detalles;
        }
    }
}
