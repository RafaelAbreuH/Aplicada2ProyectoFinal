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
    public class UsuariosController
    {

        public bool Guardar(Usuarios usuarios)
        {
            Contexto contexto = new Contexto();
            bool paso = false;
            try
            {
                if (usuarios.UsuarioId == 0)
                {
                    paso = Insertar(usuarios);
                }
                else
                {
                    paso = Modificar(usuarios);
                }
            }
            catch (Exception)
            {
                throw;
            }
            return paso;
        }
        private bool Insertar(Usuarios usuarios)
        {
            Contexto contexto = new Contexto();
            bool paso = false;
            try
            {
                contexto.Usuarios.Add(usuarios);
                paso = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            return paso;
        }
        private bool Modificar(Usuarios usuarios)
        {
            Contexto contexto = new Contexto();
            bool paso = false;
            try
            {
                contexto.Usuarios.Add(usuarios);
                contexto.Entry(usuarios).State = EntityState.Modified;
                paso = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            return paso;
        }

        public Usuarios Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Usuarios usuarios = new Usuarios();
            try
            {
                usuarios = contexto.Usuarios.Find(id);
            }
            catch (Exception)
            {
                throw;
            }
            return usuarios;
        }
        public bool Eliminar(int id)
        {
            Contexto contexto = new Contexto();
            bool paso = false;
            Usuarios usuarios = new Usuarios();

            try
            {
                usuarios = contexto.Usuarios.Find(id);
                contexto.Entry(usuarios).State = EntityState.Deleted;
                paso = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            return paso;
        }
        public List<Usuarios> GetList(Expression<Func<Usuarios, bool>> expression)
        {
            Contexto contexto = new Contexto();
            List<Usuarios> lista;
            try
            {
                lista = contexto.Usuarios.Where(expression).ToList();
            }
            catch (Exception)
            {
                throw;
            }
            return lista;
        }
    }
}
