﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Aplicada2ProyectoFinal.Models
{
    public class EmpeñosDetalle
    {
        [Key]
        public int EmpeñoDetalleId { get; set; }
        public int EmpeñoId { get; set; }
        public int ArticuloId { get; set; }
        public string Articulo { get; set; }
        public string Descripcion { get; set; }
        public int Cantidad { get; set; }
        public decimal Monto { get; set; }
        public EmpeñosDetalle()
        {
            EmpeñoDetalleId = 0;
            EmpeñoId = 0;
        }
        public EmpeñosDetalle(int id, int empeñoId, int articuloId, string articulo, string descripcion, int cantidad, decimal monto)
        {
            id = EmpeñoDetalleId;
            EmpeñoId = empeñoId;
            ArticuloId = articuloId;
            Articulo = articulo;
            Descripcion = descripcion;
            Cantidad = cantidad;
            Monto = monto;
        }
    }
}
