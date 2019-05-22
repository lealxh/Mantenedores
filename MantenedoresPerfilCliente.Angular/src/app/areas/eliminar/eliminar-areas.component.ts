import { AreaDto } from './../../shared/models/area-dto';
import { NgxSpinnerService } from 'ngx-spinner';
import { Component, OnInit, OnDestroy } from '@angular/core';
import { Router, ActivatedRoute, ParamMap } from '@angular/router';
import { AreasService } from '../../shared/services/areas.service';

@Component({ selector: 'app-eliminar-areas',
  templateUrl: './eliminar-areas.component.html',
  styleUrls: ['./eliminar-areas.component.css']
})

export class EliminarAreasComponent implements OnInit, OnDestroy {
  public area: AreaDto;

  constructor(
    private svc: AreasService,
    private route: ActivatedRoute,
    private router: Router,
    private spinner: NgxSpinnerService
  ) {
    this.area = new AreaDto();
  }

  private sub;
  ngOnInit() {
    this.sub = this.route.params.subscribe(params => {
      const id: string = params['id'];
      this.spinner.show();
      this.svc.getSingle(Number(id))
        .subscribe(
          res => (this.area = res),
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
    this.svc.remove(this.area.id).subscribe(
      res => {
        this.router.navigateByUrl('/areas');
      },
      error => console.warn(error),
      () => this.spinner.hide()
    );
  }


}
