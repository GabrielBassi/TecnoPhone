import { Injectable } from '@angular/core';
import { AlertController } from '@ionic/angular';
import { async } from 'rxjs/internal/scheduler/async';

@Injectable({
  providedIn: 'root'
})
export class AlertService {

  constructor(public alertController: AlertController) { }

async presentAlert(pHeader, pSubHeader, pError) {
  const alert = await this.alertController.create({
    cssClass: 'my-custom-class',
    header: pHeader,
    subHeader: pSubHeader,
    message: pError,
    buttons: ['Ok']
  });

  await alert.present();
  }
  async presentConfirmation(pTitulo: any, pMensaje: any,pTextoCancelar: any, pTextoConfirmar: any): Promise<any> {
    return new Promise(async (resolve) => {
      const alert = await this.alertController.create({
        header: pTitulo,
        message: pMensaje,
        buttons: [
          {
            text: pTextoCancelar,
            role: 'cancel',
            cssClass: 'secondary',
            handler: (cancel) => {
              resolve('cancel');
            }
          }, {
            text: pTextoConfirmar,
            handler: (ok) => {
              resolve('ok');
            }
          }
        ]
      });
      alert.present();
    });
  }
}