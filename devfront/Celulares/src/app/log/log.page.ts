import { Component, OnInit } from '@angular/core';
import { Validators, FormBuilder, FormGroup, FormControl } from '@angular/forms';

import { Router } from '@angular/router';
import { MenuController} from '@ionic/angular';
import { AuthsService } from '../Services/auth/auths.service';

@Component({
  selector: 'app-login',
  templateUrl: './log.page.html',
  styleUrls: ['./log.page.scss'],
})
export class LogPage implements OnInit {
  isAdmin:boolean;
  validations_form: FormGroup;
  errorMessage: string = '';
  loading: boolean = false;

  validation_messages = {
   'email': [
     { type: 'required', message: 'El correo electrónico es requerido.' },
     { type: 'pattern', message: 'Ingrese un correo electrónico válido.' }
   ],
   'password': [
     { type: 'required', message: 'La contraseña es requerida.' },
     { type: 'minlength', message: 'La contraseña debe tener al menos 5 caracteres.' }
   ]
 };

  constructor(private authService: AuthsService,
              private formBuilder: FormBuilder,
              private router: Router,
              private menu: MenuController) {
    
    this.menu.enable(false);
  }

  ngOnInit() {
    console.log('antes de usar servicio '+ this.authService.uId);
    this.isAdmin=this.authService.ControlAdmin(this.authService.uId);
    console.log('ustedes es '+this.isAdmin);
    this.validations_form = this.formBuilder.group({
      email: new FormControl('', Validators.compose([
        Validators.required,
        Validators.pattern('^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+.[a-zA-Z0-9-.]+$')
      ])),
      password: new FormControl('', Validators.compose([
        Validators.minLength(5),
        Validators.required
      ])),
    });
  }

  tryLogin(value){
    this.loading = true;
    this.authService.doLogin(value)
    .then(res => {
      console.log('segundo control');
      this.authService.ControlAdmin(this.authService.uId);
      this.router.navigate(["/menu"]);
    }, err => {
      if (err.code == "auth/user-not-found" || err.code == "auth/wrong-password" ) {
        this.errorMessage = "Contraseña o correo electrónico incorrecto";
      } else {
        this.errorMessage = err.message;
      }
    }).finally(
      () => {
        this.loading = false;
      }
    );
  }

  /* activateMenu(){
    this.menu.enable(true);
    this.navCtrl.navigateRoot("/search-book");
  } */ 
  ionViewWillEnter(){
    this.validations_form.controls.email.setValue('');
    this.validations_form.controls.email.markAsPristine();
    this.validations_form.controls.email.markAsUntouched();

    this.validations_form.controls.password.setValue('');
    this.validations_form.controls.password.markAsPristine();
    this.validations_form.controls.password.markAsUntouched();
    console.log('estoy en ionview'+ this.authService.uId);
    this.isAdmin=this.authService.ControlAdmin(this.authService.uId);
    console.log('estoy en ionview ustedes es '+this.isAdmin);
  }

}

