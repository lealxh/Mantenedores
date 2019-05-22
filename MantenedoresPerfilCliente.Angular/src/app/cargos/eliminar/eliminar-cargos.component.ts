import { CargoDto } from './../../shared/models/cargo-dto';
import { CargosService } from '../../shared/services/cargos.service';

import { NgxSpinnerService } from 'ngx-spinner';
import { Component, OnInit, OnDestroy } from '@angular/core';
import { Router, ActivatedRoute, ParamMap } from '@angular/router';

@Component({

  selector: 'app-eliminar-cargos',
  templateUrl: './eliminar-cargos.component.html',
  styleUrls: ['./eliminar-cargos.component.css']
})

export class EliminarCargosComponent implements OnInit, OnDestroy {
  public cargo: CargoDto;

  constructor(
    private svc: CargosService,
    private route: ActivatedRoute,
    private router: Router,
    private spinner: NgxSpinnerService
  ) {
    this.cargo = new CargoDto();
  }

  private sub;
  ngOnInit() {
    this.sub = this.route.params.subscribe(params => {
      const id: string = params['id'];
      this.spinner.show();
      this.svc
        .getSingle(Number(id))
        .subscribe(
          res => (this.cargo = res),
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
    this.svc.remove(this.cargo.id).subscribe(
      res => {
        this.router.navigateByUrl('/cargos');
      },
      error => console.warn(error),
      () => this.spinner.hide()
    );
  }


}
