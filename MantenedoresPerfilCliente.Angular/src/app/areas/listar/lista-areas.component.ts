import { AreasService } from '../../shared/services/areas.service';
import { AreaDto } from '../../shared/models/area-dto';
import { Component, OnInit } from '@angular/core';
import { NgxSpinnerService } from 'ngx-spinner';


@Component({
  selector: 'app-areas',
  templateUrl: './lista-areas.component.html',
  styleUrls: ['./lista-areas.component.css']
})
export class ListaAreasComponent implements OnInit {
  public areas: AreaDto[];

  constructor(private svc: AreasService, private spinner: NgxSpinnerService) {}

  ngOnInit() {
    this.spinner.show();
    this.svc.getAll().subscribe(
      result => {
        console.log(result);
        this.areas = result;
        this.spinner.hide();
      },
      error => console.log(error),
      () => this.spinner.hide()
    );
  }
}
