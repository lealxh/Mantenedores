import { CargosService } from '../shared/services/cargos.service';
import { DetalleCargosComponent } from './detalle/detalle-cargos.component';
import { EliminarCargosComponent } from './eliminar/eliminar-cargos.component';
import { EditarCargosComponent } from './editar/editar-cargos.component';
import { ListaCargosComponent } from './listar/lista-cargos.component';
import { CargosRoutingModule } from './cargos-routing.module';

import { NgxSpinnerModule } from 'ngx-spinner';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';




@NgModule({
  imports: [
    HttpClientModule,
    HttpModule,
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    CargosRoutingModule,
    NgxSpinnerModule
  ],
  declarations: [
    ListaCargosComponent,
    EditarCargosComponent,
    EliminarCargosComponent,
    DetalleCargosComponent
],
  providers: [HttpClient]
})
export class CargosModule {}
