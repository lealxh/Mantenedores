import { UsuariosService } from './shared/services/usuarios.service';
import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  template: `
  <div class="navbar navbar-inverse navbar-fixed-top">
  <div class="container">
    <div class="navbar-header">
      <button type="button" class="navbar-toggle" data-toggle="collapse" data-target=".navbar-collapse">
        <span class="icon-bar"></span>
        <span class="icon-bar"></span>
        <span class="icon-bar"></span>
      </button>
      <a class="navbar-brand"  [routerLink] = "['/']">Mantenedores de Perfiles</a>
    </div>
    <div class="navbar-collapse collapse">
      <ul class="nav navbar-nav">
        <li><a [routerLink] = "['perfiles']">Perfiles</a></li>
        <li><a [routerLink] = "['filtros']" >Filtros</a></li>
        <li><a [routerLink]="['exclusiones']">Exclusiones</a></li>
        <li class="dropdown">
          <a class="dropdown-toggle" data-toggle="dropdown">Parametros
            <span class="caret"></span></a>
          <ul class="dropdown-menu">
            <li><a  [routerLink] ="['tipoperfiles']">Tipo Perfiles</a></li>
            <li><a  [routerLink] ="['estadoperfiles']">Estado Perfiles</a></li>
            <li><a  [routerLink] ="['universos']">Universos</a></li>
            <li><a  [routerLink] ="['estadofiltros']">Estado Filtros</a></li>
            <li><a  [routerLink] ="['motivosbloqueo']">Motivos Bloqueo</a></li>
            <li><a  [routerLink] ="['areas']">Areas</a></li>
            <li><a  [routerLink] ="['cargos']">Cargos</a></li>
          </ul>
        </li>
        <li><a href="#" (click)='logout()'>Logout</a> </li>

      </ul>
    </div>
  </div>
</div>
<div class="container body-content">
  <router-outlet></router-outlet>

  <hr/>
  <footer>
    <p>© 2018- My Angular 6 Application</p>
  </footer>
</div>


`
})
export class AppComponent {

  /**
   *
   */
  constructor(private svc: UsuariosService) {


  }
  logout() {
    this.svc.logout();
  }
}
