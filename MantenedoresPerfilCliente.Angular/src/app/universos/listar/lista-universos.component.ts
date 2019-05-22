
import { UniversoDto } from '../../shared/models/universo-dto';
import { UniversosService } from '../../shared/services/universos.service';
import { Component, OnInit } from '@angular/core';
import { NgxSpinnerService } from 'ngx-spinner';


@Component({
  selector: 'app-universos',
  templateUrl: './lista-universos.component.html',
  styleUrls: ['./lista-universos.component.css']
})
export class ListaUniversosComponent implements OnInit {
  public universos: UniversoDto[];

  constructor(private svc: UniversosService, private spinner: NgxSpinnerService) {}

  ngOnInit() {
    this.spinner.show();
    this.svc.getAll().subscribe(
      result => {
        console.log(result);
        this.universos = result;
        this.spinner.hide();
      },
      error => console.log(error),
      () => this.spinner.hide()
    );
  }
}
