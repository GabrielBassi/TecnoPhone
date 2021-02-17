import { NgModule } from '@angular/core';
import { PreloadAllModules, RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  {
    path: '',
    redirectTo: 'log',
    pathMatch: 'full'
  },
  {
    path: 'folder/:id',
    loadChildren: () => import('./folder/folder.module').then( m => m.FolderPageModule)
  },
  {
    path: 'cliente',
    loadChildren: () => import('./cliente/cliente.module').then( m => m.ClientePageModule)
  },
  {
    path: 'orden-reparacion-cel',
    loadChildren: () => import('./orden-reparacion-cel/orden-reparacion-cel.module').then( m => m.OrdenReparacionCelPageModule)
  },
  {
    path: 'orden-reparacion-pc',
    loadChildren: () => import('./orden-reparacion-pc/orden-reparacion-pc.module').then( m => m.OrdenReparacionPcPageModule)
  },
  {
    path: 'menu',
    loadChildren: () => import('./menu/menu.module').then( m => m.MenuPageModule)
  }
  ,
  {
    path: 'log',
    loadChildren: () => import('./log/log.module').then( m => m.LogPageModule)
  }


];

@NgModule({
  imports: [
   // RouterModule.forRoot(routes, { preloadingStrategy: PreloadAllModules })
   RouterModule.forRoot(routes, { useHash: true })
  ],
  exports: [RouterModule]
})
export class AppRoutingModule {}
