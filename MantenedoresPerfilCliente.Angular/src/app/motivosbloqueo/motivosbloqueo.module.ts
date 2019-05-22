import { ListaMotivosBloqueoComponent } from './listar/lista-motivosbloqueo.component';
import { EditarMotivosBloqueoComponent } from './editar/editar-motivosbloqueo.component';
import { DetalleMotivosBloqueoComponent } from './detalle/detalle-motivosbloqueo.component';
import { MotivosBloqueoService } from '../shared/services/motivos-bloqueo.service';

import { NgxSpinnerModule } from 'ngx-spinner';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { EliminarMotivosBloqueoComponent } from './eliminar/eliminar-motivosbloqueo.component';
import { MotivosBloqueoRoutingModule } from './motivosbloqueo-routing.module';




@NgModule({
  imports: [
    HttpClientModule,
    HttpModule,
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    MotivosBloqueoRoutingModule,
    NgxSpinnerModule
  ],
  declarations: [
    ListaMotivosBloqueoComponent,
    EditarMotivosBloqueoComponent,
    EliminarMotivosBloqueoComponent,
    DetalleMotivosBloqueoComponent
],
  providers: [HttpClient, MotivosBloqueoService]
})
export class MotivosBloqueoModule {}
