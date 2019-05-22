import { EstadoPerfilesService } from '../../shared/services/estado-perfiles.service';
import { Component, OnInit } from '@angular/core';
import { NgxSpinnerService } from 'ngx-spinner';
import { EstadoPerfiles } from '../../shared/models/estado-perfiles';

@Component({
  selector: 'app-estadoperfiles',
  templateUrl: './lista-estadoperfiles.component.html',
  styleUrls: ['./lista-estadoperfiles.component.css']
})
export class ListaEstadoPerfilesComponent implements OnInit {
  public estadosperfiles: EstadoPerfiles[];

  constructor(private svc: EstadoPerfilesService, private spinner: NgxSpinnerService) {}

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
