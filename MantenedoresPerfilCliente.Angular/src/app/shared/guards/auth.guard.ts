
import { Observable, of, observable } from 'rxjs';
import { NgxSpinnerService } from 'ngx-spinner';
import { ResponsePUT } from './../models/responsePUT';
import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, Router } from '@angular/router';
import { UsuariosService } from '../services/usuarios.service';

@Injectable()
export class AuthGuard implements CanActivate {

  private resp: ResponsePUT;
  private validSession: boolean;
  constructor(private usuariosSVC: UsuariosService,
    private router: Router,
    private spinner: NgxSpinnerService) { }

  canActivate(next: ActivatedRouteSnapshot, state: RouterStateSnapshot): Observable<boolean> | Promise<boolean> | boolean {

    /*if (token) {
      this.usuariosSVC.refrescarToken(token).subscribe(
        res => {
          this.resp = res;
          const tokn = res.payload.jwt;
          window.sessionStorage.setItem('token', tokn);
          if (this.resp.codigo === 200) {

            this.validSession = true;
          }
          console.log(res);
        },
        error => console.log(error),
        () => this.spinner.hide()
      );
    }*/
    const token = window.sessionStorage.getItem('token');
    if (!token) {
      this.router.navigate(['/login'], { queryParams: {return: state.url}});
      return false;
    }
    return true;
   }
}
