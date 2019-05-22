import { EstadoFiltroDto } from './../../shared/models/estado-filtro-dto';
import { EstadoFiltrosService } from '../../shared/services/estado-filtros.service';



import { Component, OnInit } from '@angular/core';
import { NgxSpinnerService } from 'ngx-spinner';

@Component({
  selector: 'app-estadofiltros',
  templateUrl: './lista-estadofiltros.component.html',
  styleUrls: ['./lista-estadofiltros.component.css']
})
export class ListaEstadoFiltrosComponent implements OnInit {
  public estadosperfiles: EstadoFiltroDto[];

  constructor(private svc: EstadoFiltrosService, private spinner: NgxSpinnerService) {}

  ngOnInit() {
    this.spinner.show();
    this.svc.getAll().subscribe(
      result => {
        console.log(result);
        this.estadosperfiles = result;
        this.spinner.hide();
      },
      error => console.log(error),
      () => this.spinner.hide()
    );
  }
}
