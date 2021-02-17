import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { IonicModule } from '@ionic/angular';

import { ModificarOrdenCelPageRoutingModule } from './modificar-orden-cel-routing.module';

import { ModificarOrdenCelPage } from './modificar-orden-cel.page';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    IonicModule,
    ModificarOrdenCelPageRoutingModule
  ],
  declarations: [ModificarOrdenCelPage]
})
export class ModificarOrdenCelPageModule {}
