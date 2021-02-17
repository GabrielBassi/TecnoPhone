import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { OrdenReparacionPcPage } from './orden-reparacion-pc.page';

const routes: Routes = [
  {
    path: '',
    component: OrdenReparacionPcPage
  },
  {
    path: 'alta-orden-pc',
    loadChildren: () => import('./alta-orden-pc/alta-orden-pc.module').then( m => m.AltaOrdenPcPageModule)
  },
  {
    path: 'baja-orden-pc',
    loadChildren: () => import('./baja-orden-pc/baja-orden-pc.module').then( m => m.BajaOrdenPcPageModule)
  },
  {
    path: 'modificar-orden-pc',
    loadChildren: () => import('./modificar-orden-pc/modificar-orden-pc.module').then( m => m.ModificarOrdenPcPageModule)
  },
  {
    path: 'consultar-orden-pc',
    loadChildren: () => import('./consultar-orden-pc/consultar-orden-pc.module').then( m => m.ConsultarOrdenPcPageModule)
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class OrdenReparacionPcPageRoutingModule {}
