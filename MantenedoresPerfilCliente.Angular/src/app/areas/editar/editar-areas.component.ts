import { AreaDto } from './../../shared/models/area-dto';
import { AreasService } from '../../shared/services/areas.service';
import { Router, ActivatedRoute } from '@angular/router';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { NgxSpinnerService } from 'ngx-spinner';

@Component({
  selector: 'app-editar-areas',
  templateUrl: './editar-areas.component.html',
  styleUrls: ['./editar-areas.component.css']
})
export class EditarAreasComponent implements OnInit {

  public data: AreaDto;
  private edit: boolean;
  public areasForm: FormGroup;

  constructor(
    private fb: FormBuilder,
    private svc: AreasService,
    private router: Router,
    private spinner: NgxSpinnerService,
    private route: ActivatedRoute
  ) {
    this.data = new AreaDto();

    this.areasForm = this.fb.group({
      nombre: ['',
        [Validators.maxLength(100),
         Validators.required]
      ]
    });
  }

  parseForm() {
    this.data.nombre = this.areasForm.controls['nombre'].value;

  }

  parseData() {
    this.areasForm.controls['nombre'].setValue(this.data.nombre);
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

  get nombre() {
    return this.areasForm.get('nombre');
  }

  onSubmit() {
    this.spinner.show();
    this.parseForm();
    if (this.edit) {
      console.log(this.data);
      this.svc.edit(this.data).subscribe(
        res => {
          console.log(res);
          this.router.navigateByUrl('/areas');
        },
        error => console.warn(error),
        () => this.spinner.hide()
      );
    } else {
      this.svc.add(this.data).subscribe(
        res => {
          console.log(res);
          this.router.navigateByUrl('/areas');
        },
        error => console.warn(error),
        () => this.spinner.hide()
      );
    }
  }
}
