using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCelulares.Controllers.DTO
{
    public class DtoOrdenDeReparacionCelular
    {
        public int DtoOrdenDeReparacionCelularId { get; set; }
        public  DateTime fechaIngreso { get; set; }
        public  string fecheEgreso { get; set; }
        //Se declara lo que hay que hacer a la celular
        public string detalleOrden { get; set; }
        public  double precio { get; set; }
        public  string  dni { get; set; }
        public  string empresa { get; set; }
        public  bool chip { get; set; }
        public  bool tarjetaSD { get; set; }
        //Se declara el estado actual en el que encuentra el equipo cuando se deja
        public string diagnosticoCelular { get; set; }
        public  int pin { get; set; }
        public string patron { get; set; }
        //En que etapa se encuentra el equipo (a reparar, reparado, etc....)
        public string estado { get; set; }
        public string nombreMarcaCelular { get; set; }
        public string nombreModeloCelular { get; set; }
        public string versionCelular { get; set; }
        //Se declara el informe cuando se entrega la pc
        public string detalleReparacion { get; set; }
        public bool enciende { get; set; }
        public double presupuesto { get; set; }
        public double seña { get; set; }
        public string proveedor { get; set; }
        public double costoRepuesto { get; set; }
    }
}
