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
    public class TipoUsuariosController
    {
        public bool Guardar(TiposUsuarios TipoUsuario)
        {
            Contexto contexto = new Contexto();
            bool paso = false;
            try
            {
                if (TipoUsuario.TipoUsuarioId == 0)
                {
                    paso = Insertar(TipoUsuario);
                }
                else
                {
                    paso = Modificar(TipoUsuario);
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
        private bool Insertar(TiposUsuarios TipoUsuario)
        {
            Contexto contexto = new Contexto();
            bool paso = false;
            try
            {
                contexto.TiposUsuarios.Add(TipoUsuario);
                paso = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            return paso;
        }
        private bool Modificar(TiposUsuarios TipoUsuario)
        {
            Contexto contexto = new Contexto();
            bool paso = false;
            try
            {
                contexto.TiposUsuarios.Add(TipoUsuario);
                contexto.Entry(TipoUsuario).State = EntityState.Modified;
                paso = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            return paso;
        }

        public TiposUsuarios Buscar(int id)
        {
            Contexto contexto = new Contexto();
            TiposUsuarios TipoUsuario = new TiposUsuarios();
            try
            {
                TipoUsuario = contexto.TiposUsuarios.Find(id);
            }
            catch (Exception)
            {
                throw;
            }
            return TipoUsuario;
        }
        public bool Eliminar(int id)
        {
            Contexto contexto = new Contexto();
            bool paso = false;
            TiposUsuarios TipoUsuario = new TiposUsuarios();

            try
            {
                TipoUsuario = contexto.TiposUsuarios.Find(id);
                contexto.Entry(TipoUsuario).State = EntityState.Deleted;
                paso = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            return paso;
        }
        public List<TiposUsuarios> GetList(Expression<Func<TiposUsuarios, bool>> expression)
        {
            Contexto contexto = new Contexto();
            List<TiposUsuarios> lista;
            try
            {
                lista = contexto.TiposUsuarios.Where(expression).ToList();
            }
            catch (Exception)
            {
                throw;
            }
            return lista;
        }
    }
}
