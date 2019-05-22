import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { PageNotFoundComponent } from './not-found.component';
import { LoginComponent } from './login/login.component';

const appRoutes: Routes = [
  { path: '', component: LoginComponent },
  { path: 'login', component: LoginComponent },
  {
    path: 'perfiles',
    loadChildren: './perfiles/perfiles.module#PerfilesModule'
  },
  {
    path: 'filtros',
    loadChildren: './filtros/filtros.module#FiltrosModule'
  },
  {
    path: 'exclusiones',
    loadChildren: './exclusiones/exclusiones.module#ExclusionesModule'
  },
  { path: '**', component: PageNotFoundComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(appRoutes)],
  exports: [RouterModule],
  providers: []
})
export class AppRoutingModule {}
