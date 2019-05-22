import { map } from 'rxjs/operators';
import { environment } from '../../../environments/environment';
import { Observable, of } from 'rxjs';
import { TipoPerfilDto } from '../models/tipo-perfil-dto';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class TipoPerfilesService {
  private Url: string;
  private TipoPerfilDto: TipoPerfilDto[];
  private dataLoaded: boolean;

  getHttpOptions() {
    const token = window.sessionStorage.getItem('token');
    return {
      headers: new HttpHeaders({ 'Authorization': 'Bearer ' + token })
    };
  }
  constructor(private http: HttpClient) {
    this.Url = `${environment.bffUrl}/api/TipoPerfilesBFF`;
  }
  replaceData(TipoPerfil: TipoPerfilDto) {
    for (let index = 0; index < this.TipoPerfilDto.length; index++) {
      if (this.TipoPerfilDto[index].id === TipoPerfil.id) {
         this.TipoPerfilDto[index] = TipoPerfil;
      }
    }
   }
   saveData(resp: TipoPerfilDto[]) {

     this.TipoPerfilDto = resp;
     this.dataLoaded = true;
     return resp;
   }

   getAll(): Observable<TipoPerfilDto[]> {
     console.log('Data Loaded? ' + this.dataLoaded);
     if (!this.dataLoaded) {
       return this.http.get<TipoPerfilDto[]>(this.Url, this.getHttpOptions())
         .pipe(map((resp) => this.saveData(resp)));
     } else {
       return of(this.TipoPerfilDto);
     }
   }

   getSingle(id: number): Observable<TipoPerfilDto> {
     if (!this.dataLoaded) {
       this.getAll();
     }
     const resp: TipoPerfilDto = this.TipoPerfilDto.find(x => x.id === id);
     return of(resp);
   }

   add(TipoPerfil: TipoPerfilDto): Observable<TipoPerfilDto> {
     this.dataLoaded = false;
     return this.http.post<TipoPerfilDto>(this.Url, TipoPerfil, this.getHttpOptions());
   }
   removeData(id: number) {
     this.TipoPerfilDto.splice(this.TipoPerfilDto.indexOf(this.TipoPerfilDto.find(x => x.id === id)), 1);
   }
   remove(id: number) {
     const url = `${this.Url}/${id}`;
     return this.http.delete(url, this.getHttpOptions())
       .pipe(map((resp) => {
         console.log(resp);
         this.removeData(id);
       }));
   }

   edit(TipoPerfil: TipoPerfilDto) {
     return this.http.put(this.Url, TipoPerfil, this.getHttpOptions())
       .pipe(map((resp) => this.replaceData(TipoPerfil)));
   }
}
