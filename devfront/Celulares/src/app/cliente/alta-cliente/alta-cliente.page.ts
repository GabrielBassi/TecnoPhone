import { Component, OnInit, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { AlertService } from 'src/app/Services/alert-service/alert.service';
import { ClienteService } from 'src/app/Services/cliente-service/cliente.service';
import { LoadService } from 'src/app/Services/load-service/load.service';
import * as html2pdf from 'html2pdf.js';

@Component({
  selector: 'app-alta-cliente',
  templateUrl: './alta-cliente.page.html',
  styleUrls: ['./alta-cliente.page.scss'],
})
export class AltaClientePage implements OnInit {
  @ViewChild('form') public AltaClienteForm:NgForm;
  dni:string;
  nombre:string;
  apellido:string;
  telefono:string;
  direccion:string;
  email:string;
  constructor(public clienteService:ClienteService,
    public loadService:LoadService, public alertService:AlertService) { }

  ngOnInit() {
  }
AgregarCliente()
{
 
  let unCliente={
    "dtoClienteId": 0,
    "clienteId": 0,
    "nombre": this.nombre,
    "apellido": this.apellido,
    "telefono": this.telefono,
    "email": this.email,
    "dni": this.dni,
    "direccion": this.direccion,
  }
  console.log(unCliente);
   this.loadService.presentLoadingWithTime("Agregando Cliente..",3);
  this.clienteService.AgregarUnCliente(unCliente).then(
    (resultado)=>{
      this.alertService.presentAlert('Ok','Cliente cargado','Registro Exitoso');
      console.log(resultado);
      this.AltaClienteForm.reset();
    }).catch((error)=>
    {
      this.alertService.presentAlert('Error','Error al cargar dni cliente',error.error);
      console.log(error);
    })
}
}