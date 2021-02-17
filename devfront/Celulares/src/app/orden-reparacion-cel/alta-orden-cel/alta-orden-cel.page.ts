import { getLocaleDateTimeFormat } from '@angular/common';
import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { FormBuilder, NgForm } from '@angular/forms';
import { AlertService } from 'src/app/Services/alert-service/alert.service';
import { ClienteService } from 'src/app/Services/cliente-service/cliente.service';
import { LoadService } from 'src/app/Services/load-service/load.service';
import { OrdenReparacionCelService } from 'src/app/Services/ordenReparacionCel/orden-reparacion-cel.service';
import { PdfMakeWrapper , Columns , Table, Canvas, Line, Img} from 'pdfmake-wrapper';
import pdfMake from "pdfmake/build/pdfmake";
import pdfFonts from "pdfmake/build/vfs_fonts";
pdfMake.vfs = pdfFonts.pdfMake.vfs;
@Component({
  selector: 'app-alta-orden-cel',
  templateUrl: './alta-orden-cel.page.html',
  styleUrls: ['./alta-orden-cel.page.scss'],
})
export class AltaOrdenCelPage implements OnInit {
  @ViewChild('form') public AltaOrdenCelForm:NgForm;
  @ViewChild('formCli') public AltaOrdenCelFormCli:NgForm;
  valor:number=0;
  datosDniEncontrado=false;
  bdni:string;
  nombre:string;
  apellido:string;
  telefono:string;
  direccion:string;
  email:string;
  datosCliente=false;
  fechaIngreso:Date;
  fechaIngresoImprimir:string;
  fecheEgreso:string;
  detalleOrden:string;
  precio:number;
  dni:string;
  empresa:string;
  chip:boolean=false;
  tarjetaSD:boolean=false;
  diagnosticoCelular:string;
  pin:number;
  patron:string;
  estado:string="A reparar";
  nombreMarcaCelular:string;
  nombreModeloCelular:string;
  versionCelular:string;
  empresaCelular:string;
  detalleReparacion:string;
  enciende:boolean=false;
  presupuesto:number;
  senia:number;
  proveedor:string;
  costoRepuesto:number;
  dniCliente:string;
  dniNC:string;
  cliente=null;
  constructor(public ordenReparacionCel:OrdenReparacionCelService,private clienteService:ClienteService,
    public loadService:LoadService, public alertService:AlertService) { }

  ngOnInit() {
    this.datosCliente=false ;
  this.datosDniEncontrado=false;

  }
 AgregarOrden()
 {
  this.loadService.presentLoadingWithTime("Agregando Orden Reparación",5);
  if (this.datosCliente==true) {
    let unCliente={
      "dtoClienteId": 0,
      "nombre": this.nombre,
      "apellido": this.apellido,
      "telefono": this.telefono,
      "email": this.email,
      "dni": this.dniNC,
      "direccion": this.direccion,
    }
    this.AgregarCliente(unCliente);
    console.log("va en agregar");
    console.log(this.dniNC);
    console.log("valor dni");
    console.log(this.dni);
    
    let unaReparacion={
      "dtoOrdenDeReparacionCelularId":0,
      "fechaIngreso": this.fechaIngreso,
      "fecheEgreso": "",
      "detalleOrden": this.detalleOrden,
      "precio": this.precio,
      "dni": this.dniNC,
      "empresa": this.empresa,
      "chip": this.chip,
      "tarjetaSD": this.tarjetaSD,
      "diagnosticoCelular": this.diagnosticoCelular,
      "pin": this.pin,
      "patron": this.patron,
      "estado": this.estado,
      "nombreMarcaCelular": this.nombreMarcaCelular,
      "nombreModeloCelular": this.nombreModeloCelular,
      "versionCelular": this.versionCelular,
      "detalleReparacion": this.detalleReparacion,
      "enciende": this.enciende,
      "presupuesto":this.presupuesto,
      "senia":this.senia,
      "proveedor":this.proveedor,
      "costoRepuesto":this.costoRepuesto,

    }
    console.log(unaReparacion);
    this.CargarOrden(unaReparacion);
  } 
  else {
    let unaReparacion={
      "dtoOrdenDeReparacionCelularId":0,
      "fechaIngreso": this.fechaIngreso,
      "fecheEgreso": "",
      "detalleOrden": this.detalleOrden,
      "precio": this.precio,
      "dni": this.dni,
      "empresa": this.empresa,
      "chip": this.chip,
      "tarjetaSD": this.tarjetaSD,
      "diagnosticoCelular": this.diagnosticoCelular,
      "pin": this.pin,
      "patron": this.patron,
      "estado": this.estado,
      "nombreMarcaCelular": this.nombreMarcaCelular,
      "nombreModeloCelular": this.nombreModeloCelular,
      "versionCelular": this.versionCelular,
      "detalleReparacion": this.detalleReparacion,
      "enciende": this.enciende,
      "presupuesto":this.presupuesto,
      "seña":this.senia,
      "proveedor":this.proveedor,
      "costoRepuesto":this.costoRepuesto,
    }
    console.log(unaReparacion);
      this.CargarOrden(unaReparacion);
  }
 }

 CargarOrden(unaReparacion)
 {
  this.ordenReparacionCel.AgregarOrdenReparacionCelular(unaReparacion).then(
    (resultado)=>{
      this.alertService.presentAlert('Ok','Reparacion Cargada','Registro Exitoso');
      this.GenerarPDF();
      this.AltaOrdenCelForm.reset();
      this.AltaOrdenCelFormCli.reset();
      this.datosCliente=false ;
      this.datosDniEncontrado=false;
      this.dni="";
      this.dniNC="";
      this.chip=false;
      this.enciende=false;
      this.tarjetaSD=false;
      console.log( this.chip);
      console.log( this.enciende);
      console.log( this.tarjetaSD);
      console.log(resultado);
    }).catch((error)=>
    {
      this.alertService.presentAlert('Error','Error al cargar, Vuelva intentar',error.error);
      console.log(error);
    })
 }
 AgregarCliente(unCliente)
 {
  this.clienteService.AgregarUnCliente(unCliente).then(
    (resultado)=>{
      console.log(resultado);
    }).catch((error)=>
    {
    //  this.alertService.presentAlert('Error','Error al cargar cliente',error.error);
      console.log(error);
    })
 }
 BuscarClienteDni(pDni)
 {  
  
  this.loadService.presentLoadingWithTime("Buscando Cliente..",6);
  this.clienteService.ObtenerUnClientePorDni(pDni).then(
    (resultado)=>{
      this.cliente=resultado;
      this.alertService.presentAlert("Ok","Cliente Encontrado", pDni);
      this.datosCliente=false ;
      this.datosDniEncontrado=true;
      this.dni=pDni;
      this.nombre = this.cliente.nombre;
      this.apellido=this.cliente.apellido;
      this.telefono=this.cliente.telefono;
      console.log( this.nombre);
      console.log(resultado);
    }).catch((error)=>
    {
      if (pDni==null) {
        this.alertService.presentAlert("Debe ingresar un Dni",error.error,pDni);
      }
      else {
      this.alertService.presentAlert("Dni no registrado",error.error,pDni);
      this.nombre="";
      this.apellido="";
      this.telefono="";
      this.dni=pDni;
      this.dniNC=pDni;
      this.datosCliente=true ;
      this.datosDniEncontrado=false;
      console.log(error);
      console.log( this.dniNC);
      console.log( this.dni);
      }
    })
}

cancel(){
  this.cliente = null;
}
boolChip() {
  this.chip = !this.chip
  console.log(this.chip+"chip");   
}
boolTarjetaSd() {
  this.tarjetaSD = !this.tarjetaSD
  console.log(this.tarjetaSD+"tarjeta");   
}
boolEnciende() {
  this.enciende = !this.enciende
  console.log(this.enciende+"enciende");   
}
Limpiarpantalla()
{
   this.fechaIngreso=new Date;
     this.detalleOrden="";
      this.precio=0;
      this.dni="";
      this.empresa="";
       this.chip=false;
     this.tarjetaSD=false;
      this.diagnosticoCelular="";
     this.pin=0;
       this.patron="";
      this.estado="";
       this.nombreMarcaCelular="";
       this.nombreModeloCelular="";
      this.versionCelular="";
       this.detalleReparacion="";
      this.enciende=false;
  
}
async GenerarPDF(){
  this.ionViewWillEnter();
  let apellidoImprimir= this.apellido;
  let nombreImprimir= this.nombre;
  let dniImprimir= this.dni;
  let telefonoImprimir= this.telefono;
  let marcaImprimir = this.nombreMarcaCelular;
  let modeloImprimir=this.nombreModeloCelular;
  let versionImprimir=this.versionCelular;
  let empresaImprimir=this.empresa;
  let chipImprimir=this.chip;
  let chipNombreImprimir:string;
  if (chipImprimir == true)
  {
    chipNombreImprimir = 'Si'
  }
  else 
  {
    chipNombreImprimir = 'No'
  }
  let pinImprimir=this.pin;
  let patronImprimir=this.patron;
  let detalleImprimir=this.detalleOrden;
  let diagnosticoImprimir=this.diagnosticoCelular;
  let presupuestoImprimir=this.presupuesto;
  let seniaImprimir=this.senia;
  let tarjetaSDImprimir=this.tarjetaSD;
  let tarjetaSDNombreImprimir:string;
  if (tarjetaSDImprimir==true)
  {
    tarjetaSDNombreImprimir = 'Si'
  }
  else
  {
    tarjetaSDNombreImprimir = 'No'
  }
  let enciendeImprimir=this.enciende;
  let enciendeNombreImprimir:string;
  if (enciendeImprimir == true)
  {
    enciendeNombreImprimir = 'Si'
  }
  else 
  {
    enciendeNombreImprimir = 'No'
  }
this.fechaIngresoImprimir=this.fechaIngreso.toString();
console.log(this.fechaIngresoImprimir+' fecha es');
let fechapdf=this.fechaIngresoImprimir.substr(0,10);
console.log(fechapdf +'fecha recortada es');
const pdf = new PdfMakeWrapper();
console.log("acaimnpri");
pdf.defaultStyle({
fontSize: 13,
alignment:"center",
color:"black",
bold: true,
});
/*pdf.pageSize({
width: 350,
height: 250
//595.28
});*/

pdf.pageSize('A4');

pdf.background( await new Img("../../assets/img/tecimp7.png").build());



pdf.add((' '));
pdf.add(('TecnoPhone - San Martin 781 - Local 1 - Cel: 3442485405'));  
pdf.add((' '));
pdf.add('Dni Cliente: '+ dniImprimir + '             ' + '                ' + 'N° de Orden Cel: '+ this.valor+'            ' + 'Fecha de ingreso: '+fechapdf); 
pdf.add((' '));
pdf.add('Datos del equipo:');
pdf.add((' '));
pdf.add('Marca: '+marcaImprimir);
pdf.add((' '));
pdf.add('Modelo: '+modeloImprimir);
pdf.add((' '));
pdf.add('Versión: '+versionImprimir);
pdf.add((' '));
pdf.add('Detalle: '+detalleImprimir);
pdf.add((' '));
pdf.add('Diagnóstico: '+diagnosticoImprimir);
pdf.add((' '));
pdf.add(('- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -'));
pdf.add((' '));
pdf.add(('TecnoPhone - San Martin 781 - Local 1 - Cel: 3442485405'));  
pdf.add((' '));
pdf.add('     N° de Orden: '+ this.valor + '               ' +      'Fecha de ingreso: '+fechapdf);
pdf.add((' '));
pdf.add('Apellido: '+ apellidoImprimir + '                                 ' + 'Nombre: ' +  nombreImprimir);
pdf.add((' '));
pdf.add('Dni Cliente: '+ dniImprimir +'                                  '+'Teléfono: ' + telefonoImprimir); 
pdf.add((' '));
pdf.add('Datos del equipo:');
pdf.add((' '));
pdf.add('Marca: '+marcaImprimir+'                               ' +'Modelo: ' + modeloImprimir);
pdf.add((' '));
pdf.add('Versión: '+versionImprimir+'                       '+'         Empresa: ' + empresaImprimir);
pdf.add((' '));
pdf.add('Chip: '+ chipNombreImprimir+'                 '+ 'TarjetaSD: ' + tarjetaSDNombreImprimir+'                 '+'Enciende: ' + enciendeNombreImprimir);
pdf.add((' '));
pdf.add(('Pin: ' + pinImprimir+'                 '+ 'Patrón: ' + patronImprimir));
pdf.add((' '));
pdf.add('Detalle: '+detalleImprimir);
pdf.add((' '));
pdf.add('Diagnóstico:'+diagnosticoImprimir);
pdf.add((' '));
pdf.add(('Presupuesto: '  + presupuestoImprimir + '                                 ' + 'Seña: ' + seniaImprimir));
pdf.add((' '));
pdf.add(('Fecha de entrega:      /        /        '));
pdf.add((' '));
pdf.add(('Importante: Para retirar el producto deberá presentar este comprobante. Transcurrido los 15 días a partir de la fecha de recepción del producto, la empresa facturará al cliente un cargo diario por depósito. Si el producto no fuera retirado dentro del plazo de 10 días a partir de la fecha de recepción del mismo por parte de la empresa, será considerado abandono en los términos de los artículos 2375/2525/2524 del código civil, quedando la empresa facultada a darle el destino que considere pertinente sin necesidad de informar previamente al cliente. Las señas tomadas tendrán una vigencia de 15 días de la fecha, sin derecho a reclamo ni reintegro.'));


pdf.pageMargins(10);
pdf.create().open(); 
this.valor=0;
}

ionViewWillEnter(){
  this.ordenReparacionCel.ObtenerUltimoId().then(
    (resultado:number)=>{
      this.valor= resultado;
      console.log(this.valor+'idrepa');
    }
   );
   console.log(this.valor+'valorrepaid');
}
estadoReparacion(value:string)
{ this.estado=value;
  console.log(value+" enciende2"); 
  console.log(this.estado+" el estado ahroa es"); 
}
}
