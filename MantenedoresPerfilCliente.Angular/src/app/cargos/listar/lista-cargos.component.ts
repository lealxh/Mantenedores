import { CargoDto } from '../../shared/models/cargo-dto';
import { CargosService } from '../../shared/services/cargos.service';
import { Component, OnInit } from '@angular/core';
import { NgxSpinnerService } from 'ngx-spinner';


@Component({
  selector: 'app-cargos',
  templateUrl: './lista-cargos.component.html',
  styleUrls: ['./lista-cargos.component.css']
})
export class ListaCargosComponent implements OnInit {
  public cargos: CargoDto[];

  constructor(private svc: CargosService, private spinner: NgxSpinnerService) {}

  ngOnInit() {
    this.spinner.show();
    this.svc.getAll().subscribe(
      result => {
        console.log(result);
        this.cargos = result;
        this.spinner.hide();
      },
      error => console.log(error),
      () => this.spinner.hide()
    );
  }
}
