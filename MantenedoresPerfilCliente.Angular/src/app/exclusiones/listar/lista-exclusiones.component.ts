
import { ExclusionesService } from '../../shared/services/exclusiones.service';
import { ExclusionesDto } from '../../shared/models/exclusiones-dto';
import { Component, OnInit } from '@angular/core';
import { NgxSpinnerService } from 'ngx-spinner';

@Component({
  selector: 'app-lista-filtros',
  templateUrl: './lista-exclusiones.component.html',
  styleUrls: ['./lista-exclusiones.component.css']
})
export class ListaExclusionesComponent implements OnInit {
  public exclusiones: ExclusionesDto[];

  constructor(private svc: ExclusionesService, private spinner: NgxSpinnerService) {}

  ngOnInit() {
    this.spinner.show();
    this.svc.ExclusionesLoad(true).subscribe(
      result => {
        console.log(result);
        this.exclusiones = result.exclusiones;
        this.spinner.hide();
      },
      error => console.log(error),
      () => this.spinner.hide()
    );
  }
}
