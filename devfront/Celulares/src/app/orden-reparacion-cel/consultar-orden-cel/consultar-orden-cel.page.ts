import { Component, OnInit, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { IonToggle, MenuController } from '@ionic/angular';
import { AlertService } from 'src/app/Services/alert-service/alert.service';
import { ClienteService } from 'src/app/Services/cliente-service/cliente.service';
import { LoadService } from 'src/app/Services/load-service/load.service';
import { OrdenReparacionCelService } from 'src/app/Services/ordenReparacionCel/orden-reparacion-cel.service';

@Component({
  selector: 'app-consultar-orden-cel',
  templateUrl: './consultar-orden-cel.page.html',
  styleUrls: ['./consultar-orden-cel.page.scss'],
})
export class ConsultarOrdenCelPage implements OnInit {
  @ViewChild('form') public ConsultarOrdenCelForm:NgForm;
  dtoOrdenDeReparacionCelularId:string;
  fechaIngreso:Date;
  fecheEgreso:string;
  detalleOrden:string;
  precio:number;
  dni:string;
  empresa:string;
  chip:boolean;
  tarjetaSD:boolean;
  diagnosticoCelular:string;
  pin:number;
  patron:string;
  estado:string;
  nombreMarcaCelular:string;
  nombreModeloCelular:string;
  versionCelular:string;
  detalleReparacion:string;
  enciende:boolean;
  proveedor:string;
  costoRepuesto:number;
  presupuesto:number;
  senia:number;
  numOrden:number;
  datosEncontrados:boolean=false;
  constructor(public ordenReparacionCel:OrdenReparacionCelService,private router: ActivatedRoute,
    public loadService:LoadService, public alertService:AlertService, private menu: MenuController) { 
     // this.menu.enable(true);
    }

  ngOnInit() {
    let pIdordens = this.router.snapshot.paramMap.get('dtoOrdenDeReparacionCelularId');
    console.log(pIdordens);
    if (pIdordens!=null) {
      this.BuscarOrden(pIdordens);
    } 
  }

  BuscarOrden(pIdORden){
     this.loadService.presentLoadingWithTime("Buscando Orden..",6);
     this.ordenReparacionCel.ObtenerUnaReparacionCelular(pIdORden).then(
       (resultado:any)=>{
        this.dtoOrdenDeReparacionCelularId=resultado.dtoOrdenDeReparacionCelularId;
        this.fechaIngreso=resultado.fechaIngreso;
        this.fecheEgreso=resultado.fecheEgreso;
        this.detalleOrden=resultado.detalleOrden;
        this.precio=resultado.precio;
        this.dni=resultado.dni;
        this.empresa=resultado.empresa;
        this.chip=resultado.chip;
        this.tarjetaSD=resultado.tarjetaSD;
        this.diagnosticoCelular=resultado.diagnosticoCelular;
        this.pin=resultado.pin;
        this.patron=resultado.patron;
        this.estado=resultado.estado;
        this.nombreMarcaCelular=resultado.nombreMarcaCelular;
        this.nombreModeloCelular=resultado.nombreModeloCelular;
        this.versionCelular=resultado.versionCelular;
        this.detalleReparacion=resultado.detalleReparacion;
        this.proveedor=resultado.proveedor;
        this.costoRepuesto=resultado.costoRepuesto;
        this.presupuesto=resultado.presupuesto;    
        this.senia=resultado.seña;
        this.enciende=resultado.enciende;
         this.alertService.presentAlert("Ok","Reparación Encontrada", pIdORden);
         this.datosEncontrados=true;
         console.log(resultado);
         console.log(resultado.chip);
         console.log(resultado.tarjetaSD);
         console.log(resultado.enciende);
         console.log(resultado.fecheEgreso);
       }).catch((error)=>
       {
         if (pIdORden==null) {
           this.alertService.presentAlert("Debe ingresar un id",error.error,pIdORden);
         }
         else {
         this.alertService.presentAlert("Id orden no registrado",error.error,pIdORden);
         this.datosEncontrados=false;
         console.log(error);
         }
       })
   }
   EliminarOrden(pId){
    this.loadService.presentLoadingWithTime("Eliminando Orden..",6);
    this.ordenReparacionCel.EliminarOrdenReparacionCelular(pId).then(
      (resultado:any)=>{
        this.alertService.presentAlert("Ok","Reparación Eliminada", pId);
        this.ConsultarOrdenCelForm.reset();
        this.datosEncontrados=false;
        console.log(resultado);
      }).catch((error)=>
      {
        if (pId==null) {
          this.alertService.presentAlert("Debe ingresar un id",error.error,pId);
        }
        else {
        this.alertService.presentAlert("Id orden no eliminado",error.error,pId);
        this.datosEncontrados=false;
        console.log(error);
        }
      })
   }
   ModificarOrden()
   {
    let unaReparacion={
      "dtoOrdenDeReparacionCelularId":this.dtoOrdenDeReparacionCelularId,
      "fechaIngreso": this.fechaIngreso,
      "fecheEgreso": this.fecheEgreso,
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
      "proveedor":this.proveedor,
      "costoRepuesto":this.costoRepuesto, 
      "presupuesto":this.presupuesto,
      "seña":this.senia,

    }
    this.loadService.presentLoadingWithTime("Modificando Orden..",6);
    this.ordenReparacionCel.ModificarOrdenReparacionCelular(unaReparacion).then(
      (resultado:any)=>{
        this.alertService.presentAlert("Ok","Reparación Modificada", unaReparacion.dtoOrdenDeReparacionCelularId);
        this.ConsultarOrdenCelForm.reset();
        this.datosEncontrados=false;
        console.log(resultado);
      }).catch((error)=>
      {
        if (unaReparacion.dtoOrdenDeReparacionCelularId==null) {
          this.alertService.presentAlert("Debe ingresar un id",error.error,unaReparacion.dtoOrdenDeReparacionCelularId);
        }
        else {
        this.alertService.presentAlert("Id orden no modificado",error.error,unaReparacion.dtoOrdenDeReparacionCelularId);
        console.log(error);
        }
      })
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
  estadoReparacion(value:string)
  { this.estado=value;
    console.log(value+" enciende2"); 
    console.log(this.estado+" el estado ahroa es"); 
  }

}
