import { Component, OnInit, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { IonToggle } from '@ionic/angular';
import { AlertService } from 'src/app/Services/alert-service/alert.service';
import { LoadService } from 'src/app/Services/load-service/load.service';
import { OrdenReparacionPcService } from 'src/app/Services/ordenReparacionPc/orden-reparacion-pc.service';

@Component({
  selector: 'app-consultar-orden-pc',
  templateUrl: './consultar-orden-pc.page.html',
  styleUrls: ['./consultar-orden-pc.page.scss'],
})
export class ConsultarOrdenPcPage implements OnInit {
  @ViewChild('form') public ConsultarOrdenPcForm:NgForm;
  @ViewChild(IonToggle) public SS:IonToggle;
  dtoOrdenDeReparacionPcId:string;
  fechaIngreso:Date;
  fecheEgreso:string;
  detalleOrden:string;
  precio:number;
  diagnosticoPc:string;
  dni:string;
  nombreMarcaPc:string;
  nombreModeloPc:string;
  versionPc:string;
  estado:string;
  detalleReparacion:string;
  numOrdenPc:number;
  proveedor:string;
  costoRepuesto:number;
  presupuesto:number;
  senia:number;
  datosEncontradospc:boolean=false;
  constructor(public ordenReparacionPc:OrdenReparacionPcService,private router: ActivatedRoute,
    public loadService:LoadService, public alertService:AlertService) { }

  ngOnInit() {

    let pIdordensPc = this.router.snapshot.paramMap.get('dtoOrdenDeReparacionPcId');
    console.log(pIdordensPc);
    if (pIdordensPc!=null) {
      this.BuscarOrdenPc(pIdordensPc);
    } 
  }
  BuscarOrdenPc(pIdORden){
    console.log(pIdORden);
    this.loadService.presentLoadingWithTime("Buscando Orden..",6);
    this.ordenReparacionPc.ObtenerUnaReparacionPc(pIdORden).then(
      (resultado:any)=>{
       this.dtoOrdenDeReparacionPcId=resultado.dtoOrdenDeReparacionPcId;
       this.fechaIngreso=resultado.fechaIngreso;
       this.fecheEgreso=resultado.fecheEgreso;
       this.detalleOrden=resultado.detalleOrden;
       this.precio=resultado.precio;
       this.diagnosticoPc=resultado.diagnosticoPc;
       this.dni=resultado.dni;
       this.nombreMarcaPc=resultado.nombreMarcaPc;
       this.nombreModeloPc=resultado.nombreModeloPc;
       this.versionPc=resultado.versionPc;
       this.estado=resultado.estado;
       this.detalleReparacion=resultado.detalleReparacion;
       this.presupuesto=resultado.presupuesto;
       this.proveedor=resultado.proveedor;
       this.costoRepuesto=resultado.costoRepuesto;
       this.senia=resultado.seña;
        this.alertService.presentAlert("Ok","Reparación Encontrada", pIdORden);
        this.datosEncontradospc=true;
        console.log(resultado);
        console.log(resultado.fecheEgreso);
      }).catch((error)=>
      {
        if (pIdORden==null) {
          this.alertService.presentAlert("Debe ingresar un id",error.error,pIdORden);
        }
        else {
        this.alertService.presentAlert("Id orden no registrado",error.error,pIdORden);
        this.datosEncontradospc=false;
        console.log(error);
        }
      })
  }
  EliminarOrdenPc(pId){
   this.loadService.presentLoadingWithTime("Eliminando Orden..",6);
   this.ordenReparacionPc.EliminarOrdenReparacionPc(pId).then(
     (resultado:any)=>{
       this.alertService.presentAlert("Ok","Reparación Eliminada", pId);
       this.ConsultarOrdenPcForm.reset();
       this.datosEncontradospc=false;
       console.log(resultado);
     }).catch((error)=>
     {
       if (pId==null) {
         this.alertService.presentAlert("Debe ingresar un id",error.error,pId);
       }
       else {
       this.alertService.presentAlert("Id orden no eliminado",error.error,pId);
       this.datosEncontradospc=false;
       console.log(error);
       }
     })
  }
  ModificarOrdenPc()
  {
   let unaReparacionPc={
     "dtoOrdenDeReparacionPcId":this.dtoOrdenDeReparacionPcId,
     "fechaIngreso": this.fechaIngreso,
     "fecheEgreso": this.fecheEgreso,
     "detalleOrden": this.detalleOrden,
     "precio": this.precio,
     "diagnosticoPc": this.diagnosticoPc,
     "dni": this.dni,
     "nombreMarcaPc": this.nombreMarcaPc,
     "nombreModeloPc": this.nombreModeloPc,
     "versionPc": this.versionPc,
     "estado": this.estado,
     "detalleReparacion": this.detalleReparacion,
     "proveedor":this.proveedor,
     "costoRepuesto":this.costoRepuesto,
     "seña":this.senia,
     "presupuesto":this.presupuesto,
   }
   this.loadService.presentLoadingWithTime("Modificando Orden..",6);
   this.ordenReparacionPc.ModificarOrdenReparacionPc(unaReparacionPc).then(
     (resultado:any)=>{
       this.alertService.presentAlert("Ok","Reparación Modificada", unaReparacionPc.dtoOrdenDeReparacionPcId);
       this.ConsultarOrdenPcForm.reset();
       this.datosEncontradospc=false;
       console.log(resultado);
     }).catch((error)=>
     {
       if (unaReparacionPc.dtoOrdenDeReparacionPcId==null) {
         this.alertService.presentAlert("Debe ingresar un id",error.error,unaReparacionPc.dtoOrdenDeReparacionPcId);
       }
       else {
       this.alertService.presentAlert("Id orden no modificado",error.error,unaReparacionPc.dtoOrdenDeReparacionPcId);
       console.log(error);
       }
     })
  }
  estadoReparacion(value:string)
  { this.estado=value;
    console.log(value+" enciende2"); 
    console.log(this.estado+" el estado ahroa es"); 
  }
}
