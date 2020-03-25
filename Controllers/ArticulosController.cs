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
            public bool Guardar(Articulos articulos)
            {
                Contexto contexto = new Contexto();
                bool paso = false;
                try
                {
                    if (articulos.ArticuloId == 0)
                    {
                        paso = Insertar(articulos);
                    }
                    else
                    {
                        paso = Modificar(articulos);
                    }
                }
                catch (Exception)
                {
                    throw;
                }
                return paso;
            }
            private bool Insertar(Articulos articulos)
            {
                Contexto contexto = new Contexto();
                bool paso = false;
                try
                {
                    contexto.Articulos.Add(articulos);
                    paso = contexto.SaveChanges() > 0;
                }
                catch (Exception)
                {
                    throw;
                }
                return paso;
            }
            private bool Modificar(Articulos articulos)
            {
                Contexto contexto = new Contexto();
                bool paso = false;
                try
                {
                    contexto.Articulos.Add(articulos);
                    contexto.Entry(articulos).State = EntityState.Modified;
                    paso = contexto.SaveChanges() > 0;
                }
                catch (Exception)
                {
                    throw;
                }
                return paso;
            }

            public Articulos Buscar(int id)
            {
                Contexto contexto = new Contexto();
                Articulos articulos = new Articulos();
                try
                {
                    articulos = contexto.Articulos.Find(id);
                }
                catch (Exception)
                {
                    throw;
                }
                return articulos;
            }
            public bool Eliminar(int id)
            {
                Contexto contexto = new Contexto();
                bool paso = false;
                Articulos articulos = new Articulos();

                try
                {
                    articulos = contexto.Articulos.Find(id);
                    contexto.Entry(articulos).State = EntityState.Deleted;
                    paso = contexto.SaveChanges() > 0;
                }
                catch (Exception)
                {
                    throw;
                }
                return paso;
            }
            public List<Articulos> GetList(Expression<Func<Articulos, bool>> expression)
            {
                Contexto contexto = new Contexto();
                List<Articulos> lista;
                try
                {
                    lista = contexto.Articulos.Where(expression).ToList();
                }
                catch (Exception)
                {
                    throw;
                }
                return lista;
            }
            public string RetornarNombre(string nombre)
            {
            string descripcion = string.Empty;
            var lista = GetList(x => x.Nombre.Equals(nombre));
            foreach (var item in lista)
            {
                descripcion = item.Nombre;
            }
            return descripcion;
            }
    }
}
