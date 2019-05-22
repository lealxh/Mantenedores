import { AuthGuard } from './../shared/guards/auth.guard';
import { EditarFiltrosComponent } from './editar/editar-filtros.component';
import { DetalleFiltrosComponent } from './detalle/detalle-filtros.component';
import { EliminarFiltrosComponent } from './eliminar/eliminar-filtros.component';
import { ListaFiltrosComponent } from './listar/lista-filtros.component';
// tslint:disable-next-line:import-spacing
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const appRoutes: Routes = [
  { path: 'filtros/listar', component: ListaFiltrosComponent, canActivate: [AuthGuard] },
  { path: 'filtros/editar/:id', component: EditarFiltrosComponent, canActivate: [AuthGuard] },
  { path: 'filtros/eliminar/:id', component: EliminarFiltrosComponent, canActivate: [AuthGuard] },
  { path: 'filtros/detalles/:id', component: DetalleFiltrosComponent, canActivate: [AuthGuard] },
  { path: 'filtros', redirectTo: 'filtros/listar' }
];

@NgModule({
  imports: [RouterModule.forChild(appRoutes)],
  declarations: [],
  exports: [RouterModule],
  providers: []
})
export class FiltrosRoutingModule {}
