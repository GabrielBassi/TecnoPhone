import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { IonicModule } from '@ionic/angular';

import { OrdenReparacionPcPageRoutingModule } from './orden-reparacion-pc-routing.module';

import { OrdenReparacionPcPage } from './orden-reparacion-pc.page';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    IonicModule,
    OrdenReparacionPcPageRoutingModule
  ],
  declarations: [OrdenReparacionPcPage]
})
export class OrdenReparacionPcPageModule {}
