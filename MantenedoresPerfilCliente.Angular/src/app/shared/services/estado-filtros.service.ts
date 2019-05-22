import { map } from 'rxjs/operators';
import { EstadoFiltroDto } from './../models/estado-filtro-dto';
import { environment } from '../../../environments/environment';
import { Observable, of } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class EstadoFiltrosService {
  private Url: string;
  private EstadoFiltros: EstadoFiltroDto[];
  private dataLoaded: boolean;

  getHttpOptions() {
    const token = window.sessionStorage.getItem('token');
    return {
      headers: new HttpHeaders({ 'Authorization': 'Bearer ' + token })
    };
  }
  constructor(private http: HttpClient) {
    this.Url = `${environment.bffUrl}/api/EstadoFiltrosBFF`;
  }
  replaceData(EstadoFiltro: EstadoFiltroDto) {
    for (let index = 0; index < this.EstadoFiltros.length; index++) {
      if (this.EstadoFiltros[index].id === EstadoFiltro.id) {
         this.EstadoFiltros[index] = EstadoFiltro;
      }
    }
   }
   saveData(resp: EstadoFiltroDto[]) {

     this.EstadoFiltros = resp;
     this.dataLoaded = true;
     return resp;
   }

   getAll(): Observable<EstadoFiltroDto[]> {
     console.log('Data Loaded? ' + this.dataLoaded);
     if (!this.dataLoaded) {
       return this.http.get<EstadoFiltroDto[]>(this.Url, this.getHttpOptions())
         .pipe(map((resp) => this.saveData(resp)));
     } else {
       return of(this.EstadoFiltros);
     }
   }

   getSingle(id: number): Observable<EstadoFiltroDto> {
     if (!this.dataLoaded) {
       this.getAll();
     }
     const resp: EstadoFiltroDto = this.EstadoFiltros.find(x => x.id === id);
     return of(resp);
   }

   add(EstadoFiltro: EstadoFiltroDto): Observable<EstadoFiltroDto> {
     this.dataLoaded = false;
     return this.http.post<EstadoFiltroDto>(this.Url, EstadoFiltro, this.getHttpOptions());
   }
   removeData(id: number) {
     this.EstadoFiltros.splice(this.EstadoFiltros.indexOf(this.EstadoFiltros.find(x => x.id === id)), 1);
   }
   remove(id: number) {
     const url = `${this.Url}/${id}`;
     return this.http.delete(url, this.getHttpOptions())
       .pipe(map((resp) => {
         console.log(resp);
         this.removeData(id);
       }));
   }

   edit(EstadoFiltro: EstadoFiltroDto) {
     return this.http.put(this.Url, EstadoFiltro, this.getHttpOptions())
       .pipe(map((resp) => this.replaceData(EstadoFiltro)));
   }
}
