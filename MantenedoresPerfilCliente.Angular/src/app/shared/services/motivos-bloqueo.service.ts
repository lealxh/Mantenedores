import { map } from 'rxjs/operators';
import { MotivoBloqueo } from '../models/motivo-bloqueo';
import { environment } from '../../../environments/environment';
import { Observable, of } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class MotivosBloqueoService {
  private Url: string;
  private MotivoBloqueos: MotivoBloqueo[];
  private dataLoaded: boolean;

  getHttpOptions() {
    const token = window.sessionStorage.getItem('token');
    return {
      headers: new HttpHeaders({ 'Authorization': 'Bearer ' + token })
    };
  }


  constructor(private http: HttpClient) {
    this.dataLoaded = false;
    this.Url = `${environment.bffUrl}/api/MotivoBloqueosBFF`;
  }
  replaceData(motivobloqueo: MotivoBloqueo) {
   for (let index = 0; index < this.MotivoBloqueos.length; index++) {
     if (this.MotivoBloqueos[index].id === motivobloqueo.id) {
        this.MotivoBloqueos[index] = motivobloqueo;
     }
   }
  }
  saveData(resp: MotivoBloqueo[]) {
    this.MotivoBloqueos = resp;
    this.dataLoaded = true;
    return resp;
  }

  getAll(): Observable<MotivoBloqueo[]> {
    console.log('Data Loaded? ' + this.dataLoaded);
    if (!this.dataLoaded) {
      return this.http.get<MotivoBloqueo[]>(this.Url, this.getHttpOptions())
        .pipe(map((resp) => this.saveData(resp)));
    } else {
      return of(this.MotivoBloqueos);
    }
  }

  getSingle(id: number): Observable<MotivoBloqueo> {
    if (!this.dataLoaded) {
      this.getAll();
    }
    const resp: MotivoBloqueo = this.MotivoBloqueos.find(x => x.id === id);
    return of(resp);
  }

  add(motivobloqueo: MotivoBloqueo): Observable<MotivoBloqueo> {
    this.dataLoaded = false;
    return this.http.post<MotivoBloqueo>(this.Url, motivobloqueo, this.getHttpOptions());
  }
  removeData(id: number) {
    this.MotivoBloqueos.splice(this.MotivoBloqueos.indexOf(this.MotivoBloqueos.find(x => x.id === id)), 1);
  }
  remove(id: number) {
    const url = `${this.Url}/${id}`;
    return this.http.delete(url, this.getHttpOptions())
      .pipe(map((resp) => {
        console.log(resp);
        this.removeData(id);
      }));
  }

  edit(motivobloqueo: MotivoBloqueo) {
    return this.http.put(this.Url, motivobloqueo, this.getHttpOptions())
      .pipe(map((resp) => this.replaceData(motivobloqueo)));
  }

}
