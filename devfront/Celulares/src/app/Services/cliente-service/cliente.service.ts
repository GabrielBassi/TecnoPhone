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
export class ClienteService {
  private clienteUrl = 'http://192.168.0.92:8080/api/Clientes'; 
  
  constructor(private http: HttpClient) { }

  ObtenerUnClientePorDni(pId){
    return new Promise((resolve,reject)=>{
      this.http.get(this.clienteUrl+'/'+pId,httpOptions).subscribe(
        data=>resolve(data),
        error => reject(error)
      ) 
    });
  }
  ModificarCliente(unCliente){
    return new Promise((resolve,reject)=>{
    this.http.put(this.clienteUrl,unCliente,httpOptions).subscribe(
      data=>resolve(data),
      error=>reject(error)
    )
    });
    }

  AgregarUnCliente(unCliente){
    return new Promise((resolve,reject)=>{
    this.http.post(this.clienteUrl,unCliente,httpOptions).subscribe(
      data=>resolve(data),
      error=>reject(error)
    )
    });
    }
    
    EliminarUnCliente(pDni){
      return new Promise((resolve,reject)=>{
      this.http.delete(this.clienteUrl+'/'+pDni,httpOptions).subscribe(
        data=>resolve(data),
        error=>reject(error)
      )
      });
      }
}
