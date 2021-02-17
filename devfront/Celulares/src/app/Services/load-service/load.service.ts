import { Injectable } from '@angular/core';
import { LoadingController } from '@ionic/angular';

@Injectable({
  providedIn: 'root'
})
export class LoadService {

  constructor(public loadingController: LoadingController) { }
  async presentLoading(message: string) {
    const loading = await this.loadingController.create({
      message
    });
    return loading.present();
  }

  async presentLoadingWithTime(message: string, duration: number) {
    const loading = await this.loadingController.create({
      message,
      duration
    });
    return loading.present();
  }

}
