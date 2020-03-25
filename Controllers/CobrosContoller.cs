using Aplicada2ProyectoFinal.Data;
using Aplicada2ProyectoFinal.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Aplicada2ProyectoFinal.Controllers
{
    public class CobrosContoller
    {
        private static int AumentoDias(decimal abono, decimal monto)
        {
            decimal res = 0;
            res = monto * Convert.ToDecimal(0.05);
            int dias = Convert.ToInt32(15 / (res / abono));
            return dias;
        }

        public static decimal Quincenas(DateTime fecha, decimal monto)
        {
            decimal res = 0;
            var resultado = Math.Abs((fecha.Date - DateTime.Now.Date).TotalDays);
            if (resultado <= 15)
            {
                res = monto * Convert.ToDecimal(0.05);
                monto += res;
            }
            if (resultado >= 15 && resultado <= 30)
            {
                res = monto * Convert.ToDecimal(0.10);
                monto += res;
            }
            if (resultado >= 30 && resultado <= 45)
            {
                res = monto * Convert.ToDecimal(0.15);
                monto += res;
            }
            if (resultado >= 60 && resultado <= 75)
            {
                res = monto * Convert.ToDecimal(0.20);
                monto += res;
            }
            if (resultado == 75 && resultado <= 90)
            {
                res = monto * Convert.ToDecimal(0.25);
                monto += res;
            }
            if (resultado == 90 && resultado <= 95)
            {
                res = monto * Convert.ToDecimal(0.30);
                monto += res;
            }
            return monto;
        }

        public static decimal Ganancia(DateTime fecha, decimal monto)
        {
            decimal res = 0;
            var resultado = Math.Abs((fecha.Date - DateTime.Now.Date).TotalDays);

            if (resultado <= 15)
            {
                res = monto * Convert.ToDecimal(0.05);
            }

            if (resultado >= 15 && resultado <= 30)
            {
                res = monto * Convert.ToDecimal(0.10);
            }
            if (resultado >= 30 && resultado <= 45)
            {
                res = monto * Convert.ToDecimal(0.15);
            }
            if (resultado >= 60 && resultado <= 75)
            {
                res = monto * Convert.ToDecimal(0.20);
            }
            if (resultado == 75 && resultado <= 90)
            {
                res = monto * Convert.ToDecimal(0.25);
            }
            if (resultado == 90 && resultado <= 95)
            {
                res = monto * Convert.ToDecimal(0.30);
            }
            return res;
        }
        public static bool Guardar(Cobros cobro)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            EmpeñosController controller = new EmpeñosController();
            try
            {
                if (contexto.Cobros.Add(cobro) != null)
                {
                    contexto.Empeños.Find(cobro.EmpeñoId).Abono += cobro.Abono;
                    foreach (var item in controller.GetList(x => x.EmpeñoId == cobro.EmpeñoId))
                    {
                        contexto.Empeños.Find(cobro.EmpeñoId).UltimaFechadeVigencia = item.UltimaFechadeVigencia.AddDays(AumentoDias(cobro.Abono, item.MontoTotal));
                    }
                    contexto.SaveChanges();

                    foreach (var item in controller.GetList(x => x.EmpeñoId == cobro.EmpeñoId))
                    {
                        if ((item.MontoTotal + Ganancia(item.Fecha, item.MontoTotal)) - item.Abono == 0)
                        {
                            controller.EliminarParaCobro(cobro.EmpeñoId);
                        }
                    }
                    paso = true;
                }
                contexto.Dispose();
            }
            catch (Exception) { throw; }
            return paso;
        }

        public static bool Eliminar(int id)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            EmpeñosController controller = new EmpeñosController();
            try
            {
                Cobros cobro = contexto.Cobros.Find(id);
                if (cobro != null)
                {
                    contexto.Empeños.Find(cobro.EmpeñoId).Abono -= cobro.Abono;
                    foreach (var item in controller.GetList(x => x.EmpeñoId == cobro.EmpeñoId))
                    {
                        contexto.Empeños.Find(cobro.EmpeñoId).UltimaFechadeVigencia = item.UltimaFechadeVigencia.AddDays(-AumentoDias(cobro.Abono, item.MontoTotal));
                    }
                    contexto.Entry(cobro).State = EntityState.Deleted;
                }
                if (contexto.SaveChanges() > 0)
                {
                    paso = true;
                    contexto.Dispose();
                }
            }
            catch (Exception) { throw; }
            return paso;
        }
        public static bool Modificar(Cobros cobro)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            EmpeñosController controller = new EmpeñosController();
            try
            {
                Cobros Anterior = Buscar(cobro.CobroId);
                decimal diferencia;
                diferencia = Anterior.Abono + cobro.Abono;
                decimal otradif = Anterior.Abono - cobro.Abono;
                Empeños recibos = controller.Buscar(cobro.EmpeñoId);
                recibos.Abono = Math.Abs(recibos.Abono - diferencia);
                recibos.UltimaFechadeVigencia = recibos.UltimaFechadeVigencia.AddDays(-AumentoDias(Anterior.Abono, recibos.MontoTotal));
                recibos.UltimaFechadeVigencia = recibos.UltimaFechadeVigencia.AddDays(AumentoDias(cobro.Abono, recibos.MontoTotal));
                EmpeñosController.ModificarEspecial(recibos);
                foreach (var item in controller.GetList(x => x.EmpeñoId == cobro.EmpeñoId))
                {
                    if ((item.MontoTotal + Ganancia(item.Fecha, item.MontoTotal)) - item.Abono == 0)
                    {
                        controller.EliminarParaCobro(cobro.EmpeñoId);

                    }
                }
                contexto.Entry(cobro).State = EntityState.Modified;
                if (contexto.SaveChanges() > 0)
                {
                    paso = true;
                }
                contexto.Dispose();
            }
            catch (Exception) { throw; }
            return paso;
        }
        public static Cobros Buscar(int id)
        {
            Cobros cobro = new Cobros();
            Contexto contexto = new Contexto();
            try
            {
                cobro = contexto.Cobros.Find(id);
                contexto.Dispose();
            }
            catch (Exception) { throw; }
            return cobro;

        }
        public static List<Cobros> GetList(Expression<Func<Cobros, bool>> expression)
        {
            List<Cobros> cobro = new List<Cobros>();
            Contexto contexto = new Contexto();
            try
            {
                cobro = contexto.Cobros.Where(expression).ToList();
                contexto.Dispose();
            }
            catch (Exception) { throw; }
            return cobro;
        }
    }
}
