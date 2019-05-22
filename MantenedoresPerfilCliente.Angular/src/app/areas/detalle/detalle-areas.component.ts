
import { AreasService } from '../../shared/services/areas.service';
import { AreaDto } from '../../shared/models/area-dto';
import { NgxSpinnerService } from 'ngx-spinner';
import { Component, OnInit, OnDestroy } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';


@Component({
  selector: 'app-detalle-areas',
  templateUrl: './detalle-areas.component.html',
  styleUrls: ['./detalle-areas.component.css']
})
export class DetalleAreasComponent implements OnInit, OnDestroy {
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
      this.svc.getSingle(Number(id)).subscribe(
        res => {
          this.area = res;
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
