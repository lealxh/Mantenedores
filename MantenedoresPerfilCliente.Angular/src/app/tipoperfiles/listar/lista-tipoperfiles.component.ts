import { TipoPerfilesService } from '../../shared/services/tipo-perfiles.service';
import { Component, OnInit } from '@angular/core';
import { NgxSpinnerService } from 'ngx-spinner';
import { TipoPerfilDto } from '../../shared/models/tipo-perfil-dto';

@Component({
  selector: 'app-tipoperfiles',
  templateUrl: './lista-tipoperfiles.component.html',
  styleUrls: ['./lista-tipoperfiles.component.css']
})
export class ListaTipoPerfilesComponent implements OnInit {
  public tiposperfiles: TipoPerfilDto[];

  constructor(private svc: TipoPerfilesService, private spinner: NgxSpinnerService) {}

  ngOnInit() {
    this.spinner.show();
    this.svc.getAll().subscribe(
      result => {
        console.log(result);
        this.tiposperfiles = result;
        this.spinner.hide();
      },
      error => console.log(error),
      () => this.spinner.hide()
    );
  }
}
