import { MotivosBloqueoService } from '../shared/services/motivos-bloqueo.service';
import { CargosService } from '../shared/services/cargos.service';
import { AreasService } from '../shared/services/areas.service';
import { ExclusionesService } from '../shared/services/exclusiones.service';
import { EditarExclusionesComponent } from './editar/editar-exclusiones.component';
import { DetalleExclusionesComponent } from './detalle/detalle-exclusiones.component';
import { EliminarExclusionesComponent } from './eliminar/eliminar-exclusiones.component';
import { ExclusionesRoutingModule } from './exclusiones-routing.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { HttpClient, HttpClientModule } from '@angular/common/http';

import { FiltrosService } from '../shared/services/filtros.service';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ListaExclusionesComponent } from './listar/lista-exclusiones.component';
import { NgxSpinnerModule } from 'ngx-spinner';
import { Ng2Rut } from 'ng2-rut';

@NgModule({
  imports: [
    HttpClientModule,
    HttpModule,
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    ExclusionesRoutingModule,
    NgxSpinnerModule,
    Ng2Rut
  ],
  declarations: [
    ListaExclusionesComponent,
    EditarExclusionesComponent,
    EliminarExclusionesComponent,
    DetalleExclusionesComponent
  ],
  providers: [HttpClient, ExclusionesService, AreasService, CargosService, MotivosBloqueoService]
})
export class ExclusionesModule {}
