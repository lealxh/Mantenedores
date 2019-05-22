import { MotivosBloqueoService } from '../../shared/services/motivos-bloqueo.service';
import { MotivoBloqueo } from '../../shared/models/motivo-bloqueo';
import { NgxSpinnerService } from 'ngx-spinner';
import { Component, OnInit, OnDestroy } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-detalle-motivosbloqueo',
  templateUrl: './detalle-motivosbloqueo.component.html',
  styleUrls: ['./detalle-motivosbloqueo.component.css']
})
export class DetalleMotivosBloqueoComponent implements OnInit, OnDestroy {
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
      this.svc.getSingle(Number(id)).subscribe(
        res => {
          this.motivoBloqueo = res;
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
