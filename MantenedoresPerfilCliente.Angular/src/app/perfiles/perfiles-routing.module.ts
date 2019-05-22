import { AuthGuard } from './../shared/guards/auth.guard';
import { EditarPerfilesComponent } from './editar/editar-perfiles.component';
import { EliminarPerfilesComponent } from './eliminar/eliminar-perfiles.component';
import { ListaPerfilesComponent } from './listar/lista-perfiles.component';
import { DetallePerfilesComponent } from './detalle/detalle-perfiles.component';

// tslint:disable-next-line:import-spacing
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const appRoutes: Routes = [
  { path: 'perfiles/listar', component: ListaPerfilesComponent, canActivate: [AuthGuard]},
  { path: 'perfiles/editar/:id', component: EditarPerfilesComponent, canActivate: [AuthGuard] },
  { path: 'perfiles/eliminar/:id', component: EliminarPerfilesComponent, canActivate: [AuthGuard]},
  { path: 'perfiles/detalles/:id', component: DetallePerfilesComponent, canActivate: [AuthGuard]},
  { path: 'perfiles', redirectTo: 'perfiles/listar' }
];

@NgModule({
  imports: [RouterModule.forChild(appRoutes)],
  declarations: [],
  exports: [RouterModule],
  providers: []
})
export class PerfilesRoutingModule {}
