import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { ConsultarOrdenPcPage } from './consultar-orden-pc.page';

const routes: Routes = [
  {
    path: '',
    component: ConsultarOrdenPcPage
  },
  {
    path: ':dtoOrdenDeReparacionPcId',
    component: ConsultarOrdenPcPage
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class ConsultarOrdenPcPageRoutingModule {}
