import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { IonicModule } from '@ionic/angular';

import { BajaOrdenPcPageRoutingModule } from './baja-orden-pc-routing.module';

import { BajaOrdenPcPage } from './baja-orden-pc.page';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    IonicModule,
    BajaOrdenPcPageRoutingModule
  ],
  declarations: [BajaOrdenPcPage]
})
export class BajaOrdenPcPageModule {}
