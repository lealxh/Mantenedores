import { EstadoFiltrosService } from '../../shared/services/estado-filtros.service';
import { EstadoFiltroDto } from '../../shared/models/estado-filtro-dto';

import { Router, ActivatedRoute } from '@angular/router';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { NgxSpinnerService } from 'ngx-spinner';

@Component({
  selector: 'app-editar-estadofiltros',
  templateUrl: './editar-estadofiltros.component.html',
  styleUrls: ['./editar-estadofiltros.component.css']
})
export class EditarEstadoFiltrosComponent implements OnInit {
  public data: EstadoFiltroDto;
  private edit: boolean;
  public estadoFiltrosForm: FormGroup;

  constructor(
    private fb: FormBuilder,
    private svc: EstadoFiltrosService,
    private router: Router,
    private spinner: NgxSpinnerService,
    private route: ActivatedRoute
  ) {
    this.data = new EstadoFiltroDto();

    this.estadoFiltrosForm = this.fb.group({
      codigo: [
        ' ',
        [
          Validators.required,
          Validators.maxLength(2)
        ]]
        ,
      descripcion: ['',
        [Validators.maxLength(100),
         Validators.required]
      ]
    });
  }

  parseForm() {
    this.data.cod = this.estadoFiltrosForm.controls['codigo'].value;
    this.data.descripcion = this.estadoFiltrosForm.controls['descripcion'].value;

  }

  parseData() {
    this.estadoFiltrosForm.controls['codigo'].setValue(this.data.cod);
    this.estadoFiltrosForm.controls['descripcion'].setValue(this.data.descripcion);
  }

  ngOnInit() {
    this.route.params.subscribe(params => {
      const id: string = params['id'];
      this.edit = false;
      if (id !== '0') {
        this.edit = true;
        this.svc.getSingle(Number(id)).subscribe(
          res => {
            this.data = res;
            this.parseData();
            this.spinner.hide();
          },
          error => console.log(error),
          () => this.spinner.hide()
        );
      }
    });


  }

  get codigo() {
    return this.estadoFiltrosForm.get('codigo');
  }

  get descripcion() {
    return this.estadoFiltrosForm.get('descripcion');
  }

  onSubmit() {
    this.spinner.show();
    this.parseForm();
    if (this.edit) {
      this.svc.edit(this.data).subscribe(
        res => {
          console.log(res);
          this.router.navigateByUrl('/estadofiltros');
        },
        error => console.warn(error),
        () => this.spinner.hide()
      );
    } else {
      this.svc.add(this.data).subscribe(
        res => {
          console.log(res);
          this.router.navigateByUrl('/estadofiltros');
        },
        error => console.warn(error),
        () => this.spinner.hide()
      );
    }
  }
}
