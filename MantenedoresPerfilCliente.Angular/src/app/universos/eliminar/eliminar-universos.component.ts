import { UniversoDto } from '../../shared/models/universo-dto';
import { UniversosService } from '../../shared/services/universos.service';

import { NgxSpinnerService } from 'ngx-spinner';
import { Component, OnInit, OnDestroy } from '@angular/core';
import { Router, ActivatedRoute, ParamMap } from '@angular/router';

@Component({ selector: 'app-eliminar-universos',
  templateUrl: './eliminar-universos.component.html',
  styleUrls: ['./eliminar-universos.component.css']
})

export class EliminarUniversosComponent implements OnInit, OnDestroy {
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
      this.svc
        .getSingle(Number(id))
        .subscribe(
          res => (this.universo = res),
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
    this.svc.remove(this.universo.id).subscribe(
      res => {
        this.router.navigateByUrl('/universos');
      },
      error => console.warn(error),
      () => this.spinner.hide()
    );
  }


}
