import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { ModificarOrdenPcPage } from './modificar-orden-pc.page';

const routes: Routes = [
  {
    path: '',
    component: ModificarOrdenPcPage
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class ModificarOrdenPcPageRoutingModule {}
