import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { IonicModule } from '@ionic/angular';

import { ConsultarClientePageRoutingModule } from './consultar-cliente-routing.module';

import { ConsultarClientePage } from './consultar-cliente.page';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    IonicModule,
    ConsultarClientePageRoutingModule
  ],
  declarations: [ConsultarClientePage]
})
export class ConsultarClientePageModule {}
