import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { ConsultarOrdenCelPage } from './consultar-orden-cel.page';

const routes: Routes = [
  {
    path: '',
    component: ConsultarOrdenCelPage
  },
  {
    path: ':dtoOrdenDeReparacionCelularId',
    component: ConsultarOrdenCelPage
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class ConsultarOrdenCelPageRoutingModule {}
