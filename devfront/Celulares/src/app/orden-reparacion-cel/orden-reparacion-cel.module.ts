import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { IonicModule } from '@ionic/angular';

import { OrdenReparacionCelPageRoutingModule } from './orden-reparacion-cel-routing.module';

import { OrdenReparacionCelPage } from './orden-reparacion-cel.page';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    IonicModule,
    OrdenReparacionCelPageRoutingModule
  ],
  declarations: [OrdenReparacionCelPage]
})
export class OrdenReparacionCelPageModule {}
