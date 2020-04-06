using Aplicada2ProyectoFinal.Data;
using Aplicada2ProyectoFinal.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Aplicada2ProyectoFinal.Controllers
{
    public class ArticulosController
    {
        public bool Guardar(Articulos articulo)
        {
            Contexto contexto = new Contexto();
            bool paso = false;
            try
            {
                if (articulo.ArticuloId == 0)
                {
                    paso = Insertar(articulo);
                }
                else
                {
                    paso = Modificar(articulo);
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return paso;
        }

        private bool Insertar(Articulos articulo)
        {
            Contexto contexto = new Contexto();
            bool paso = false;
            try
            {
                contexto.Articulos.Add(articulo);
                paso = contexto.SaveChanges() > 0;

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return paso;
        }

        private bool Modificar(Articulos articulo)
        {
            Contexto contexto = new Contexto();
            bool paso = false;

            try
            {
                Articulos ArticuloTemporal = contexto.Articulos.Find(articulo.ArticuloId);
                if (ArticuloTemporal != null)
                {
                    contexto = new Contexto();
                    contexto.Entry(articulo).State = EntityState.Modified;
                    paso = contexto.SaveChanges() > 0;
                }
            }
            catch (Exception)
            {
                throw;

            }
            finally
            {
                contexto.Dispose();

            }

            return paso;
        }

        public Articulos Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Articulos articulo = new Articulos();

            try
            {
                articulo = contexto.Articulos.Find(id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return articulo;
        }

        public bool Eliminar(int id)
        {
            Contexto contexto = new Contexto();
            bool paso = false;
            Articulos articulo = new Articulos();
            try
            {
                articulo = contexto.Articulos.Find(id);
                contexto.Entry(articulo).State = EntityState.Deleted;
                paso = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return paso;
        }

        public List<Articulos> GetList(Expression<Func<Articulos, bool>> expression)
        {
            Contexto contexto = new Contexto();
            List<Articulos> ListadoArticulos = new List<Articulos>();

            try
            {
                ListadoArticulos = contexto.Articulos.Where(expression).ToList();

            }
            catch (Exception)
            {
                throw;

            }
            finally
            {
                contexto.Dispose();

            }

            return ListadoArticulos;
        }
    }
}
