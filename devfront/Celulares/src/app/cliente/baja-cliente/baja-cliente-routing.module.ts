import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { BajaClientePage } from './baja-cliente.page';

const routes: Routes = [
  {
    path: '',
    component: BajaClientePage
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class BajaClientePageRoutingModule {}
