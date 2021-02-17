import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { IonicModule } from '@ionic/angular';

import { ConsultarOrdenCelPageRoutingModule } from './consultar-orden-cel-routing.module';

import { ConsultarOrdenCelPage } from './consultar-orden-cel.page';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    IonicModule,
    ConsultarOrdenCelPageRoutingModule
  ],
  declarations: [ConsultarOrdenCelPage]
})
export class ConsultarOrdenCelPageModule {}
