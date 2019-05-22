import { UsuariosService } from '../../shared/services/usuarios.service';
import { PerfilesService } from '../../shared/services/perfiles.service';
import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { PerfilDto } from '../../shared/models/perfil-dto';
import { NgxSpinnerService } from 'ngx-spinner';

import { identity } from 'rxjs';

@Component({
  selector: 'app-detalle-perfiles',
  templateUrl: './detalle-perfiles.component.html',
  styleUrls: ['./detalle-perfiles.component.css']
})
export class DetallePerfilesComponent implements OnInit {
  public perfil: PerfilDto = {
    id: 0,
    codigo: 1,
    descripcion: '',
    piMax: 1,
    estadoPerfilId: 1,
    estadoPerfilDescripcion: '',
    tipoPerfilId: 1,
    tipoPerfilDescripcion: ''
  };

  private sub;
  constructor(
    private svc: PerfilesService,
    private route: ActivatedRoute,
    private spinner: NgxSpinnerService
    , private usersSVC: UsuariosService
  ) {}

  ngOnInit() {
    this.sub = this.route.params.subscribe(params => {
      const id: string = params['id'];
      this.spinner.show();
      this.svc.getPerfil(Number(id)).subscribe(
        res => {
          this.perfil = res as PerfilDto;
          console.log(res);
          this.spinner.hide();
        },
        error => {
          console.log(error);
          this.spinner.hide();
        }
      );
    });
  }
}
