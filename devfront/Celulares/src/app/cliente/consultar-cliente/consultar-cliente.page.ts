import { Component, OnInit, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { AlertService } from 'src/app/Services/alert-service/alert.service';
import { ClienteService } from 'src/app/Services/cliente-service/cliente.service';
import { LoadService } from 'src/app/Services/load-service/load.service';

@Component({
  selector: 'app-consultar-cliente',
  templateUrl: './consultar-cliente.page.html',
  styleUrls: ['./consultar-cliente.page.scss'],
})
export class ConsultarClientePage implements OnInit {
  @ViewChild('form') public ConsultarClienteForm:NgForm;
  clienteId:string;
  nombre:string;
  apellido:string;
  telefono:string;
  email:string;
  direccion:string;
  dni:string;
  datosCliente:boolean=false;
  dniCliente:string;
  /*cliente:any;*/
  datosEncontrados:boolean=false;
  constructor(public clienteService:ClienteService,
    public loadService:LoadService, public alertService:AlertService) { }

  ngOnInit() {
  }

  BuscarClienteDni(pDni)
  {  
   this.loadService.presentLoadingWithTime("Buscando Cliente...",5);
   this.clienteService.ObtenerUnClientePorDni(pDni).then(
     (resultado:any)=>{
    
      this.alertService.presentAlert("Ok","Cliente Encontrado", pDni);
      this.clienteId=resultado.clienteId;
      this.datosEncontrados=true;
      this.apellido= resultado.apellido;
      this.nombre=resultado.nombre;
      this.direccion = resultado.direccion;
      this.dni=resultado.dni;
      this.telefono= resultado.telefono;
      this.email=resultado.email;
      console.log( resultado);
     }).catch((error)=>
     {
       this.alertService.presentAlert("Error","Cliente No Encontrado", pDni);
       this.datosEncontrados=false;
       console.log(error);
      
     })
  }
  
 ModificarCliente()
  {   
  let unCliente={
   "dtoClienteId": 0,
  "clienteId":this.clienteId,  
  "nombre":this.nombre,
  "apellido":this.apellido,
  "telefono":this.telefono,
  "email":this.email,
  "direccion":this.direccion,
  "dni":this.dni
  }
  this.loadService.presentLoadingWithTime("Modificando datos del cliente..",6);
  this.clienteService.ModificarCliente(unCliente).then(
    (resultado:any)=>{
      this.alertService.presentAlert("Ok","Cliente Modificado", unCliente.clienteId);
      this.ConsultarClienteForm.reset();
      this.datosEncontrados=false;
      console.log(resultado);
    }).catch((error)=>
    {
      if (unCliente.clienteId==null) {
        this.alertService.presentAlert("Debe ingresar un Dni",error.error,unCliente.clienteId);
        console.log("reaaa");
      }
      else {
      this.alertService.presentAlert("Dni del cliente no modificado",error.error,unCliente.clienteId);
      console.log(error);
      }
    })
 }

  EliminarCliente(pDni){
    this.loadService.presentLoadingWithTime("Eliminando Cliente..",6);
    console.log(pDni);
    this.clienteService.EliminarUnCliente(pDni).then(
      (resultado)=>{
        console.log(pDni);
        this.alertService.presentAlert("Ok","Eliminado", pDni);
        
        this.datosEncontrados=false;
        this.ConsultarClienteForm.reset();
        console.log(resultado);
      }).catch((error)=>
      {
        if (pDni==null) {
          this.alertService.presentAlert("Debe ingresar un DNI",error.error,pDni); /*id*/
        }
        else {
        this.alertService.presentAlert("Id del cliente no encontrado",error.error,pDni); /*id*/
        this.datosEncontrados=false;
        console.log(error);
        console.log(pDni);
        }
      })
   }
  }
