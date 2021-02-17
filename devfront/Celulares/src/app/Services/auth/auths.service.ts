import { Injectable } from '@angular/core';
import { AngularFireAuth } from '@angular/fire/auth';
import * as firebase from 'firebase';
import { TokenInterceptor } from 'src/app/interceptors/token-interceptor';

@Injectable({
  providedIn: 'root'
})
export class AuthsService {
  uId:any;
  constructor(public afAuth: AngularFireAuth) { }
  doRegister(value){
    return new Promise<any>((resolve, reject) => {
      firebase.auth().createUserWithEmailAndPassword(value.email, value.password)
      .then(
        res => resolve(res),
        err => reject(err))
    })
   }
   doLogin(value){
    return new Promise<any>((resolve, reject) => {
      firebase.auth().signInWithEmailAndPassword(value.email, value.password)
      .then(
        res => {
          this.uId=firebase.auth().currentUser.uid;
          console.log('aca tengo '+ this.uId);
        
         firebase.auth().currentUser.getIdToken().then(token => {
           localStorage.setItem(TokenInterceptor.TOKEN_KEY, token); 
         //  console.log('tu token putop '+token);
         });
            
         return resolve(res);
       },
        err => reject(err)) 
    })
   }
   
   doLogout(){
    return new Promise((resolve, reject) => {
      this.afAuth.auth.signOut()
      .then(() => {
        localStorage.removeItem(TokenInterceptor.TOKEN_KEY);
        resolve();
      }).catch((error) => {
        console.log(error);
        reject();
      });
    })
  }
  ControlAdmin (pCadena:any):boolean
  {
    console.log('aca llega cadena ' +pCadena);
   let encontrado:boolean;
   if (pCadena == 'ioYREozdDkRSH4rbHPbF2HsGcQb2' || pCadena == 'i5LAT55tQ4NmhCCWjHD7BnOh7TB2' || pCadena == '0VYt1ptfTJOtrYb8oTMkuALu68n2')
   {
     encontrado = true;
   } 
   else 
   {
     encontrado=false;
   }
   return encontrado;
 }

}
