import { CargosService } from './shared/services/cargos.service';
import { AuthGuard } from './shared/guards/auth.guard';
import { EstadoPerfilesService } from './shared/services/estado-perfiles.service';
import { TipoPerfilesService } from './shared/services/tipo-perfiles.service';
import { PerfilesService } from './shared/services/perfiles.service';
import { MotivosBloqueoModule } from './motivosbloqueo/motivosbloqueo.module';
import { CargosModule } from './cargos/cargos.module';
import { AreasModule } from './areas/areas.module';
import { EstadoFiltrosModule } from './estadofiltros/estadofiltros.module';
import { TipoPerfilesModule } from './TipoPerfiles/tipoperfiles.module';
import { NgxSpinnerModule } from 'ngx-spinner';
import { ExclusionesModule } from './exclusiones/exclusiones.module';
import { FiltrosModule } from './filtros/filtros.module';
import { PerfilesModule } from './perfiles/perfiles.module';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { Router } from '@angular/router';
import { AppComponent } from './app.component';
import { AppRoutingModule } from './app-routing.module';
import { PageNotFoundComponent } from './not-found.component';
import { LoginComponent } from './login/login.component';
import { UsuariosService } from './shared/services/usuarios.service';
import { EstadoPerfilesModule } from './EstadoPerfiles/estadoperfiles.module';
import { UniversosModule } from './universos/universos.module';

@NgModule({
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    FormsModule,
    ReactiveFormsModule,
    PerfilesModule,
    FiltrosModule,
    ExclusionesModule,
    TipoPerfilesModule,
    EstadoPerfilesModule,
    EstadoFiltrosModule,
    UniversosModule,
    AreasModule,
    CargosModule,
    MotivosBloqueoModule,
    AppRoutingModule,
    NgxSpinnerModule
  ],
  providers: [UsuariosService,
    PerfilesService,
    TipoPerfilesService,
    EstadoPerfilesService,
    AuthGuard,
   CargosService],

  declarations: [AppComponent, PageNotFoundComponent, LoginComponent],
  bootstrap: [AppComponent]
})

export class AppModule {
  constructor(router: Router) {}
}
