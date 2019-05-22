import { UsuariosService } from '../../shared/services/usuarios.service';
import { NgxSpinnerService } from 'ngx-spinner';
import { PerfilesService } from '../../shared/services/perfiles.service';
import { Component, OnInit, OnDestroy } from '@angular/core';
import { Router, ActivatedRoute, ParamMap } from '@angular/router';
import { PerfilDto } from '../../shared/models/perfil-dto';

@Component({
  selector: 'app-eliminar-perfiles',
  templateUrl: './eliminar-perfiles.component.html',
  styleUrls: ['./eliminar-perfiles.component.css']
})
export class EliminarPerfilesComponent implements OnInit, OnDestroy {
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

  constructor(
    private svc: PerfilesService,
    private route: ActivatedRoute,
    private router: Router,
    private spinner: NgxSpinnerService
    , private usersSVC: UsuariosService
  ) {
    this.perfil = new PerfilDto();
  }

  private sub;
  ngOnInit() {
    this.sub = this.route.params.subscribe(params => {
      const id: string = params['id'];
      this.spinner.show();
      this.svc
        .getPerfil(Number(id))
        .subscribe(
          res => (this.perfil = res as PerfilDto),
          error => console.log(error),
          () => this.spinner.hide()
        );
    });
  }

  ngOnDestroy() {
    this.sub.unsubscribe();
  }

  eliminarClick() {
    this.spinner.show();
    this.svc.removePerfil(this.perfil.id).subscribe(
      res => {
        console.log(res);
        this.router.navigateByUrl('/perfiles');
      },
      error => console.warn(error),
      () => this.spinner.hide()
    );
  }
}
