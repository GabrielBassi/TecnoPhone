import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { IonicModule } from '@ionic/angular';

import { AltaOrdenCelPageRoutingModule } from './alta-orden-cel-routing.module';

import { AltaOrdenCelPage } from './alta-orden-cel.page';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    IonicModule,
    AltaOrdenCelPageRoutingModule
  ],
  declarations: [AltaOrdenCelPage]
})
export class AltaOrdenCelPageModule {}
