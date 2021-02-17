import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { IonicModule } from '@ionic/angular';

import { ModificarOrdenPcPageRoutingModule } from './modificar-orden-pc-routing.module';

import { ModificarOrdenPcPage } from './modificar-orden-pc.page';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    IonicModule,
    ModificarOrdenPcPageRoutingModule
  ],
  declarations: [ModificarOrdenPcPage]
})
export class ModificarOrdenPcPageModule {}
