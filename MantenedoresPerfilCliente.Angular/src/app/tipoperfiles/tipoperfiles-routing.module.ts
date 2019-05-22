import { AuthGuard } from './../shared/guards/auth.guard';
import { EliminarTipoPerfilesComponent } from './eliminar/eliminar-tipoperfiles.component';
import { DetalleTipoPerfilesComponent } from './detalle/detalle-tipoperfiles.component';
import { EditarTipoPerfilesComponent } from './editar/editar-tipoperfiles.component';
import { ListaTipoPerfilesComponent } from './listar/lista-tipoperfiles.component';
// tslint:disable-next-line:import-spacing
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const appRoutes: Routes = [
  { path: 'tipoperfiles/listar', component: ListaTipoPerfilesComponent, canActivate: [AuthGuard]},
  { path: 'tipoperfiles/editar/:id', component: EditarTipoPerfilesComponent, canActivate: [AuthGuard]},
  { path: 'tipoperfiles/eliminar/:id', component: EliminarTipoPerfilesComponent, canActivate: [AuthGuard]},
  { path: 'tipoperfiles/detalles/:id', component: DetalleTipoPerfilesComponent, canActivate: [AuthGuard]},
  { path: 'tipoperfiles', redirectTo: 'tipoperfiles/listar' }
];

@NgModule({
  imports: [RouterModule.forChild(appRoutes)],
  declarations: [],
  exports: [RouterModule],
  providers: []
})
export class TipoPerfilesRoutingModule {}
