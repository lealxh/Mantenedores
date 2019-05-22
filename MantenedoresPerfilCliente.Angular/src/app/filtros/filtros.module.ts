import { EditarFiltrosComponent } from './editar/editar-filtros.component';
import { CodigoFiltroOcupadoValidatorDirective } from '../shared/directives/codigo-filtro-ocupado.directive';
import {
  OrdenFiltroOcupadoValidator,
  OrdenFiltroOcupadoValidatorDirective
} from '../shared/directives/orden-filtro-ocupado.directive';
import { CodigoFiltroOcupadoValidator } from '../shared/directives/codigo-filtro-ocupado.directive';
import { DetalleFiltrosComponent } from './detalle/detalle-filtros.component';
import { EliminarFiltrosComponent } from './eliminar/eliminar-filtros.component';
import { PerfilesService } from '../shared/services/perfiles.service';
import { NgxSpinnerModule } from 'ngx-spinner';
import { FiltrosRoutingModule } from './filtros-routing.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { EstadoFiltrosService } from '../shared/services/estado-filtros.service';
import { FiltrosService } from '../shared/services/filtros.service';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ListaFiltrosComponent } from './listar/lista-filtros.component';
import { UniversosService } from '../shared/services/universos.service';

@NgModule({
  imports: [
    HttpClientModule,
    HttpModule,
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    FiltrosRoutingModule,
    NgxSpinnerModule
  ],
  declarations: [
    ListaFiltrosComponent,
    EditarFiltrosComponent,
    EliminarFiltrosComponent,
    DetalleFiltrosComponent,
    CodigoFiltroOcupadoValidatorDirective,
    OrdenFiltroOcupadoValidatorDirective
  ],
  providers: [HttpClient, FiltrosService, EstadoFiltrosService, UniversosService, PerfilesService]
})
export class FiltrosModule {}
