import { PerfilesService } from '../../shared/services/perfiles.service';
import { Component, OnInit } from '@angular/core';
import { PerfilDto } from '../../shared/models/perfil-dto';
import { NgxSpinnerService } from 'ngx-spinner';

@Component({
  selector: 'app-lista-perfiles',
  templateUrl: './lista-perfiles.component.html',
  styleUrls: ['./lista-perfiles.component.css']
})
export class ListaPerfilesComponent implements OnInit {
  public perfiles: PerfilDto[];

  constructor(private svc: PerfilesService, private spinner: NgxSpinnerService) {}

  ngOnInit() {
    this.spinner.show();
    this.svc.PerfilesLoad(true).subscribe(
      result => {
        this.perfiles = result.perfiles;
        this.spinner.hide();
      },
      error => {
        console.log(error);
        this.spinner.hide();
      }
    );
  }
}
