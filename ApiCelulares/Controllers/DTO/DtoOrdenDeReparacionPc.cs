using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCelulares.Controllers.DTO
{
    public class DtoOrdenDeReparacionPc
    {
        public int DtoOrdenDeReparacionPcId { get; set; }
        public  DateTime fechaIngreso { get; set; }
        public string fecheEgreso { get; set; }
        //Se declara lo que hay que hacer a la pc
        public  string detalleOrden { get; set; }
        public  double precio { get; set; }
        //Se declara el estado actual en el que encuentra el equipo cuando se deja
        public  string diagnosticoPc { get; set; }
        public string dni { get; set; }
        public string nombreMarcaPc { get; set; }
        public string nombreModeloPc { get; set; }
        public string versionPc { get; set; }
        //En que etapa se encuentra el equipo (a reparar, reparado, etc....)
        public string estado { get; set; }
        //Se declara el informe cuando se entrega la pc
        public string detalleReparacion { get; set; }
        public double presupuesto { get; set; }
        public double seña { get; set; }
        public string proveedor { get; set; }
        public double costoRepuesto { get; set; }

    }
}
