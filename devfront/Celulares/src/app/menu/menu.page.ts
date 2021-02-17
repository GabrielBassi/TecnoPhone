import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { MenuController } from '@ionic/angular';
import { AuthsService } from '../Services/auth/auths.service';

@Component({
  selector: 'app-menu',
  templateUrl: './menu.page.html',
  styleUrls: ['./menu.page.scss'],
})
export class MenuPage implements OnInit {
  isAdmin:boolean;
  constructor(private router: Router, private menu: MenuController,private auservice: AuthsService,private menuCrtl: MenuController) { 
    this.menu.enable(true);
  }

  ngOnInit() {
    console.log('antes de usar servicio '+ this.auservice.uId);
   this.isAdmin=this.auservice.ControlAdmin(this.auservice.uId);
   console.log('ustedes es '+this.isAdmin);
   console.log('inicio yo de nuevo');
   if (this.isAdmin==true) {
     this.menu.enable(true);
   } else {
     this.menu.enable(false);
   }
 }
  ionViewWillEnter(){
   
    console.log('estoy en ionview'+ this.auservice.uId);
    this.isAdmin=this.auservice.ControlAdmin(this.auservice.uId);
    console.log('estoy en ionview ustedes es '+this.isAdmin);
    if (this.isAdmin==true) {
      this.menu.enable(true);
    } else {
      this.menu.enable(false);
    }
  }
  logOut(){
    this.auservice.doLogout()
    .then(res => {
      this.menuCrtl.enable(false);
      this.router.navigate(["/log"]);
    }, err => {
      console.log(err);
    })
  }
}
