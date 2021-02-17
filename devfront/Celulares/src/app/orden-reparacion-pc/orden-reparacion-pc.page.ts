import { Component, OnInit, ViewChild } from '@angular/core';
import { AlertService } from '../Services/alert-service/alert.service';
import { ClienteService } from '../Services/cliente-service/cliente.service';
import { LoadService } from '../Services/load-service/load.service';
import { OrdenReparacionPcService } from '../Services/ordenReparacionPc/orden-reparacion-pc.service';
import { IonInfiniteScroll } from '@ionic/angular';

@Component({
  selector: 'app-orden-reparacion-pc',
  templateUrl: './orden-reparacion-pc.page.html',
  styleUrls: ['./orden-reparacion-pc.page.scss'],
})
export class OrdenReparacionPcPage implements OnInit {
  @ViewChild(IonInfiniteScroll) infiniteScroll: IonInfiniteScroll;
  datosDniEncontradopc=false;
  bdnipc:string;
  ordenespc:any;
  dnipc:string;
  datosEncontradospc:boolean=false;
  cardEncontrado:boolean=false;
  iCard:number=0;
  page=1;
  //maximumPage=3;
  data:any;
  constructor(public ordenReparacionPc:OrdenReparacionPcService,private clienteService:ClienteService,
    public loadService:LoadService, public alertService:AlertService) {
    //  this.BuscarListPaginacion();
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
}

  
