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
            List<EmpeñosDetalle> recibos = new List<EmpeñosDetalle>();
            Contexto contexto = new Contexto();
            try
            {
                recibos = contexto.EmpeñosDetalles.Where(expression).ToList();
                recibos.ToList().Count();
            }
            catch (Exception) { throw; }
            return recibos;
        }
    }
}
