import { TipoPerfilDto } from '../../shared/models/tipo-perfil-dto';
import { TipoPerfilesService } from '../../shared/services/tipo-perfiles.service';
import { NgxSpinnerService } from 'ngx-spinner';
import { FiltrosService } from '../../shared/services/filtros.service';
import { Component, OnInit, OnDestroy } from '@angular/core';
import { Router, ActivatedRoute, ParamMap } from '@angular/router';

@Component({
  selector: 'app-eliminar-tipoperfiles',
  templateUrl: './eliminar-tipoperfiles.component.html',
  styleUrls: ['./eliminar-tipoperfiles.component.css']
})
export class EliminarTipoPerfilesComponent implements OnInit, OnDestroy {
  public tipoPerfil: TipoPerfilDto;

  constructor(
    private svc: TipoPerfilesService,
    private route: ActivatedRoute,
    private router: Router,
    private spinner: NgxSpinnerService
  ) {
    this.tipoPerfil = new TipoPerfilDto();
  }

  private sub;
  ngOnInit() {
    this.sub = this.route.params.subscribe(params => {
      const id: string = params['id'];
      this.spinner.show();
      this.svc
        .getSingle(Number(id))
        .subscribe(
          res => (this.tipoPerfil = res),
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
    this.svc.remove(this.tipoPerfil.id).subscribe(
      res => {
        this.router.navigateByUrl('/tipoperfiles');
      },
      error => console.warn(error),
      () => this.spinner.hide()
    );
  }
}
