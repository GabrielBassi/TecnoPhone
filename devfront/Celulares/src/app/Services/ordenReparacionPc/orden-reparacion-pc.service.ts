import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';

const httpOptions = {
  headers: new HttpHeaders({'Authorization': 'Bearer ' + localStorage.getItem("token")})
};
const headers = {
  headers:new HttpHeaders({'Content-Type':'application/json; charset=utf-8'})
};
@Injectable({
  providedIn: 'root'
})
export class OrdenReparacionPcService {
  private reparacionPcUrl = 'http://192.168.0.92:8080/api/OrdenDeReparacionPcs';
  private todasReparacionesPcDniUrl='http://192.168.0.92:8080/api/OrdenDeReparacionPcs/GetTodasOrdenReparacionPc';
  private actualizarEstadoPcUrl='http://192.168.0.92:8080/api/OrdenDeReparacionPcs/ActualizarEstadoOrden/';
  private ultimoId ='http://192.168.0.92:8080/api/OrdenDeReparacionPcs/UltimoIdReparacionPc';
  constructor(private http: HttpClient) { }

  ObtenerUnaReparacionPc(pId){
    return new Promise((resolve,reject)=>{
      this.http.get(this.reparacionPcUrl+'/'+pId,httpOptions).subscribe(
        data=>resolve(data),
        error => reject(error)
      )
    });
  }
  ObtenerTodasLasReparacionPcPorDni(pDni){
    return new Promise((resolve,reject)=>{
      this.http.get(this.todasReparacionesPcDniUrl+'/'+pDni,httpOptions).subscribe(
        data=>resolve(data),
        error => reject(error)
      )
    });
  }
  EliminarOrdenReparacionPc(pId){
    return new Promise((resolve,reject)=>{
    this.http.delete(this.reparacionPcUrl+'/'+pId,httpOptions).subscribe(
      data=>resolve(data),
      error=>reject(error)
    )
    });
    }
    ModificarOrdenReparacionPc(unaReparacion){
      return new Promise((resolve,reject)=>{
      this.http.put(this.reparacionPcUrl,unaReparacion,httpOptions).subscribe(
        data=>resolve(data),
        error=>reject(error)
      )
      });
      }
   AgregarOrdenReparacionPc(unaOrden){
    return new Promise((resolve,reject)=>{
     this.http.post(this.reparacionPcUrl,unaOrden,httpOptions).subscribe(
     data=>resolve(data),
     error=>reject(error)
      )
    });
    }
    ObtenerUltimoId(){
      return new Promise((resolve,reject)=>{
        this.http.get(this.ultimoId,httpOptions).subscribe(
          data=>resolve(data),
          error => reject(error)
        )
      });
    }
    ObtenerTodasLasReparacionColor(){
      return new Promise((resolve,reject)=>{
        this.http.get(this.reparacionPcUrl,httpOptions).subscribe(
          data=>resolve(data),
          error => reject(error)
        )
      });
    }
    ObtenerTodasLasReparacionPcPage(page){
      return new Promise((resolve,reject)=>{
        this.http.get(this.reparacionPcUrl+'/GetOrdenReparacionPcDTOPage?pnumber='+page+'&psize=8',httpOptions).subscribe(
          data=>resolve(data),
          error => reject(error)
        )
      });
    }
}