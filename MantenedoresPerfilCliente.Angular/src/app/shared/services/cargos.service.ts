import { element } from 'protractor';
import { CargoDto } from './../models/cargo-dto';
import { CargosModule } from './../../cargos/cargos.module';
import { map } from 'rxjs/operators';

import { environment } from '../../../environments/environment';
import { Observable, of } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class CargosService {
  private Url: string;
  private cargos: CargoDto[];
  private dataLoaded: boolean;

  getHttpOptions() {
    const token = window.sessionStorage.getItem('token');
    return {
      headers: new HttpHeaders({ 'Authorization': 'Bearer ' + token })
    };
  }


  constructor(private http: HttpClient) {
    this.dataLoaded = false;
    this.Url = `${environment.bffUrl}/api/CargosBFF`;
  }
  replaceData(cargo: CargoDto) {
   for (let index = 0; index < this.cargos.length; index++) {
     if (this.cargos[index].id === cargo.id) {
        this.cargos[index] = cargo;
     }
   }
  }
  saveData(resp: CargoDto[]) {

    this.cargos = resp;
    this.dataLoaded = true;
    return resp;
  }

  getAll(): Observable<CargoDto[]> {
    console.log('Data Loaded? ' + this.dataLoaded);
    if (!this.dataLoaded) {
      return this.http.get<CargoDto[]>(this.Url, this.getHttpOptions())
        .pipe(map((resp) => this.saveData(resp)));
    } else {
      return of(this.cargos);
    }
  }

  getSingle(id: number): Observable<CargoDto> {
    if (!this.dataLoaded) {
      this.getAll();
    }
    const resp: CargoDto = this.cargos.find(x => x.id === id);
    return of(resp);
  }

  add(cargo: CargoDto): Observable<CargoDto> {
    this.dataLoaded = false;
    return this.http.post<CargoDto>(this.Url, cargo, this.getHttpOptions());
  }
  removeData(id: number) {
    this.cargos.splice(this.cargos.indexOf(this.cargos.find(x => x.id === id)), 1);
  }
  remove(id: number) {
    const url = `${this.Url}/${id}`;
    return this.http.delete(url, this.getHttpOptions())
      .pipe(map((resp) => {
        console.log(resp);
        this.removeData(id);
      }));
  }

  edit(cargo: CargoDto) {
    return this.http.put(this.Url, cargo, this.getHttpOptions())
      .pipe(map((resp) => this.replaceData(cargo)));
  }
}

