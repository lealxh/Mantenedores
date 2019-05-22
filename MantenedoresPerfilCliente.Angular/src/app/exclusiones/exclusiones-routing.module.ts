import { AuthGuard } from './../shared/guards/auth.guard';
import { EditarExclusionesComponent } from './editar/editar-exclusiones.component';
import { DetalleExclusionesComponent } from './detalle/detalle-exclusiones.component';
import { EliminarExclusionesComponent } from './eliminar/eliminar-exclusiones.component';
import { ListaExclusionesComponent } from './listar/lista-exclusiones.component';
// tslint:disable-next-line:import-spacing
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const appRoutes: Routes = [
  { path: 'exclusiones/listar', component: ListaExclusionesComponent, canActivate: [AuthGuard] },
  { path: 'exclusiones/editar/:id', component: EditarExclusionesComponent, canActivate: [AuthGuard] },
  { path: 'exclusiones/eliminar/:id', component: EliminarExclusionesComponent, canActivate: [AuthGuard]},
  { path: 'exclusiones/detalles/:id', component: DetalleExclusionesComponent, canActivate: [AuthGuard]},
  { path: 'exclusiones', redirectTo: 'exclusiones/listar' }
];

@NgModule({
  imports: [RouterModule.forChild(appRoutes)],
  declarations: [],
  exports: [RouterModule],
  providers: []
})
export class ExclusionesRoutingModule {}
