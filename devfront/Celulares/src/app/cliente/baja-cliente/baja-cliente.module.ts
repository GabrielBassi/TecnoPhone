import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { IonicModule } from '@ionic/angular';

import { BajaClientePageRoutingModule } from './baja-cliente-routing.module';

import { BajaClientePage } from './baja-cliente.page';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    IonicModule,
    BajaClientePageRoutingModule
  ],
  declarations: [BajaClientePage]
})
export class BajaClientePageModule {}
