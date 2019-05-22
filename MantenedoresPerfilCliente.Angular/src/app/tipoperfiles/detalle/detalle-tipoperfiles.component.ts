import { TipoPerfilDto } from '../../shared/models/tipo-perfil-dto';
import { TipoPerfilesService } from '../../shared/services/tipo-perfiles.service';

import { NgxSpinnerService } from 'ngx-spinner';
import { Component, OnInit, OnDestroy } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-detalle-tipoperfiles',
  templateUrl: './detalle-tipoperfiles.component.html',
  styleUrls: ['./detalle-tipoperfiles.component.css']
})
export class DetalleTipoPerfilesComponent implements OnInit, OnDestroy {
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
      this.svc.getSingle(Number(id)).subscribe(
        res => {
          this.tipoPerfil = res;
          console.log(res);
        },
        error => console.log(error),
        () => this.spinner.hide()
      );
    });
  }

  ngOnDestroy() {
    this.sub.unsubscribe();
  }
}
