import { EliminarEstadoPerfilesComponent } from './eliminar/eliminar-estadoperfiles.component';
import { DetalleEstadoPerfilesComponent } from './detalle/detalle-estadoperfiles.component';
import { EstadoPerfilesService } from '../shared/services/estado-perfiles.service';
import { ListaEstadoPerfilesComponent } from './listar/lista-estadoperfiles.component';
import { NgxSpinnerModule } from 'ngx-spinner';
import { EstadoPerfilesRoutingModule } from './estadoperfiles-routing.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { EditarEstadoPerfilesComponent } from './editar/editar-estadoperfiles.component';


@NgModule({
  imports: [
    HttpClientModule,
    HttpModule,
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    EstadoPerfilesRoutingModule,
    NgxSpinnerModule
  ],
  declarations: [
    ListaEstadoPerfilesComponent,
    EditarEstadoPerfilesComponent,
    EliminarEstadoPerfilesComponent,
    DetalleEstadoPerfilesComponent
],
  providers: [HttpClient, EstadoPerfilesService]
})
export class EstadoPerfilesModule {}
