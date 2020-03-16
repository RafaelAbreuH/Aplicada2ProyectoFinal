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
    public class ControllersCliente
    {
        public bool Guardar(Clientes clientes)
        {
            bool paso = false;
            Contexto db = new Contexto();
            try
            {
                if (db.Clientes.Any(A => A.ClienteId == clientes.ClienteId))
                {
                    paso = Modificar(clientes);
                }
                else
                {
                    paso = Insertar(clientes);
                }
            }
            catch (Exception)
            {

                throw;
            }
            return paso;
        }


        private bool Insertar(Clientes clientes)
        {
            Contexto db = new Contexto();
            bool paso = false;

            try
            {
                db.Clientes.Add(clientes);
                paso = db.SaveChanges() > 0;
            }
            catch (Exception)
            {

                throw;
            }

            return paso;
        }

        private bool Modificar(Clientes clientes)
        {
            bool paso = false;
            Contexto db = new Contexto();
            try
            {
                db.Entry(clientes).State = EntityState.Modified;
                paso = db.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            return paso;
        }

        public bool Eliminar(int id)
        {
            bool paso = false;
            Contexto db = new Contexto();

            try
            {
                Clientes clientes = db.Clientes.Find(id);
                if (clientes != null)
                {
                    db.Entry(clientes).State = EntityState.Deleted;
                    paso = db.SaveChanges() > 0;
                }
            }
            catch (Exception)
            {

                throw;
            }
            return paso;
        }

        public Clientes Buscar(int id)
        {
            Clientes clientes;
            Contexto db = new Contexto();
            try
            {
                clientes = db.Clientes.Find(id);
            }
            catch (Exception)
            {

                throw;
            }
            return clientes;
        }

        public List<Clientes> GetList(Expression<Func<Clientes, bool>> expression)
        {
            Contexto db = new Contexto();
            List<Clientes> lista = new List<Clientes>();

            try
            {
                lista = db.Clientes.Where(expression).ToList();
            }
            catch (Exception)
            {

                throw;
            }
            return lista;
        }

    }
}
