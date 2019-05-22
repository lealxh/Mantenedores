import { EstadoPerfilesService } from '../../shared/services/estado-perfiles.service';
import { EstadoPerfiles } from './../../shared/models/estado-perfiles';

import { NgxSpinnerService } from 'ngx-spinner';
import { Component, OnInit, OnDestroy } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-detalle-estadoperfiles',
  templateUrl: './detalle-estadoperfiles.component.html',
  styleUrls: ['./detalle-estadoperfiles.component.css']
})
export class DetalleEstadoPerfilesComponent implements OnInit, OnDestroy {
  public estadoPerfil: EstadoPerfiles;

  constructor(
    private svc: EstadoPerfilesService,
    private route: ActivatedRoute,
    private router: Router,
    private spinner: NgxSpinnerService
  ) {
    this.estadoPerfil = new EstadoPerfiles();
  }

  private sub;
  ngOnInit() {
    this.sub = this.route.params.subscribe(params => {
      const id: string = params['id'];
      this.spinner.show();
      this.svc.getSingle(Number(id)).subscribe(
        res => {
          this.estadoPerfil = res;
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
