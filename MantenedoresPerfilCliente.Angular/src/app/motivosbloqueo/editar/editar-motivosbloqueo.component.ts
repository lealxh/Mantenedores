import { MotivosBloqueoService } from '../../shared/services/motivos-bloqueo.service';
import { MotivoBloqueo } from '../../shared/models/motivo-bloqueo';

import { Router, ActivatedRoute } from '@angular/router';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { NgxSpinnerService } from 'ngx-spinner';

@Component({
  selector: 'app-editar-motivosbloqueo',
  templateUrl: './editar-motivosbloqueo.component.html',
  styleUrls: ['./editar-motivosbloqueo.component.css']
})
export class EditarMotivosBloqueoComponent implements OnInit {

  public data: MotivoBloqueo;
  private edit: boolean;
  public motivosBloqueoForm: FormGroup;

  constructor(
    private fb: FormBuilder,
    private svc: MotivosBloqueoService,
    private router: Router,
    private spinner: NgxSpinnerService,
    private route: ActivatedRoute
  ) {
    this.data = new MotivoBloqueo();

    this.motivosBloqueoForm = this.fb.group({
      descripcion: ['',
        [Validators.maxLength(100),
         Validators.required]
      ],
      tipo: ['',
      [Validators.maxLength(100),
       Validators.required]
    ]
    });
  }

  parseForm() {
    this.data.descripcion = this.motivosBloqueoForm.controls['descripcion'].value;
    this.data.tipoBloqueo = this.motivosBloqueoForm.controls['tipo'].value;

  }

  parseData() {
    this.motivosBloqueoForm.controls['descripcion'].setValue(this.data.descripcion);
    this.motivosBloqueoForm.controls['tipo'].setValue(this.data.tipoBloqueo);
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
    return this.motivosBloqueoForm.get('descripcion');
  }
  get tipo() {
    return this.motivosBloqueoForm.get('tipo');
  }
  onSubmit() {
    this.spinner.show();
    this.parseForm();
    if (this.edit) {
      console.log(this.data);
      this.svc.edit(this.data).subscribe(
        res => {
          console.log(res);
          this.router.navigateByUrl('/motivosbloqueo');
        },
        error => console.warn(error),
        () => this.spinner.hide()
      );
    } else {
      this.svc.add(this.data).subscribe(
        res => {
          console.log(res);
          this.router.navigateByUrl('/motivosbloqueo');
        },
        error => console.warn(error),
        () => this.spinner.hide()
      );
    }
  }
}
