import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { AltaOrdenPcPage } from './alta-orden-pc.page';

const routes: Routes = [
  {
    path: '',
    component: AltaOrdenPcPage
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class AltaOrdenPcPageRoutingModule {}
