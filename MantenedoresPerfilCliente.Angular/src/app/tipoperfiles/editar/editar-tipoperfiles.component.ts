import { TipoPerfilDto } from '../../shared/models/tipo-perfil-dto';

import { Router, ActivatedRoute } from '@angular/router';
import { FiltrosService } from '../../shared/services/filtros.service';
import { Component, OnInit, Optional } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { NgxSpinnerService } from 'ngx-spinner';
import { TipoPerfilesService } from '../../shared/services/tipo-perfiles.service';

@Component({
  selector: 'app-editar-tipoperfiles',
  templateUrl: './editar-tipoperfiles.component.html',
  styleUrls: ['./editar-tipoperfiles.component.css']
})
export class EditarTipoPerfilesComponent implements OnInit {
  public data: TipoPerfilDto;
  private edit: boolean;
  public tipoPerfilesForm: FormGroup;

  constructor(
    private fb: FormBuilder,
    private svc: TipoPerfilesService,
    private router: Router,
    private spinner: NgxSpinnerService,
    private route: ActivatedRoute
  ) {
    this.data = new TipoPerfilDto();

    this.tipoPerfilesForm = this.fb.group({
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
    this.data.cod = this.tipoPerfilesForm.controls['codigo'].value;
    this.data.descripcion = this.tipoPerfilesForm.controls['descripcion'].value;

  }

  parseData() {
    this.tipoPerfilesForm.controls['codigo'].setValue(this.data.cod);
    this.tipoPerfilesForm.controls['descripcion'].setValue(this.data.descripcion);
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
    return this.tipoPerfilesForm.get('codigo');
  }

  get descripcion() {
    return this.tipoPerfilesForm.get('descripcion');
  }

  onSubmit() {
    this.spinner.show();
    this.parseForm();
    if (this.edit) {
      this.svc.edit(this.data).subscribe(
        res => {
          console.log(res);
          this.router.navigateByUrl('/tipoperfiles');
        },
        error => console.warn(error),
        () => this.spinner.hide()
      );
    } else {
      this.svc.add(this.data).subscribe(
        res => {
          console.log(res);
          this.router.navigateByUrl('/tipoperfiles');
        },
        error => console.warn(error),
        () => this.spinner.hide()
      );
    }
  }
}
