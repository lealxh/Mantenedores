import { AuthGuard } from './../shared/guards/auth.guard';
import { DetalleEstadoFiltrosComponent } from './detalle/detalle-estadofiltros.component';
import { EliminarEstadoFiltrosComponent } from './eliminar/eliminar-estadofiltros.component';
import { EditarEstadoFiltrosComponent } from './editar/editar-estadofiltros.component';
import { ListaEstadoFiltrosComponent } from './listar/lista-estadofiltros.component';

// tslint:disable-next-line:import-spacing
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const appRoutes: Routes = [
  { path: 'estadofiltros/listar', component: ListaEstadoFiltrosComponent, canActivate: [AuthGuard] },
  { path: 'estadofiltros/editar/:id', component: EditarEstadoFiltrosComponent, canActivate: [AuthGuard]},
  { path: 'estadofiltros/eliminar/:id', component: EliminarEstadoFiltrosComponent, canActivate: [AuthGuard]},
  { path: 'estadofiltros/detalles/:id', component: DetalleEstadoFiltrosComponent, canActivate: [AuthGuard]},
  { path: 'estadofiltros', redirectTo: 'estadofiltros/listar' }
];

@NgModule({
  imports: [RouterModule.forChild(appRoutes)],
  declarations: [],
  exports: [RouterModule],
  providers: []
})
export class EstadoFiltrosRoutingModule {}
