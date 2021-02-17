import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { AltaOrdenCelPage } from './alta-orden-cel.page';

const routes: Routes = [
  {
    path: '',
    component: AltaOrdenCelPage
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class AltaOrdenCelPageRoutingModule {}
