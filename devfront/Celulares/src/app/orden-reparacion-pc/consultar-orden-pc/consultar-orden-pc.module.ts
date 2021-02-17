import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { IonicModule } from '@ionic/angular';

import { ConsultarOrdenPcPageRoutingModule } from './consultar-orden-pc-routing.module';

import { ConsultarOrdenPcPage } from './consultar-orden-pc.page';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    IonicModule,
    ConsultarOrdenPcPageRoutingModule
  ],
  declarations: [ConsultarOrdenPcPage]
})
export class ConsultarOrdenPcPageModule {}
