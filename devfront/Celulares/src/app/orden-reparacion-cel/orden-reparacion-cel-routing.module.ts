import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { OrdenReparacionCelPage } from './orden-reparacion-cel.page';

const routes: Routes = [
  {
    path: '',
    component: OrdenReparacionCelPage
  },
  {
    path: 'alta-orden-cel',
    loadChildren: () => import('./alta-orden-cel/alta-orden-cel.module').then( m => m.AltaOrdenCelPageModule)
  },
  {
    path: 'baja-orden-cel',
    loadChildren: () => import('./baja-orden-cel/baja-orden-cel.module').then( m => m.BajaOrdenCelPageModule)
  },
  {
    path: 'modificar-orden-cel',
    loadChildren: () => import('./modificar-orden-cel/modificar-orden-cel.module').then( m => m.ModificarOrdenCelPageModule)
  },
  {
    path: 'consultar-orden-cel',
    loadChildren: () => import('./consultar-orden-cel/consultar-orden-cel.module').then( m => m.ConsultarOrdenCelPageModule)
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class OrdenReparacionCelPageRoutingModule {}
