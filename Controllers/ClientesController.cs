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
    public class ClientesController
    {
        public bool Guardar(Clientes clientes)
        {
            Contexto contexto = new Contexto();
            bool paso = false;
            try
            {
                if (clientes.ClienteId == 0)
                {
                    paso = Insertar(clientes);
                }
                else
                {
                    paso = Modificar(clientes);
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
            Contexto contexto = new Contexto();
            bool paso = false;
            try
            {
                contexto.Clientes.Add(clientes);
                paso = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            return paso;
        }
        private bool Modificar(Clientes clientes)
        {
            Contexto contexto = new Contexto();
            bool paso = false;
            try
            {
                contexto.Clientes.Add(clientes);
                contexto.Entry(clientes).State = EntityState.Modified;
                paso = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            return paso;
        }

        public Clientes Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Clientes clientes = new Clientes();
            try
            {
                clientes = contexto.Clientes.Find(id);
            }
            catch (Exception)
            {
                throw;
            }
            return clientes;
        }
        public bool Eliminar(int id)
        {
            Contexto contexto = new Contexto();
            bool paso = false;
            Clientes clientes = new Clientes();

            try
            {
                clientes = contexto.Clientes.Find(id);
                contexto.Entry(clientes).State = EntityState.Deleted;
                paso = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            return paso;
        }
        public List<Clientes> GetList(Expression<Func<Clientes, bool>> expression)
        {
            Contexto contexto = new Contexto();
            List<Clientes> lista;
            try
            {
                lista = contexto.Clientes.Where(expression).ToList();
            }
            catch (Exception)
            {
                throw;
            }
            return lista;
        }

    }
}
