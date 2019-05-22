import { AuthGuard } from './../shared/guards/auth.guard';
import { DetalleUniversosComponent } from './detalle/detalle-universos.component';
import { EliminarUniversosComponent } from './eliminar/eliminar-universos.component';
import { EditarUniversosComponent } from './editar/editar-universos.component';
import { ListaUniversosComponent } from './listar/lista-universos.component';

// tslint:disable-next-line:import-spacing
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const appRoutes: Routes = [
  { path: 'universos/listar', component: ListaUniversosComponent, canActivate: [AuthGuard] },
  { path: 'universos/editar/:id', component: EditarUniversosComponent, canActivate: [AuthGuard]},
  { path: 'universos/eliminar/:id', component: EliminarUniversosComponent, canActivate: [AuthGuard]},
  { path: 'universos/detalles/:id', component: DetalleUniversosComponent, canActivate: [AuthGuard]},
  { path: 'universos', redirectTo: 'universos/listar' }
];

@NgModule({
  imports: [RouterModule.forChild(appRoutes)],
  declarations: [],
  exports: [RouterModule],
  providers: []
})
export class UniversosRoutingModule {}
