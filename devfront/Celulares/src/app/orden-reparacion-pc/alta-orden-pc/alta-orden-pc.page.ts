import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { FormBuilder, NgForm } from '@angular/forms';
import { AlertService } from 'src/app/Services/alert-service/alert.service';
import { ClienteService } from 'src/app/Services/cliente-service/cliente.service';
import { LoadService } from 'src/app/Services/load-service/load.service';
import { OrdenReparacionPcService } from 'src/app/Services/ordenReparacionPc/orden-reparacion-pc.service';
import { PdfMakeWrapper , Columns , Table, Canvas, Line, Img} from 'pdfmake-wrapper';
import pdfMake from "pdfmake/build/pdfmake";
import pdfFonts from "pdfmake/build/vfs_fonts";
import {Platform} from '@ionic/angular';


pdfMake.vfs = pdfFonts.pdfMake.vfs;
@Component({
  selector: 'app-alta-orden-pc',
  templateUrl: './alta-orden-pc.page.html',
  styleUrls: ['./alta-orden-pc.page.scss'],
})
export class AltaOrdenPcPage implements OnInit {
  @ViewChild('form') public AltaOrdenPcForm:NgForm;
  @ViewChild('formCli') public AltaOrdenPcFormCli:NgForm;
  estadoCombo:string="";
  valor:number=0;
  datosDniEncontrado=false;
  bdni:string;
  nombre:string;
  apellido:string;
  telefono:string;
  direccion:string;
  email:string;
  dni:string;
  datosCliente=false;
  fechaIngreso:Date;
  fechaIngresoImprimir:string;
  fecheEgreso:string;
  nombreMarcaPc:string;
  nombreModeloPc:string;
  versionPc:string;
  detalleOrden:string;
  diagnosticoPc:string;
  detalleReparacion:string;
  presupuesto:number;
  senia:number;
  precio:number;
  estado:string="A reparar";
  proveedor:string;
  costoRepuesto:number;
  dniCliente:string;
  dniNC:string;
  cliente=null;
  constructor(public ordenReparacionPc:OrdenReparacionPcService, private clienteService:ClienteService,
    public loadService:LoadService, public alertService:AlertService) { }

    ngOnInit() {
      this.datosCliente=false ;
    this.datosDniEncontrado=false;
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
   

   CargarOrden(unaReparacion)
   {
    this.ordenReparacionPc.AgregarOrdenReparacionPc(unaReparacion).then(
      (resultado)=>{
        this.alertService.presentAlert('Ok','Reparacion Cargada','Registro Exitoso');
        this.GenerarPDF();
        this.AltaOrdenPcForm.reset();
        this.AltaOrdenPcFormCli.reset();
        this.datosCliente=false ;
        this.datosDniEncontrado=false;
        this.dni="";
        this.dniNC="";
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
        "dtoOrdenDeReparacionPcId":0,
        "dni": this.dniNC,
        "fechaIngreso": this.fechaIngreso,
        "fecheEgreso": "",
        "nombreMarcaPc": this.nombreMarcaPc,
        "nombreModeloPc": this.nombreModeloPc,
        "versionPc": this.versionPc,
        "detalleOrden": this.detalleOrden,
        "diagnosticoPc": this.diagnosticoPc,
        "detalleReparacion": this.detalleReparacion,
        "presupuesto":this.presupuesto,
        "seña":this.senia,
        "precio":this.precio,
        "estado":this.estado,
        "proveedor":this.proveedor,
        "costoRepuesto":this.costoRepuesto,
      }
      console.log(unaReparacion);
      this.CargarOrden(unaReparacion);
    } 
    else {
      let unaReparacion={
        "dtoOrdenDeReparacionPcId":0,
        "dni": this.dni,
        "fechaIngreso": this.fechaIngreso,
        "fecheEgreso": "",
        "nombreMarcaPc": this.nombreMarcaPc,
        "nombreModeloPc": this.nombreModeloPc,
        "versionPc": this.versionPc,
        "detalleOrden": this.detalleOrden,
        "diagnosticoPc": this.diagnosticoPc,
        "detalleReparacion": this.detalleReparacion,
        "presupuesto":this.presupuesto,
        "seña":this.senia,
        "precio":this.precio,
        "estado":this.estado,
        "proveedor":this.proveedor,
        "costoRepuesto":this.costoRepuesto,
      }
      console.log(unaReparacion);
        this.CargarOrden(unaReparacion);
    } 
  }  
  async GenerarPDF(){
    this.ionViewWillEnter();
    let dniImprimir= this.dni;
    let marcaImprimir = this.nombreMarcaPc;
    let modeloImprimir=this.nombreModeloPc;
    let versionImprimir=this.versionPc;
    let detalleImprimir=this.detalleOrden;
    let diagnosticoImprimir=this.diagnosticoPc;
    let nombreImprimir= this.nombre;
    let apellidoImprimir=this.apellido;
    let telefonoImprimir=this.telefono;
    let presupuestoImprimir=this.presupuesto;
    let seniaImprimir=this.senia;
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
  pdf.add('Dni Cliente: '+ dniImprimir + '             ' + '                ' + 'N° de Orden Pc: '+ this.valor+'            ' + 'Fecha de ingreso: '+fechapdf); 
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
  pdf.add('Versión: '+versionImprimir);
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
  //this.valor=0;
  }


  ionViewWillEnter(){
    this.ordenReparacionPc.ObtenerUltimoId().then(
      (resultado:number)=>{
        this.valor= resultado;
       
        console.log(this.valor+'idrepa');
      }
     );
     console.log(this.valor+'pu');
  }
  estadoReparacion(value:string)
  { this.estado=value;
    console.log(value+" enciende2"); 
    console.log(this.estado+" el estado ahroa es"); 
  }
}