import { Component, OnInit, ViewChild } from '@angular/core';
import { IonInfiniteScroll } from '@ionic/angular';
import { AlertService } from 'src/app/Services/alert-service/alert.service';
import { ClienteService } from 'src/app/Services/cliente-service/cliente.service';
import { LoadService } from 'src/app/Services/load-service/load.service';
import { OrdenReparacionPcService } from 'src/app/Services/ordenReparacionPc/orden-reparacion-pc.service';

@Component({
  selector: 'app-modificar-orden-pc',
  templateUrl: './modificar-orden-pc.page.html',
  styleUrls: ['./modificar-orden-pc.page.scss'],
})
export class ModificarOrdenPcPage implements OnInit {
  @ViewChild(IonInfiniteScroll) infiniteScroll: IonInfiniteScroll;
  datosDniEncontradopc=false;
  bdnipc:string;
  ordenespc:any;
  dnipc:string;
  datosEncontradospc:boolean=false;
  cardEncontrado:boolean=false;
  iCard:number=0;
  page=1;
  data:any;

  constructor(public ordenReparacionPc:OrdenReparacionPcService,private clienteService:ClienteService,
    public loadService:LoadService, public alertService:AlertService) {
      this.BuscarListPaginacion();
     }

     ngOnInit() {
    }
    boolCabezaera(pid) {
      console.log(pid);
      this.iCard=pid;
        this.cardEncontrado = !this.cardEncontrado
        console.log(this.cardEncontrado+"cardoculta");   
    }
  
    BuscarOrdenesPcPorDni(bdni)
    { 
      console.log(bdni);
      this.loadService.presentLoadingWithTime("Buscando Orden..",6);
      this.ordenReparacionPc.ObtenerTodasLasReparacionPcPorDni(bdni).then((resultado:any)=>{
          this.alertService.presentAlert("Ok","Ordenes del dni Encontradas", bdni);
         this.datosEncontradospc=true;
          this.ordenespc=resultado;
          console.log(this.ordenespc);
        }).catch((error)=>
        {
          if (bdni==null) {
            this.alertService.presentAlert("Debe ingresar un id",error.error,bdni);
          }
          else {
          this.alertService.presentAlert("Id orden no registrado",error.error,bdni);
          this.datosEncontradospc=false;
          console.log(error);
          }
        })
  
    }
    BuscarOrdenesPcTodas()
    {
      this.loadService.presentLoadingWithTime("Buscando Orden..",8);
      this.ordenReparacionPc.ObtenerTodasLasReparacionColor().then((resultado:any)=>{
        this.alertService.presentAlert("Ok","Ordenes Encontradas", "Todas");
        this.datosEncontradospc=true;
         this.ordenespc=resultado;
         console.log(this.ordenespc);
      }).catch((error)=>
      {
        this.alertService.presentAlert("Ordenes no encontradas",error.error,"Listado");
        this.datosEncontradospc=false;
        console.log(error);
      })
    }
    BuscarListPaginacion(event?){
      console.log(event);
      console.log("valor ev");
      this.ordenReparacionPc.ObtenerTodasLasReparacionPcPage(this.page).then((resultado)=>{
        this.alertService.presentAlert("Ok","Ordenes Encontradas", "Todas");
        this.datosEncontradospc=true;
         this.data=resultado;
        this.ordenespc=resultado;
         console.log(resultado);
         console.log( this.data);
         console.log("va data");
         console.log( this.ordenespc);
         console.log("va orden");
       
      }).catch((error)=>
      {
        this.alertService.presentAlert("Ordenes no encontradas",error.error,"Listado");
        this.datosEncontradospc=false;
        console.log(error);
      })
    }
  
   loadData(event) {
     this.page=this.page+1;
     console.log( this.page+'vaevent');
     this.ordenReparacionPc.ObtenerTodasLasReparacionPcPage(this.page).then((resultado)=>{
     // this.alertService.presentAlert("Ok","Ordenes Encontradas", "Todas");
      this.datosEncontradospc=true;
       this.data=resultado;
       console.log("ANTES DEL FOR");
     for (const article of this.data) {
      this.ordenespc.push(article);
       
     }
     event.target.complete();
      }).catch((error)=>
      {
        this.alertService.presentAlert("Ordenes no encontradas",error.error,"Listado");
        this.datosEncontradospc=false;
        console.log(error);
      })
    }
  }
  
    
  