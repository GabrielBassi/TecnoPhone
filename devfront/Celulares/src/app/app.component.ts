import { Component, OnInit } from '@angular/core';

import { MenuController, Platform } from '@ionic/angular';

import { Router } from '@angular/router';
//import { AngularFireAuth } from '@angular/fire/auth';
import { AuthsService } from './Services/auth/auths.service';
import { AngularFireAuth } from '@angular/fire/auth';
import { Plugins,  StatusBarStyle } from '@capacitor/core';

@Component({
  selector: 'app-root',
  templateUrl: 'app.component.html',
  styleUrls: ['app.component.scss']
})
export class AppComponent implements OnInit {
  public selectedIndex = 0;
  public appPages = [
    {
      title: 'Buscar Orden Celular',
      url: '/orden-reparacion-cel/consultar-orden-cel',
      icon: 'search'
    },
    {
      title: 'Agregar Orden Celular',
      url: '/orden-reparacion-cel/alta-orden-cel',
      icon: 'create'
    },
    {
      title: 'Listar Ordenes Celulares',
      url: '/orden-reparacion-cel',
      icon: 'list-circle'
    },
    {
      title: 'Buscar Orden Pc',
      url: '/orden-reparacion-pc/consultar-orden-pc',
      icon: 'search'
    },
    {
      title: 'Agregar Orden Pc',
      url: '/orden-reparacion-pc/alta-orden-pc',
      icon: 'desktop'
    },
    {
      title: 'Listar Ordenes Pc',
      url: '/orden-reparacion-pc',
      icon: 'list'
    },
    {
      title: 'Buscar Cliente',
      url: '/cliente/consultar-cliente',
      icon: 'search'
    },
    {
      title: 'Agregar Cliente',
      url: '/cliente/alta-cliente',
      icon: 'person-add'
    },
  ];
  

  constructor(private platform: Platform,
    private router: Router,
    public afAuth: AngularFireAuth,
    private authService: AuthsService,
    private menuCrtl: MenuController
  ) {
    this.initializeApp();
  }

 /*async initializeApp(){
   const {SplashScreen, StatusBar}= Plugins;
   try{
     await SplashScreen.hide();
     await StatusBar.setStyle({style:StatusBarStyle.Light});
     if(this.platform.is('android')){
       StatusBar.setBackgroundColor({color:'#CDCDCD'});
     }
   }catch (err){
     console.log('This is normal in a browser',err);
   }
 }*/
  initializeApp() {
    const {SplashScreen, StatusBar}= Plugins;
    this.authService.doLogout();

    this.platform.ready().then(() => {
      this.afAuth.user.subscribe(user => {
        if(user){
          this.router.navigate(["/menu"]);
        } else {
          this.router.navigate(["/log"]);
        }//log
      }, err => {
        this.router.navigate(["/log"]);
      }, () => {
        SplashScreen.hide();
      })
      StatusBar.setStyle({style:StatusBarStyle.Light});
    });
  }

  ngOnInit() {
    const path = window.location.pathname.split('folder/')[1];
    if (path !== undefined) {
      this.selectedIndex = this.appPages.findIndex(page => page.title.toLowerCase() === path.toLowerCase());
    }
  }
  logOut(){
    this.authService.doLogout()
    .then(res => {
      this.menuCrtl.enable(false);
      this.router.navigate(["/log"]);
    }, err => {
      console.log(err);
    })
  }
}
