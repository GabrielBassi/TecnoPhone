import { Component, OnInit } from '@angular/core';
import { AlertService } from 'src/app/Services/alert-service/alert.service';
import { ClienteService } from 'src/app/Services/cliente-service/cliente.service';
import { LoadService } from 'src/app/Services/load-service/load.service';
import { OrdenReparacionCelService } from 'src/app/Services/ordenReparacionCel/orden-reparacion-cel.service';

@Component({
  selector: 'app-modificar-orden-cel',
  templateUrl: './modificar-orden-cel.page.html',
  styleUrls: ['./modificar-orden-cel.page.scss'],
})
export class ModificarOrdenCelPage implements OnInit {
  datosDniEncontrado=false;
  bdni:string;
  ordenes:any;
  cardEncontrado:boolean=false;
  dni:string;
  datosEncontrados:boolean=false;
  iCard:number=0;
  page=1;
  data:any;
  constructor(public ordenReparacionCel:OrdenReparacionCelService,private clienteService:ClienteService,
    public loadService:LoadService, public alertService:AlertService) {
      this.BuscarListPaginacion();
     }

  ngOnInit() {
  } boolCabezaera(pid) {
    console.log(pid);
    this.iCard=pid;
      this.cardEncontrado = !this.cardEncontrado
      console.log(this.cardEncontrado+"cardoculta");   
  }

  BuscarOrdenesPorDni(bdni)
  { 
    console.log(bdni);
    this.loadService.presentLoadingWithTime("Buscando Orden..",6);
    this.ordenReparacionCel.ObtenerTodasLasReparacionCelularPorDni(bdni).then((resultado:any)=>{
        this.alertService.presentAlert("Ok","Ordenes del dni Encontradas", bdni);
       this.datosEncontrados=true;
        this.ordenes=resultado;
        console.log(this.ordenes);
      }).catch((error)=>
      {
        if (bdni==null) {
          this.alertService.presentAlert("Debe ingresar un id",error.error,bdni);
        }
        else {
        this.alertService.presentAlert("Id orden no registrado",error.error,bdni);
        this.datosEncontrados=false;
        console.log(error);
        }
      })

  }
  BuscarOrdenesCelularTodas()
  {
    this.loadService.presentLoadingWithTime("Buscando Orden..",8);
    this.ordenReparacionCel.ObtenerTodasLasReparacionColor().then((resultado:any)=>{
      this.alertService.presentAlert("Ok","Ordenes Encontradas", "Todas");
      this.datosEncontrados=true;
       this.ordenes=resultado;
       console.log(this.ordenes);
    }).catch((error)=>
    {
      this.alertService.presentAlert("Ordenes no encontradas",error.error,"Listado");
      this.datosEncontrados=false;
      console.log(error);
    })
  }
  BuscarListPaginacion(event?){
    console.log(event);
    console.log("valor ev");
    this.ordenReparacionCel.ObtenerTodasLasReparacionCelPage(this.page).then((resultado)=>{
      this.alertService.presentAlert("Ok","Ordenes Encontradas", "Todas");
      this.datosEncontrados=true;
       this.data=resultado;
      this.ordenes=resultado;
     
    }).catch((error)=>
    {
      this.alertService.presentAlert("Ordenes no encontradas",error.error,"Listado");
      this.datosEncontrados=false;
      console.log(error);
    })
  }

 loadData(event) {
   this.page=this.page+1;
   console.log( this.page+'vaevent');
   this.ordenReparacionCel.ObtenerTodasLasReparacionCelPage(this.page).then((resultado)=>{
   // this.alertService.presentAlert("Ok","Ordenes Encontradas", "Todas");
    this.datosEncontrados=true;
     this.data=resultado;
     console.log("ANTES DEL FOR");
   for (const article of this.data) {
    this.ordenes.push(article);
     
   }
   event.target.complete();
    }).catch((error)=>
    {
      this.alertService.presentAlert("Ordenes no encontradas",error.error,"Listado");
      this.datosEncontrados=false;
      console.log(error);
    })
  }
}

  



