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
export class OrdenReparacionCelService {
  private repracionCelularUrl = 'http://192.168.0.92:8080/api/OrdenDeReparacionCelulars';
  private todasReparacionesDniUrl='http://192.168.0.92:8080/api/OrdenDeReparacionCelulars/GetTodasOrdenReparacionCelular';
  private actualizarEstadoUrl='http://192.168.0.92:8080/api/OrdenDeReparacionCelulars/ActualizarEstadoOrden/';
  private ultimoId ='http://192.168.0.92:8080/api/OrdenDeReparacionCelulars/UltimoIdReparacionPc';
  constructor(private http: HttpClient) { }

ObtenerTodasLasReparacionCelular(){
  return new Promise((resolve,reject)=>{
    this.http.get(this.repracionCelularUrl,httpOptions).subscribe(
      data=>resolve(data),
      error => reject(error)
    )
  });
}
ObtenerUnaReparacionCelular(pId){
  return new Promise((resolve,reject)=>{
    this.http.get(this.repracionCelularUrl+'/'+pId,httpOptions).subscribe(
      data=>resolve(data),
      error => reject(error)
    )
  });
}
ObtenerTodasLasReparacionCelularPorDni(pDni){
  return new Promise((resolve,reject)=>{
    this.http.get(this.todasReparacionesDniUrl+'/'+pDni,httpOptions).subscribe(
      data=>resolve(data),
      error => reject(error)
    )
  });
}
ActualizarEstadoOrdenReparacionCelular(pId,pEstado){
return new Promise((resolve,reject)=>{
this.http.put(this.actualizarEstadoUrl+pId,'',httpOptions).subscribe(
  data=>resolve(data),
  error=>reject(error)
)
});
}
ModificarOrdenReparacionCelular(unaReparacion){
  return new Promise((resolve,reject)=>{
  this.http.put(this.repracionCelularUrl,unaReparacion,httpOptions).subscribe(
    data=>resolve(data),
    error=>reject(error)
  )
  });
  }

  AgregarOrdenReparacionCelular(unaOrden){
    return new Promise((resolve,reject)=>{
    this.http.post(this.repracionCelularUrl,unaOrden,httpOptions).subscribe(
      data=>resolve(data),
      error=>reject(error)
    )
    });
    }
    EliminarOrdenReparacionCelular(pId){
      return new Promise((resolve,reject)=>{
      this.http.delete(this.repracionCelularUrl+'/'+pId,httpOptions).subscribe(
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
          this.http.get(this.repracionCelularUrl,httpOptions).subscribe(
            data=>resolve(data),
            error => reject(error)
          )
        });
      }
      ObtenerTodasLasReparacionCelPage(page){
        return new Promise((resolve,reject)=>{
          this.http.get(this.repracionCelularUrl+'/GetOrdenReparacionCelDTOPage?pnumber='+page+'&psize=8',httpOptions).subscribe(
            data=>resolve(data),
            error => reject(error)
          )
        });
      }
}