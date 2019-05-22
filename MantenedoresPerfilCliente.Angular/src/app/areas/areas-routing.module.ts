import { AuthGuard } from './../shared/guards/auth.guard';
import { EliminarAreasComponent } from './eliminar/eliminar-areas.component';
import { ListaAreasComponent } from './listar/lista-areas.component';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { EditarAreasComponent } from './editar/editar-areas.component';
import { DetalleAreasComponent } from './detalle/detalle-areas.component';

const appRoutes: Routes = [
  { path: 'areas/listar', component: ListaAreasComponent, canActivate: [AuthGuard] },
  { path: 'areas/editar/:id', component: EditarAreasComponent, canActivate: [AuthGuard]},
  { path: 'areas/eliminar/:id', component: EliminarAreasComponent, canActivate: [AuthGuard] },
  { path: 'areas/detalles/:id', component: DetalleAreasComponent, canActivate: [AuthGuard] },
  { path: 'areas', redirectTo: 'areas/listar' }
];

@NgModule({
  imports: [RouterModule.forChild(appRoutes)],
  declarations: [],
  exports: [RouterModule],
  providers: []
})
export class AreasRoutingModule {}
