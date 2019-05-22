import { map } from 'rxjs/operators';
import { environment } from '../../../environments/environment';
import { UniversoDto } from '../models/universo-dto';
import { Observable, of } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class UniversosService {
  private Url: string;
  private Universos: UniversoDto[];
  private dataLoaded: boolean;

  getHttpOptions() {
    const token = window.sessionStorage.getItem('token');
    return {
      headers: new HttpHeaders({ 'Authorization': 'Bearer ' + token })
    };
  }


  constructor(private http: HttpClient) {
    this.dataLoaded = false;
    this.Url = `${environment.bffUrl}/api/UniversosBFF`;
  }
  replaceData(universo: UniversoDto) {
   for (let index = 0; index < this.Universos.length; index++) {
     if (this.Universos[index].id === universo.id) {
        this.Universos[index] = universo;
     }
   }
  }
  saveData(resp: UniversoDto[]) {

    this.Universos = resp;
    this.dataLoaded = true;
    return resp;
  }

  getAll(): Observable<UniversoDto[]> {
    console.log('Data Loaded? ' + this.dataLoaded);
    if (!this.dataLoaded) {
      return this.http.get<UniversoDto[]>(this.Url, this.getHttpOptions())
        .pipe(map((resp) => this.saveData(resp)));
    } else {
      return of(this.Universos);
    }
  }

  getSingle(id: number): Observable<UniversoDto> {
    if (!this.dataLoaded) {
      this.getAll();
    }
    const resp: UniversoDto = this.Universos.find(x => x.id === id);
    return of(resp);
  }

  add(universo: UniversoDto): Observable<UniversoDto> {
    this.dataLoaded = false;
    return this.http.post<UniversoDto>(this.Url, universo, this.getHttpOptions());
  }
  removeData(id: number) {
    this.Universos.splice(this.Universos.indexOf(this.Universos.find(x => x.id === id)), 1);
  }
  remove(id: number) {
    const url = `${this.Url}/${id}`;
    return this.http.delete(url, this.getHttpOptions())
      .pipe(map((resp) => {
        console.log(resp);
        this.removeData(id);
      }));
  }

  edit(universo: UniversoDto) {
    return this.http.put(this.Url, universo, this.getHttpOptions())
      .pipe(map((resp) => this.replaceData(universo)));
  }
}
