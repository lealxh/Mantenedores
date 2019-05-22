import { UniversoDto } from '../../shared/models/universo-dto';

import { NgxSpinnerService } from 'ngx-spinner';
import { Component, OnInit, OnDestroy } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { UniversosService } from '../../shared/services/universos.service';

@Component({
  selector: 'app-detalle-universos',
  templateUrl: './detalle-universos.component.html',
  styleUrls: ['./detalle-universos.component.css']
})
export class DetalleUniversosComponent implements OnInit, OnDestroy {
  public universo: UniversoDto;

  constructor(
    private svc: UniversosService,
    private route: ActivatedRoute,
    private router: Router,
    private spinner: NgxSpinnerService
  ) {
    this.universo = new UniversoDto();
  }

  private sub;
  ngOnInit() {
    this.sub = this.route.params.subscribe(params => {
      const id: string = params['id'];
      this.spinner.show();
      this.svc.getSingle(Number(id)).subscribe(
        res => {
          this.universo = res;
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
