import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { BajaOrdenPcPage } from './baja-orden-pc.page';

const routes: Routes = [
  {
    path: '',
    component: BajaOrdenPcPage
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class BajaOrdenPcPageRoutingModule {}
