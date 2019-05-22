import { MotivoBloqueo } from '../models/motivo-bloqueo';
import { PerfilDto } from '../models/perfil-dto';
import { AreaDto } from '../models/area-dto';
import { CargoDto } from '../models/cargo-dto';
import { map } from 'rxjs/operators';
import { ExclusionesCargarDto } from '../models/exclusiones-cargar-dto';
import { ExclusionesEditarDto } from '../models/exclusiones-editar-dto';
import { ExclusionesDto } from '../models/exclusiones-dto';
import { environment } from '../../../environments/environment';

import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { HttpHeaders } from '@angular/common/http';

import { Observable, of, observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ExclusionesService {

  private Url: string;
  public exclusiones: ExclusionesDto[];
  public cargos: CargoDto[];
  public areas: AreaDto[];
  public motivos: MotivoBloqueo[];
  public dataLoaded: boolean;

  constructor(private http: HttpClient) {
    this.Url = `${environment.bffUrl}/api/exclusionesBFF`;
  }
  getHttpOptions() {
    const token = window.sessionStorage.getItem('token');
    return {
      headers: new HttpHeaders({ 'Authorization': 'Bearer ' + token })
    };
  }

  ExclusionesLoad(loadAll: boolean): Observable<ExclusionesCargarDto> {
    if (!this.dataLoaded) {

      return this.http.get<ExclusionesCargarDto>(`${this.Url}/${loadAll}`, this.getHttpOptions()).pipe(map(
        (resp) => {
          this.exclusiones = resp.exclusiones;
          this.areas = resp.areas;
          this.cargos = resp.cargos;
          this.motivos = resp.motivos;
          this.dataLoaded = true;
          return resp;
        }));
    } else {

      return of({
        exclusiones: this.exclusiones,
        cargos: this.cargos,
        areas: this.areas,
        motivos: this.motivos
      });
    }
  }

  EditarExclusionesLoad(id: number): ExclusionesEditarDto {
    if (!this.dataLoaded) {
      this.ExclusionesLoad(true);
    }
    return {
      exclusion: id === 0 ? undefined : this.exclusiones.find(x => x.id === id),
      areas: this.areas,
      cargos: this.cargos,
      motivos: this.motivos
    };
  }
  getSingle(id: number): Observable<ExclusionesDto> {
    if (!this.dataLoaded) {
      this.ExclusionesLoad(true);
    }
    const resp: ExclusionesDto = this.exclusiones.find(x => x.id === id);
    return of(resp);
  }

  add(exclusion: ExclusionesDto) {
    this.dataLoaded = false;
    return this.http.post(this.Url, exclusion, this.getHttpOptions());
  }

  private replaceData(exclusion: ExclusionesDto) {
    for (let index = 0; index < this.exclusiones.length; index++) {
      if (this.exclusiones[index].id === exclusion.id) {
         this.exclusiones[index] = exclusion;
      }
    }
  }

  private removeData(id: number) {
    this.exclusiones.splice(this.exclusiones.indexOf(this.exclusiones.find(x => x.id === id)), 1);
  }

  remove(id: number) {
    const url = `${this.Url}/${id}`;
    return this.http.delete(url, this.getHttpOptions())
      .pipe(map((resp) => {
      console.log(resp);
      this.removeData(id);
    }));
  }

  edit(exclusion: ExclusionesDto) {
    return this.http.put(this.Url, exclusion, this.getHttpOptions())
    .pipe(map((resp) => this.replaceData(exclusion)));
  }
}
