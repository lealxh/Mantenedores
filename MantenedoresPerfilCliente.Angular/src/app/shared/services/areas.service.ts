import { AreaDto } from './../models/area-dto';
import { map } from 'rxjs/operators';
import { environment } from '../../../environments/environment';
import { Observable, of } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class AreasService {
  private Url: string;
  private areas: AreaDto[];
  private dataloaded: boolean;

  getHttpOptions() {
    const token = window.sessionStorage.getItem('token');
    return {
      headers: new HttpHeaders({ 'Authorization': 'Bearer ' + token })
    };
  }

  constructor(private http: HttpClient) {
    this.dataloaded = false;
    this.Url = `${environment.bffUrl}/api/areasBFF`;
  }
  saveData(resp) {
    if (resp instanceof AreaDto) {
      this.areas.push(resp);
    } else {
      this.areas = resp;
    }
    return resp;
  }
  getAll(): Observable<AreaDto[]> {
    return this.http.get<AreaDto[]>(this.Url, this.getHttpOptions())
      .pipe(map((resp) => this.saveData(resp)));
  }


  getSingle(id: number): Observable<AreaDto> {

    if (!this.dataloaded) {
      this.getAll();
    }
    const resp: AreaDto = this.areas.find(x => x.id === id);
    return of(resp);
  }

  add(area: AreaDto) {
    return this.http.post(this.Url, area, this.getHttpOptions())
    .pipe(map((resp) => this.saveData(resp)));
  }

  removeData(id: number) {
    this.areas.splice(this.areas.indexOf(this.areas.find(x => x.id === id)), 1);
  }

  remove(id: number) {
    const url = `${this.Url}/${id}`;
    return this.http.delete(url, this.getHttpOptions())
    .pipe(map((resp) => this.removeData(id)));
  }

  edit(area: AreaDto) {
    return this.http.put(this.Url, area, this.getHttpOptions());
  }
}
