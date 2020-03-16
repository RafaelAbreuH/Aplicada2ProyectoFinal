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
            bool paso = false;
            Contexto db = new Contexto();
            try
            {
                db.Usuarios.Add(usuarios);
                paso = db.SaveChanges() > 0;
            }
            catch (Exception)
            {

                throw;
            }
            return paso;
        }

        public bool Modificar(Usuarios usuarios)
        {
            bool paso = false;
            Contexto db = new Contexto();
            try
            {
                db.Entry(usuarios).State = EntityState.Modified;
                paso = db.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            return paso;
        }

        public Usuarios Buscar(int id)
        {
            Usuarios usuarios = new Usuarios();
            Contexto db = new Contexto();
            try
            {
                usuarios = db.Usuarios.Find(id);
            }
            catch (Exception)
            {
                throw;
            }

            return usuarios;
        }
        public bool Eliminar(int id)
        {
            Usuarios usuarios = new Usuarios();
            bool paso = false;
            Contexto db = new Contexto();
            try
            {
                var eliminar = db.Usuarios.Find(id);
                db.Entry(eliminar).State = EntityState.Deleted;
                paso = db.SaveChanges() > 0;
            }
            catch (Exception)
            {

                throw;
            }
            return paso;
        }

        public List<Usuarios> GetList(Expression<Func<Usuarios, bool>> expression)
        {
            List<Usuarios> lista = new List<Usuarios>();
            Contexto db = new Contexto();

            try
            {
                lista = db.Usuarios.Where(expression).ToList();
            }
            catch (Exception)
            {

                throw;
            }

            return lista;
        }
    }
}
