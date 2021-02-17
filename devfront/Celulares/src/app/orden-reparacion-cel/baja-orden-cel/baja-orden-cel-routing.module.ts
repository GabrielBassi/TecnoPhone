import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { BajaOrdenCelPage } from './baja-orden-cel.page';

const routes: Routes = [
  {
    path: '',
    component: BajaOrdenCelPage
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class BajaOrdenCelPageRoutingModule {}
