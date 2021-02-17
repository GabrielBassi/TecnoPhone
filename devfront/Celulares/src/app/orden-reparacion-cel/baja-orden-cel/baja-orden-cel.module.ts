import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { IonicModule } from '@ionic/angular';

import { BajaOrdenCelPageRoutingModule } from './baja-orden-cel-routing.module';

import { BajaOrdenCelPage } from './baja-orden-cel.page';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    IonicModule,
    BajaOrdenCelPageRoutingModule
  ],
  declarations: [BajaOrdenCelPage]
})
export class BajaOrdenCelPageModule {}
