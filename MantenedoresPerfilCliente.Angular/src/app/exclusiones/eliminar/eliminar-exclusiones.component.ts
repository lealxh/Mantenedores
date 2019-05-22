import { ExclusionesService } from '../../shared/services/exclusiones.service';
import { ExclusionesDto } from '../../shared/models/exclusiones-dto';
import { NgxSpinnerService } from 'ngx-spinner';
import { Component, OnInit, OnDestroy } from '@angular/core';
import { Router, ActivatedRoute, ParamMap } from '@angular/router';

@Component({
  selector: 'app-eliminar-exclusiones',
  templateUrl: './eliminar-exclusiones.component.html',
  styleUrls: ['./eliminar-exclusiones.component.css']
})
export class EliminarExclusionesComponent implements OnInit, OnDestroy {
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
      this.svc
        .getSingle(Number(id))
        .subscribe(
          res => (this.data = res),
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
    this.svc.remove(this.data.id).subscribe(
      res => {
        this.router.navigateByUrl('/exclusiones');
      },
      error => console.warn(error),
      () => this.spinner.hide()
    );
  }
}
