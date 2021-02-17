import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { IonicModule } from '@ionic/angular';

import { AltaOrdenPcPageRoutingModule } from './alta-orden-pc-routing.module';

import { AltaOrdenPcPage } from './alta-orden-pc.page';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    IonicModule,
    AltaOrdenPcPageRoutingModule
  ],
  declarations: [AltaOrdenPcPage]
})
export class AltaOrdenPcPageModule {}
