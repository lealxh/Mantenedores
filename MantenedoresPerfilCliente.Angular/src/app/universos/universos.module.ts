import { UniversosService } from '../shared/services/universos.service';
import { DetalleUniversosComponent } from './detalle/detalle-universos.component';
import { EliminarUniversosComponent } from './eliminar/eliminar-universos.component';
import { EditarUniversosComponent } from './editar/editar-universos.component';
import { UniversosRoutingModule } from './universos-routing.module';

import { NgxSpinnerModule } from 'ngx-spinner';

import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ListaUniversosComponent } from './listar/lista-universos.component';


@NgModule({
  imports: [
    HttpClientModule,
    HttpModule,
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    UniversosRoutingModule,
    NgxSpinnerModule
  ],
  declarations: [
    ListaUniversosComponent,
    EditarUniversosComponent,
    EliminarUniversosComponent,
    DetalleUniversosComponent
],
  providers: [HttpClient, UniversosService]
})
export class UniversosModule {}
