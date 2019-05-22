import { UniversosService } from '../../shared/services/universos.service';
import { UniversoDto } from '../../shared/models/universo-dto';

import { Router, ActivatedRoute } from '@angular/router';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { NgxSpinnerService } from 'ngx-spinner';

@Component({
  selector: 'app-editar-universos',
  templateUrl: './editar-universos.component.html',
  styleUrls: ['./editar-universos.component.css']
})
export class EditarUniversosComponent implements OnInit {

  public data: UniversoDto;
  private edit: boolean;
  public universosForm: FormGroup;

  constructor(
    private fb: FormBuilder,
    private svc: UniversosService,
    private router: Router,
    private spinner: NgxSpinnerService,
    private route: ActivatedRoute
  ) {
    this.data = new UniversoDto();

    this.universosForm = this.fb.group({
      codigo: [
        ' ',
        [
          Validators.required,
          Validators.maxLength(2)
        ]],
      descripcion: ['',
        [Validators.maxLength(100),
         Validators.required]
      ]
    });
  }

  parseForm() {
    this.data.cod = this.universosForm.controls['codigo'].value;
    this.data.descripcion = this.universosForm.controls['descripcion'].value;

  }

  parseData() {
    this.universosForm.controls['codigo'].setValue(this.data.cod);
    this.universosForm.controls['descripcion'].setValue(this.data.descripcion);
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
    return this.universosForm.get('codigo');
  }
  get descripcion() {
    return this.universosForm.get('descripcion');
  }

  onSubmit() {
    this.spinner.show();
    this.parseForm();
    if (this.edit) {
      console.log(this.data);
      this.svc.edit(this.data).subscribe(
        res => {
          console.log(res);
          this.router.navigateByUrl('/universos');
        },
        error => console.warn(error),
        () => this.spinner.hide()
      );
    } else {
      this.svc.add(this.data).subscribe(
        res => {
          console.log(res);
          this.router.navigateByUrl('/universos');
        },
        error => console.warn(error),
        () => this.spinner.hide()
      );
    }
  }
}
