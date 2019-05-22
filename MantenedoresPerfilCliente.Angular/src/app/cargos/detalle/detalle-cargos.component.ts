import { CargoDto } from '../../shared/models/cargo-dto';
import { CargosService } from '../../shared/services/cargos.service';

import { NgxSpinnerService } from 'ngx-spinner';
import { Component, OnInit, OnDestroy } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';

@Component({

  selector: 'app-detalle-cargos',
  templateUrl: './detalle-cargos.component.html',
  styleUrls: ['./detalle-cargos.component.css']
})
export class DetalleCargosComponent implements OnInit, OnDestroy {
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
      this.svc.getSingle(Number(id)).subscribe(
        res => {
          this.cargo = res;
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
