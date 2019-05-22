import { EstadoPerfiles } from './../../shared/models/estado-perfiles';
import { EstadoPerfilesService } from '../../shared/services/estado-perfiles.service';
import { NgxSpinnerService } from 'ngx-spinner';
import { Component, OnInit, OnDestroy } from '@angular/core';
import { Router, ActivatedRoute, ParamMap } from '@angular/router';

@Component({ selector: 'app-eliminar-estadoperfiles',
  templateUrl: './eliminar-estadoperfiles.component.html',
  styleUrls: ['./eliminar-estadoperfiles.component.css']
})

export class EliminarEstadoPerfilesComponent implements OnInit, OnDestroy {
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
      this.svc
        .getSingle(Number(id))
        .subscribe(
          res => (this.estadoPerfil = res),
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
    this.svc.remove(this.estadoPerfil.id).subscribe(
      res => {
        this.router.navigateByUrl('/estadoperfiles');
      },
      error => console.warn(error),
      () => this.spinner.hide()
    );
  }
}
