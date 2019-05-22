import { CargosService } from '../../shared/services/cargos.service';
import { CargoDto } from '../../shared/models/cargo-dto';

import { Router, ActivatedRoute } from '@angular/router';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { NgxSpinnerService } from 'ngx-spinner';

@Component({

  selector: 'app-editar-cargos',
  templateUrl: './editar-cargos.component.html',
  styleUrls: ['./editar-cargos.component.css']
})
export class EditarCargosComponent implements OnInit {

  public data: CargoDto;
  private edit: boolean;
  public cargosForm: FormGroup;

  constructor(
    private fb: FormBuilder,
    private svc: CargosService,
    private router: Router,
    private spinner: NgxSpinnerService,
    private route: ActivatedRoute
  ) {
    this.data = new CargoDto();

    this.cargosForm = this.fb.group({
      descripcion: ['',
        [Validators.maxLength(100),
         Validators.required]
      ]
    });
  }

  parseForm() {
    this.data.descripcion = this.cargosForm.controls['descripcion'].value;

  }

  parseData() {
    this.cargosForm.controls['descripcion'].setValue(this.data.descripcion);
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

  get descripcion() {
    return this.cargosForm.get('descripcion');
  }

  onSubmit() {
    this.spinner.show();
    this.parseForm();
    if (this.edit) {
      console.log(this.data);
      this.svc.edit(this.data).subscribe(
        res => {
          console.log(res);
          this.router.navigateByUrl('/cargos');
        },
        error => console.warn(error),
        () => this.spinner.hide()
      );
    } else {
      this.svc.add(this.data).subscribe(
        res => {
          console.log(res);
          this.router.navigateByUrl('/cargos');
        },
        error => console.warn(error),
        () => this.spinner.hide()
      );
    }
  }
}
