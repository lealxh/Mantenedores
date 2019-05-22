import { EstadoFiltroDto } from './../models/estado-filtro-dto';
import { PerfilDto } from '../models/perfil-dto';
import { UniversoDto } from '../models/universo-dto';
import { map } from 'rxjs/operators';
import { FiltroDto } from '../models/filtro-dto';
import { FiltrosCargarDto } from '../models/filtros-cargar-dto';
import { environment } from '../../../environments/environment';
import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { HttpHeaders } from '@angular/common/http';

import { Observable, of, observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class FiltrosService {

  private Url: string;
  private filtros: FiltroDto[];
  public universos: UniversoDto[];
  public estados: EstadoFiltroDto[];
  public perfiles: PerfilDto[];

  public dataLoaded: boolean;

  constructor(private http: HttpClient) {
    this.Url = `${environment.bffUrl}/api/filtrosBFF`;
  }

  getHttpOptions() {
    const token = window.sessionStorage.getItem('token');
    return {
      headers: new HttpHeaders({ 'Authorization': 'Bearer ' + token })
    };
  }
  esCodigoOcupado(codigo: number): Observable<boolean> {
    if (!this.dataLoaded) {
      this.filtrosLoad(false);
    }
    return of(this.filtros.find(x => x.codigo === codigo) !== undefined);
    // const url = `${this.Url}/EsCodigoOcupado/${codigo}`;
    // return this.http.get<boolean>(url, this.getHttpOptions());
  }

  esOrdenOcupado(orden: number): Observable<boolean> {
    if (!this.dataLoaded) {
      this.filtrosLoad(false);
    }

    return of(this.filtros.find(x => x.orden === orden) !== undefined);
    // const url = `${this.Url}/EsOrdenOcupado/${orden}`;
    // return this.http.get<boolean>(url, this.getHttpOptions());
  }


  filtrosLoad(loadAll: boolean) {
    if (!this.dataLoaded) {
      return this.http.get<FiltrosCargarDto>(`${this.Url}/${loadAll}`, this.getHttpOptions()).pipe(map(
        (resp) => {
          this.filtros = resp.filtros;
          this.estados = resp.estados;
          this.universos = resp.universos;
          this.perfiles = resp.perfiles;
          this.dataLoaded = true;
          return resp;
      }));
    } else {

      return of({
        filtros: this.filtros,
        universos: this.universos,
        estados: this.estados,
        perfiles: this.perfiles
      });

    }

  }

  editarLoad(id: number) {
    if (!this.dataLoaded) {
      this.filtrosLoad(true);
    }

    return {
      filtro: id === 0 ? undefined : this.filtros.find(x => x.id === id),
      estados: this.estados,
      universos: this.universos,
      perfiles: this.perfiles
    };

  }


  getAll(): Observable<FiltroDto[]> {
    if (!this.dataLoaded) {
      this.filtrosLoad(false);
    }
    return of(this.filtros);
  }

  getSingle(id: number): Observable<FiltroDto> {
    const resp: FiltroDto = this.filtros.find(x => x.id === id);
    return of(resp);
  }

  add(filtro: FiltroDto) {
    this.dataLoaded = false;
    return this.http.post(this.Url, filtro, this.getHttpOptions());
  }

  private replaceData(exclusion: FiltroDto) {
    for (let index = 0; index < this.filtros.length; index++) {
      if (this.filtros[index].id === exclusion.id) {
         this.filtros[index] = exclusion;
      }
    }
  }

  private removeData(id: number) {
    this.filtros.splice(this.filtros.indexOf(this.filtros.find(x => x.id === id)), 1);
  }

  remove(id: number) {
    const url = `${this.Url}/${id}`;
    return this.http.delete(url, this.getHttpOptions())
    .pipe(map((resp) => {
      console.log(resp);
      this.removeData(id);
    }));
  }

  edit(filtro: FiltroDto) {
    return this.http.put(this.Url, filtro, this.getHttpOptions())
    .pipe(map((resp) => this.replaceData(filtro)));
  }
}
