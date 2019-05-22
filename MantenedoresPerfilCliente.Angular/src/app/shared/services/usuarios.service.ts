
import { ResponseGetProfile } from '../models/responseGetProfile';
import { ResponsePUT } from '../models/responsePUT';
import { Login } from '../models/login';
import { ResponseGET } from '../models/responseGET';
import { environment } from '../../../environments/environment';

import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class UsuariosService {

public token: string;
private url: string;
  constructor(private http: HttpClient) {
    this.url = environment.bffUrl + '/api/UsuariosBFF';
  }

  getHttpOptions() {
    const token = window.sessionStorage.getItem('token');
    return {
      headers: new HttpHeaders({ 'Authorization': 'Bearer ' + token })
    };
  }
  getPublicKey(): Observable<ResponseGET> {
    // const reqUrl =  `${environment.authUrl}microservicios/usuario/v1/autenticacionAD`;
    return this.http.get<ResponseGET>(this.url);
  }

  almacenarToken(resp: any) {
    if (resp && resp.codigo === 200) {
      window.sessionStorage.setItem('token', resp.payload.jwt);
      console.log('Token almacenado: ' + resp.payload.jwt);
     }
    return resp;
  }
  autenticar(login: Login) {
   // const reqUrl = `${environment.authUrl}/microservicios/usuario/v1/autenticacionAD/`;

    return this.http.post(this.url, login).
      pipe(map((response) => this.almacenarToken(response)));
  }

  refrescarToken(token: any): Observable<any> {
   // const reqUrl = `${environment.authUrl}/microservicios/usuario/v1/autenticacionAD/`;
    return this.http.put(this.url, token, this.getHttpOptions())
    .pipe(map((response) => this.almacenarToken(response)));
  }

  logout(): void {
    this.token = null;
    window.sessionStorage.removeItem('token');
  }

  getPerfil(login: string): Observable<ResponseGetProfile> {
   // const reqUrl =  `${environment.authUrl}/microservicios/usuario/v1/perfil/${login}`;
    return this.http.get<ResponseGetProfile>(this.url + '/' + login, this.getHttpOptions());
  }
}
