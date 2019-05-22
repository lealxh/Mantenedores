import { AuthGuard } from './../shared/guards/auth.guard';
import { DetalleMotivosBloqueoComponent } from './detalle/detalle-motivosbloqueo.component';
import { EliminarMotivosBloqueoComponent } from './eliminar/eliminar-motivosbloqueo.component';
import { EditarMotivosBloqueoComponent } from './editar/editar-motivosbloqueo.component';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ListaMotivosBloqueoComponent } from './listar/lista-motivosbloqueo.component';


const appRoutes: Routes = [
  { path: 'motivosbloqueo/listar', component: ListaMotivosBloqueoComponent, canActivate: [AuthGuard] },
  { path: 'motivosbloqueo/editar/:id', component: EditarMotivosBloqueoComponent, canActivate: [AuthGuard]},
  { path: 'motivosbloqueo/eliminar/:id', component: EliminarMotivosBloqueoComponent, canActivate: [AuthGuard]},
  { path: 'motivosbloqueo/detalles/:id', component: DetalleMotivosBloqueoComponent, canActivate: [AuthGuard]},
  { path: 'motivosbloqueo', redirectTo: 'motivosbloqueo/listar' }
];



@NgModule({
  imports: [RouterModule.forChild(appRoutes)],
  declarations: [],
  exports: [RouterModule],
  providers: []
})
export class MotivosBloqueoRoutingModule {}
