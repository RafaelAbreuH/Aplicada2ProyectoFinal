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
    public class CategoriasController
    {
        public bool Guardar(Categorias categorias)
        {
            Contexto contexto = new Contexto();
            bool paso = false;
            try
            {
                if (categorias.CategoriaId == 0)
                {
                    paso = Insertar(categorias);
                }
                else
                {
                    paso = Modificar(categorias);
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
        private bool Insertar(Categorias categorias)
        {
            Contexto contexto = new Contexto();
            bool paso = false;
            try
            {
                contexto.Categorias.Add(categorias);
                paso = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            return paso;
        }
        private bool Modificar(Categorias categorias)
        {
            Contexto contexto = new Contexto();
            bool paso = false;
            try
            {
                contexto.Categorias.Add(categorias);
                contexto.Entry(categorias).State = EntityState.Modified;
                paso = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            return paso;
        }

        public Categorias Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Categorias categorias = new Categorias();
            try
            {
                categorias = contexto.Categorias.Find(id);
            }
            catch (Exception)
            {
                throw;
            }
            return categorias;
        }
        public bool Eliminar(int id)
        {
            Contexto contexto = new Contexto();
            bool paso = false;
            Categorias categorias = new Categorias();

            try
            {
                categorias = contexto.Categorias.Find(id);
                contexto.Entry(categorias).State = EntityState.Deleted;
                paso = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            return paso;
        }
        public List<Categorias> GetList(Expression<Func<Categorias, bool>> expression)
        {
            Contexto contexto = new Contexto();
            List<Categorias> lista;
            try
            {
                lista = contexto.Categorias.Where(expression).ToList();
            }
            catch (Exception)
            {
                throw;
            }
            return lista;
        }
    }
}
