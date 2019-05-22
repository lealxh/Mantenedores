import { EliminarTipoPerfilesComponent } from './eliminar/eliminar-tipoperfiles.component';
import { DetalleTipoPerfilesComponent } from './detalle/detalle-tipoperfiles.component';
import { EditarTipoPerfilesComponent } from './editar/editar-tipoperfiles.component';
import { TipoPerfilesService } from '../shared/services/tipo-perfiles.service';
import { ListaTipoPerfilesComponent } from './listar/lista-tipoperfiles.component';
import { NgxSpinnerModule } from 'ngx-spinner';
import { TipoPerfilesRoutingModule } from './tipoperfiles-routing.module';
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
   TipoPerfilesRoutingModule,
    NgxSpinnerModule
  ],
  declarations: [
    ListaTipoPerfilesComponent,
    EditarTipoPerfilesComponent,
    EliminarTipoPerfilesComponent,
    DetalleTipoPerfilesComponent
],
  providers: [HttpClient, TipoPerfilesService]
})
export class TipoPerfilesModule {}
