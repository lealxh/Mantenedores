import { map } from 'rxjs/operators';
import { environment } from '../../../environments/environment';
import { EstadoPerfiles } from '../models/estado-perfiles';

import { Observable, of } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class EstadoPerfilesService {
  private Url: string;
  private EstadoPerfiles: EstadoPerfiles[];
  private dataLoaded: boolean;

  getHttpOptions() {
    const token = window.sessionStorage.getItem('token');
    return {
      headers: new HttpHeaders({ 'Authorization': 'Bearer ' + token })
    };
  }
  constructor(private http: HttpClient) {
    this.Url = `${environment.bffUrl}/api/EstadoPerfilesBFF`;
  }
  replaceData(EstadoPerfil: EstadoPerfiles) {
    for (let index = 0; index < this.EstadoPerfiles.length; index++) {
      if (this.EstadoPerfiles[index].id === EstadoPerfil.id) {
         this.EstadoPerfiles[index] = EstadoPerfil;
      }
    }
   }
   saveData(resp: EstadoPerfiles[]) {

     this.EstadoPerfiles = resp;
     this.dataLoaded = true;
     return resp;
   }

   getAll(): Observable<EstadoPerfiles[]> {
     console.log('Data Loaded? ' + this.dataLoaded);
     if (!this.dataLoaded) {
       return this.http.get<EstadoPerfiles[]>(this.Url, this.getHttpOptions())
         .pipe(map((resp) => this.saveData(resp)));
     } else {
       return of(this.EstadoPerfiles);
     }
   }

   getSingle(id: number): Observable<EstadoPerfiles> {
     if (!this.dataLoaded) {
       this.getAll();
     }
     const resp: EstadoPerfiles = this.EstadoPerfiles.find(x => x.id === id);
     return of(resp);
   }

   add(EstadoPerfil: EstadoPerfiles): Observable<EstadoPerfiles> {
     this.dataLoaded = false;
     return this.http.post<EstadoPerfiles>(this.Url, EstadoPerfil, this.getHttpOptions());
   }
   removeData(id: number) {
     this.EstadoPerfiles.splice(this.EstadoPerfiles.indexOf(this.EstadoPerfiles.find(x => x.id === id)), 1);
   }
   remove(id: number) {
     const url = `${this.Url}/${id}`;
     return this.http.delete(url, this.getHttpOptions())
       .pipe(map((resp) => {
         console.log(resp);
         this.removeData(id);
       }));
   }

   edit(EstadoPerfil: EstadoPerfiles) {
     return this.http.put(this.Url, EstadoPerfil, this.getHttpOptions())
       .pipe(map((resp) => this.replaceData(EstadoPerfil)));
   }
}
