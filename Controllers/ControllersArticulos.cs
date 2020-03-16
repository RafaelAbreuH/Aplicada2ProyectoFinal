using Aplicada2ProyectoFinal.Data;
using Aplicada2ProyectoFinal.Modals;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Aplicada2ProyectoFinal.Controllers
{
    public class ControllersArticulos
    {

        public bool Guardar(Articulos articulos)
        {
            bool paso = false;
            Contexto db = new Contexto();
            try
            {
                db.Articulos.Add(articulos);
                paso = db.SaveChanges() > 0;
            }
            catch (Exception)
            {

                throw;
            }



            return paso;
        }

        public bool Modificar(Articulos articulos)
        {
            bool paso = false;
            Contexto db = new Contexto();
            try
            {
                db.Entry(articulos).State = EntityState.Modified;
                paso = db.SaveChanges() > 0;
            }
            catch (Exception)
            {

                throw;
            }
            return paso;
        }

        public Articulos Buscar(int id)
        {
            Articulos articulos = new Articulos();
            Contexto db = new Contexto();
            try
            {
                articulos = db.Articulos.Find(id);
            }
            catch (Exception)
            {

                throw;
            }

            return articulos;
        }
        public bool Eliminar(int id)
        {
            Articulos articulos = new Articulos();
            bool paso = false;
            Contexto db = new Contexto();
            try
            {
                var eliminar = db.Articulos.Find(id);
                db.Entry(eliminar).State = EntityState.Deleted;
                paso = db.SaveChanges() > 0;
            }
            catch (Exception)
            {

                throw;
            }
            return paso;
        }
        public List<Articulos> GetList(Expression<Func<Articulos, bool>> expression)
        {
            List<Articulos> lista = new List<Articulos>();
            Contexto db = new Contexto();

            try
            {
                lista = db.Articulos.Where(expression).ToList();
            }
            catch (Exception)
            {

                throw;
            }
            return lista;
        }
    }
}
