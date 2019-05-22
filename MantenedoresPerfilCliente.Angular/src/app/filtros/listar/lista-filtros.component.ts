import { FiltroDto } from './../../shared/models/filtro-dto';
import { FiltrosService } from '../../shared/services/filtros.service';
import { Component, OnInit } from '@angular/core';
import { NgxSpinnerService } from 'ngx-spinner';

@Component({
  selector: 'app-lista-filtros',
  templateUrl: './lista-filtros.component.html',
  styleUrls: ['./lista-filtros.component.css']
})
export class ListaFiltrosComponent implements OnInit {
  public filtros: FiltroDto[];

  constructor(private svc: FiltrosService, private spinner: NgxSpinnerService) {}

  ngOnInit() {
    this.spinner.show();
    this.svc.filtrosLoad(true).subscribe(
      result => {
        console.log(result);
        this.filtros = result.filtros;
        this.spinner.hide();
      },
      error => console.log(error),
      () => this.spinner.hide()
    );
  }
}
