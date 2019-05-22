import { FiltroDto } from './../../shared/models/filtro-dto';

import { NgxSpinnerService } from 'ngx-spinner';
import { FiltrosService } from '../../shared/services/filtros.service';
import { Component, OnInit, OnDestroy } from '@angular/core';
import { Router, ActivatedRoute, ParamMap } from '@angular/router';

@Component({
  selector: 'app-eliminar-filtros',
  templateUrl: './eliminar-filtros.component.html',
  styleUrls: ['./eliminar-filtros.component.css']
})
export class EliminarFiltrosComponent implements OnInit, OnDestroy {
  public filtro: FiltroDto;

  constructor(
    private svc: FiltrosService,
    private route: ActivatedRoute,
    private router: Router,
    private spinner: NgxSpinnerService
  ) {
    this.filtro = new FiltroDto();
  }

  private sub;
  ngOnInit() {
    this.sub = this.route.params.subscribe(params => {
      const id: string = params['id'];
      this.spinner.show();
      this.svc
        .getSingle(Number(id))
        .subscribe(
          res => (this.filtro = res),
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
    this.svc.remove(this.filtro.id).subscribe(
      res => {
        this.router.navigateByUrl('/filtros');
      },
      error => console.warn(error),
      () => this.spinner.hide()
    );
  }
}
