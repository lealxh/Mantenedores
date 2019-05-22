import { EstadoFiltroDto } from './../../shared/models/estado-filtro-dto';
import { EstadoFiltrosService } from '../../shared/services/estado-filtros.service';
import { NgxSpinnerService } from 'ngx-spinner';
import { Component, OnInit, OnDestroy } from '@angular/core';
import { Router, ActivatedRoute, ParamMap } from '@angular/router';

@Component({ selector: 'app-eliminar-estadofiltros',
  templateUrl: './eliminar-estadofiltros.component.html',
  styleUrls: ['./eliminar-estadofiltros.component.css']
})

export class EliminarEstadoFiltrosComponent implements OnInit, OnDestroy {
  public estadofiltro: EstadoFiltroDto;

  constructor(
    private svc: EstadoFiltrosService,
    private route: ActivatedRoute,
    private router: Router,
    private spinner: NgxSpinnerService
  ) {
    this.estadofiltro = new EstadoFiltroDto();
  }

  private sub;
  ngOnInit() {
    this.sub = this.route.params.subscribe(params => {
      const id: string = params['id'];
      this.spinner.show();
      this.svc
        .getSingle(Number(id))
        .subscribe(
          res => (this.estadofiltro = res),
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
    this.svc.remove(this.estadofiltro.id).subscribe(
      res => {
        this.router.navigateByUrl('/estadofiltros');
      },
      error => console.warn(error),
      () => this.spinner.hide()
    );
  }
}
