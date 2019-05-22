import { map } from 'rxjs/operators';
import { EstadoPerfiles } from '../models/estado-perfiles';
import { TipoPerfilDto } from '../models/tipo-perfil-dto';
import { UsuariosService } from './usuarios.service';
import { PerfilDto, PerfilDtoEdit } from '../models/perfil-dto';
import { PerfilesEditarDto } from '../models/perfiles-editar-dto';

import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { HttpHeaders } from '@angular/common/http';

import { Observable, of } from 'rxjs';
import { environment } from '../../../environments/environment';
import { PerfilesCargarDto } from '../models/perfiles-cargar-dto';


@Injectable({
  providedIn: 'root'
})
export class PerfilesService {

  public perfiles: PerfilDto[];
  public tiposPerfil: TipoPerfilDto[];
  public estadosPerfil: EstadoPerfiles[];
  public dataLoaded: boolean;

  private perfilesUrl: string;
  private Url: string;
  constructor(private http: HttpClient, private usuariosService: UsuariosService) {
    this.Url = `${environment.bffUrl}api/PerfilesBFF`;
    this.dataLoaded = false;
  }

  PerfilesLoad(loadAll: boolean): Observable<PerfilesCargarDto> {
    if (!this.dataLoaded) {

      return this.http.get(`${this.Url}/${loadAll}`, this.getHttpOptions()).pipe(map(
        (response) => {
          const resp = response as PerfilesCargarDto;
          this.perfiles = resp.perfiles;
          this.tiposPerfil = resp.tiposPerfil;
          this.estadosPerfil = resp.estadosPerfil;
          this.dataLoaded = true;
          return resp;
        }));
    } else {
      return of({
        perfiles: this.perfiles,
        tiposPerfil: this.tiposPerfil,
        estadosPerfil: this.estadosPerfil
      });

    }
  }

  EditarPerfilesLoad(id: number): PerfilesEditarDto {
    if (!this.dataLoaded) {
      this.PerfilesLoad(true);
    }
    return {
      perfil: id === 0 ? undefined : this.perfiles.find(x => x.id === id),
      estadosPerfil: this.estadosPerfil,
      tiposPerfil: this.tiposPerfil
    };
  }
  getPerfiles(): Observable<PerfilDto[]> {
    if (!this.dataLoaded) {
      this.PerfilesLoad(false);
    }
    return of(this.perfiles);
  }
  getHttpOptions() {
    const token = window.sessionStorage.getItem('token');
    return {
      headers: new HttpHeaders({ 'Authorization': 'Bearer ' + token })
    };
  }
  getPerfil(id: number): Observable<PerfilDto> {
    if (!this.dataLoaded) {
      this.PerfilesLoad(false);
    }

    const resp: PerfilDto = this.perfiles.find(x => x.id === id);
    return of(resp);
  }
  addPerfil(perfil: PerfilDto) {
    this.dataLoaded = false;
    return this.http.post(this.Url, perfil, this.getHttpOptions());
  }
  esCodigoOcupado(codigop: number) {
    return of(this.perfiles.find(x => x.codigo === codigop) !== undefined);
  }
  private replaceData(exclusion: PerfilDto) {
    for (let index = 0; index < this.perfiles.length; index++) {
      if (this.perfiles[index].id === exclusion.id) {
         this.perfiles[index] = exclusion;
      }
    }
  }

  private removeData(id: number) {
    this.perfiles.splice(this.perfiles.indexOf(this.perfiles.find(x => x.id === id)), 1);
  }

  removePerfil(id: number) {
    return this.http.delete(`${this.Url}/${id}`, this.getHttpOptions())
      .pipe(map((resp) => this.removeData(id)));
  }

  editPerfil(perfil: PerfilDto) {
    return this.http.put(this.Url, perfil, this.getHttpOptions())
    .pipe(map((resp) => this.replaceData(perfil)));
  }
}
