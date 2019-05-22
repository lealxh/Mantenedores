import { MotivosBloqueoService } from '../../shared/services/motivos-bloqueo.service';
import { MotivoBloqueo } from './../../shared/models/motivo-bloqueo';
import { Component, OnInit } from '@angular/core';
import { NgxSpinnerService } from 'ngx-spinner';


@Component({

  selector: 'app-motivosbloqueo',
  templateUrl: './lista-motivosbloqueo.component.html',
  styleUrls: ['./lista-motivosbloqueo.component.css']
})
export class ListaMotivosBloqueoComponent implements OnInit {
  public motivosbloqueo: MotivoBloqueo[];

  constructor(private svc: MotivosBloqueoService, private spinner: NgxSpinnerService) {}

  ngOnInit() {
    this.spinner.show();
    this.svc.getAll().subscribe(
      result => {
        console.log(result);
        this.motivosbloqueo = result;
        this.spinner.hide();
      },
      error => console.log(error),
      () => this.spinner.hide()
    );
  }
}
