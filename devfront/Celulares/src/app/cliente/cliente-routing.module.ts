import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { ClientePage } from './cliente.page';

const routes: Routes = [
  {
    path: '',
    component: ClientePage
  },
  {
    path: 'alta-cliente',
    loadChildren: () => import('./alta-cliente/alta-cliente.module').then( m => m.AltaClientePageModule)
  },
  {
    path: 'baja-cliente',
    loadChildren: () => import('./baja-cliente/baja-cliente.module').then( m => m.BajaClientePageModule)
  },
  {
    path: 'modificar-cliente',
    loadChildren: () => import('./modificar-cliente/modificar-cliente.module').then( m => m.ModificarClientePageModule)
  },
  {
    path: 'consultar-cliente',
    loadChildren: () => import('./consultar-cliente/consultar-cliente.module').then( m => m.ConsultarClientePageModule)
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class ClientePageRoutingModule {}
