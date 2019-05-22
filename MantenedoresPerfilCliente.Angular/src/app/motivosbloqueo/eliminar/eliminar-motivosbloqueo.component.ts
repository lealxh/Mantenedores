import { MotivosBloqueoService } from '../../shared/services/motivos-bloqueo.service';
import { MotivoBloqueo } from '../../shared/models/motivo-bloqueo';

import { NgxSpinnerService } from 'ngx-spinner';
import { Component, OnInit, OnDestroy } from '@angular/core';
import { Router, ActivatedRoute, ParamMap } from '@angular/router';

@Component({
  selector: 'app-eliminar-motivosbloqueo',
  templateUrl: './eliminar-motivosbloqueo.component.html',
  styleUrls: ['./eliminar-motivosbloqueo.component.css']
})

export class EliminarMotivosBloqueoComponent implements OnInit, OnDestroy {
  public motivoBloqueo: MotivoBloqueo;

  constructor(
    private svc: MotivosBloqueoService,
    private route: ActivatedRoute,
    private router: Router,
    private spinner: NgxSpinnerService
  ) {
    this.motivoBloqueo = new MotivoBloqueo();
  }

  private sub;
  ngOnInit() {
    this.sub = this.route.params.subscribe(params => {
      const id: string = params['id'];
      this.spinner.show();
      this.svc
        .getSingle(Number(id))
        .subscribe(
          res => (this.motivoBloqueo = res),
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
    this.svc.remove(this.motivoBloqueo.id).subscribe(
      res => {
        this.router.navigateByUrl('/motivosbloqueo');
      },
      error => console.warn(error),
      () => this.spinner.hide()
    );
  }


}
