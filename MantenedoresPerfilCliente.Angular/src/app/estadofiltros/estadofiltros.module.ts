import { DetalleEstadoFiltrosComponent } from './detalle/detalle-estadofiltros.component';
import { EstadoFiltrosService } from '../shared/services/estado-filtros.service';
import { EliminarEstadoFiltrosComponent } from './eliminar/eliminar-estadofiltros.component';
import { ListaEstadoFiltrosComponent } from './listar/lista-estadofiltros.component';
import { NgxSpinnerModule } from 'ngx-spinner';
import { EstadoFiltrosRoutingModule } from './EstadoFiltros-routing.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { EditarEstadoFiltrosComponent } from './editar/editar-estadofiltros.component';


@NgModule({
  imports: [
    HttpClientModule,
    HttpModule,
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    EstadoFiltrosRoutingModule,
    NgxSpinnerModule
  ],
  declarations: [
    ListaEstadoFiltrosComponent,
    EditarEstadoFiltrosComponent,
    EliminarEstadoFiltrosComponent,
    DetalleEstadoFiltrosComponent
],
  providers: [HttpClient, EstadoFiltrosService]
})
export class EstadoFiltrosModule {}
