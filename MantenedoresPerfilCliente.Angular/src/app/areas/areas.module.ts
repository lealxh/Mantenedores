import { AreasRoutingModule } from './areas-routing.module';
import { DetalleAreasComponent } from './detalle/detalle-areas.component';
import { EliminarAreasComponent } from './eliminar/eliminar-areas.component';
import { ListaAreasComponent } from './listar/lista-areas.component';
import { AreasService } from '../shared/services/areas.service';

import { NgxSpinnerModule } from 'ngx-spinner';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { EditarAreasComponent } from './editar/editar-areas.component';



@NgModule({
  imports: [
    HttpClientModule,
    HttpModule,
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    AreasRoutingModule,
    NgxSpinnerModule
  ],
  declarations: [
    ListaAreasComponent,
    EditarAreasComponent,
    EliminarAreasComponent,
    DetalleAreasComponent
],
  providers: [HttpClient, AreasService]
})
export class AreasModule {}
