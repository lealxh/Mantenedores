import {
  CodigoPerfilOcupadoValidator,
  CodigoPerfilOcupadoValidatorDirective
} from '../shared/directives/codigo-perfil-ocupado.directive';
import { EstadoPerfilesService } from '../shared/services/estado-perfiles.service';
import { EstadoPerfiles } from '../shared/models/estado-perfiles';
import { HttpClient } from '@angular/common/http';
import { TipoPerfilesService } from '../shared/services/tipo-perfiles.service';
import { EditarPerfilesComponent } from './editar/editar-perfiles.component';
import { EliminarPerfilesComponent } from './eliminar/eliminar-perfiles.component';
import { DetallePerfilesComponent } from './detalle/detalle-perfiles.component';
import { ListaPerfilesComponent } from './listar/lista-perfiles.component';
import { PerfilesService } from '../shared/services/perfiles.service';
import { PerfilesRoutingModule } from './perfiles-routing.module';
// tslint:disable-next-line:import-spacing
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { HttpClientModule } from '@angular/common/http';
import { HttpModule } from '@angular/http';
import { NgxSpinnerModule } from 'ngx-spinner';

// tslint:disable-next-line:import-spacing

@NgModule({
  imports: [
    HttpClientModule,
    HttpModule,
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    PerfilesRoutingModule,
    NgxSpinnerModule
  ],
  declarations: [
    ListaPerfilesComponent,
    DetallePerfilesComponent,
    EditarPerfilesComponent,
    EliminarPerfilesComponent,
    CodigoPerfilOcupadoValidatorDirective
  ],
  providers: [
    HttpClient
  ]
})
export class PerfilesModule {}
