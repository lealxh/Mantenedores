import { EstadoPerfilesService } from '../../shared/services/estado-perfiles.service';
import { EstadoPerfiles } from '../../shared/models/estado-perfiles';

import { Router, ActivatedRoute } from '@angular/router';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { NgxSpinnerService } from 'ngx-spinner';

@Component({
  selector: 'app-editar-estadoperfiles',
  templateUrl: './editar-estadoperfiles.component.html',
  styleUrls: ['./editar-estadoperfiles.component.css']
})
export class EditarEstadoPerfilesComponent implements OnInit {
  public data: EstadoPerfiles;
  private edit: boolean;
  public estadoPerfilesForm: FormGroup;

  constructor(
    private fb: FormBuilder,
    private svc: EstadoPerfilesService,
    private router: Router,
    private spinner: NgxSpinnerService,
    private route: ActivatedRoute
  ) {
    this.data = new EstadoPerfiles();

    this.estadoPerfilesForm = this.fb.group({
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
    this.data.cod = this.estadoPerfilesForm.controls['codigo'].value;
    this.data.descripcion = this.estadoPerfilesForm.controls['descripcion'].value;

  }

  parseData() {
    this.estadoPerfilesForm.controls['codigo'].setValue(this.data.cod);
    this.estadoPerfilesForm.controls['descripcion'].setValue(this.data.descripcion);
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
    return this.estadoPerfilesForm.get('codigo');
  }

  get descripcion() {
    return this.estadoPerfilesForm.get('descripcion');
  }

  onSubmit() {
    this.spinner.show();
    this.parseForm();
    if (this.edit) {
      this.svc.edit(this.data).subscribe(
        res => {
          console.log(res);
          this.router.navigateByUrl('/estadoperfiles');
        },
        error => console.warn(error),
        () => this.spinner.hide()
      );
    } else {
      this.svc.add(this.data).subscribe(
        res => {
          console.log(res);
          this.router.navigateByUrl('/estadoperfiles');
        },
        error => console.warn(error),
        () => this.spinner.hide()
      );
    }
  }
}
