import { ExclusionesDto } from '../../shared/models/exclusiones-dto';
import { NgxSpinnerService } from 'ngx-spinner';
import { Component, OnInit, OnDestroy } from '@angular/core';
import { Router, ActivatedRoute, ParamMap } from '@angular/router';
import { ExclusionesService } from '../../shared/services/exclusiones.service';

@Component({
  selector: 'app-detalle-exclusiones',
  templateUrl: './detalle-exclusiones.component.html',
  styleUrls: ['./detalle-exclusiones.component.css']
})
export class DetalleExclusionesComponent implements OnInit, OnDestroy {
  public data: ExclusionesDto;

  constructor(
    private svc: ExclusionesService,
    private route: ActivatedRoute,
    private router: Router,
    private spinner: NgxSpinnerService
  ) {
    this.data = new ExclusionesDto();
  }

  private sub;
  ngOnInit() {
    this.sub = this.route.params.subscribe(params => {
      const id: string = params['id'];
      this.spinner.show();
      this.svc.getSingle(Number(id)).subscribe(
        res => {
          this.data = res;
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
