import { AuthGuard } from './../shared/guards/auth.guard';
import { EliminarEstadoPerfilesComponent } from './eliminar/eliminar-estadoperfiles.component';
import { EditarEstadoPerfilesComponent } from './editar/editar-estadoperfiles.component';
import { DetalleEstadoPerfilesComponent } from './detalle/detalle-estadoperfiles.component';
import { ListaEstadoPerfilesComponent } from './listar/lista-estadoperfiles.component';
// tslint:disable-next-line:import-spacing
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const appRoutes: Routes = [
  { path: 'estadoperfiles/listar', component: ListaEstadoPerfilesComponent, canActivate: [AuthGuard]},
  { path: 'estadoperfiles/editar/:id', component: EditarEstadoPerfilesComponent, canActivate: [AuthGuard]},
  { path: 'estadoperfiles/eliminar/:id', component: EliminarEstadoPerfilesComponent, canActivate: [AuthGuard]},
  { path: 'estadoperfiles/detalles/:id', component: DetalleEstadoPerfilesComponent, canActivate: [AuthGuard]},
  { path: 'estadoperfiles', redirectTo: 'estadoperfiles/listar' }
];

@NgModule({
  imports: [RouterModule.forChild(appRoutes)],
  declarations: [],
  exports: [RouterModule],
  providers: []
})
export class EstadoPerfilesRoutingModule {}
