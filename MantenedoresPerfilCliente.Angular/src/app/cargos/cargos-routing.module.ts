import { AuthGuard } from './../shared/guards/auth.guard';
import { DetalleCargosComponent } from './detalle/detalle-cargos.component';
import { EliminarCargosComponent } from './eliminar/eliminar-cargos.component';
import { EditarCargosComponent } from './editar/editar-cargos.component';
import { ListaCargosComponent } from './listar/lista-cargos.component';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';


const appRoutes: Routes = [
  { path: 'cargos/listar', component: ListaCargosComponent, canActivate: [AuthGuard] },
  { path: 'cargos/editar/:id', component: EditarCargosComponent, canActivate: [AuthGuard]},
  { path: 'cargos/eliminar/:id', component: EliminarCargosComponent, canActivate: [AuthGuard] },
  { path: 'cargos/detalles/:id', component: DetalleCargosComponent, canActivate: [AuthGuard] },
  { path: 'cargos', redirectTo: 'cargos/listar' }
];



@NgModule({
  imports: [RouterModule.forChild(appRoutes)],
  declarations: [],
  exports: [RouterModule],
  providers: []
})
export class CargosRoutingModule {}
