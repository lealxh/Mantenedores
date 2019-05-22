import { ExclusionesDto } from './../../shared/models/exclusiones-dto';
import { CargoDto } from './../../shared/models/cargo-dto';
import { RutValidator } from 'ng2-rut';
import { MotivoBloqueo } from '../../shared/models/motivo-bloqueo';
import { MotivosBloqueoService } from '../../shared/services/motivos-bloqueo.service';
import { CargosService } from '../../shared/services/cargos.service';
import { AreasService } from '../../shared/services/areas.service';
import { AreaDto } from '../../shared/models/area-dto';
import { ExclusionesService } from '../../shared/services/exclusiones.service';
import { ExclusionesEditarDto } from '../../shared/models/exclusiones-editar-dto';
import { Router, ActivatedRoute } from '@angular/router';
import { Component, OnInit, Optional } from '@angular/core';
import { FormBuilder, FormGroup, Validators, AbstractControl, FormControl } from '@angular/forms';
import { NgxSpinnerService } from 'ngx-spinner';

@Component({
  selector: 'app-editar-exclusiones',
  templateUrl: './editar-exclusiones.component.html',
  styleUrls: ['./editar-exclusiones.component.css']
})
export class EditarExclusionesComponent implements OnInit {


  private edit: boolean;
  public exclusionForm: FormGroup = this.fb.group(
    {
      rut: [' ', [Validators.required, this.rutValidator]],
      areaId: ['', [Validators.required]],
      cargoId: ['', Validators.required],
      comentario: ['', [Validators.required, Validators.maxLength(255)]],
      fechaInicio: ['', [Validators.required, Validators.pattern('\\d\{4\}\-\[01\]\\d\-\[0\-3\]\\dT\[0\-2\]\\d\:\[0\-5\]\\d')]],
      fechaFin: ['', [Validators.required, Validators.pattern('\\d\{4\}\-\[01\]\\d\-\[0\-3\]\\dT\[0\-2\]\\d\:\[0\-5\]\\d')]],
      motivoBloqueoId: ['', Validators.required]
    },
    { validator: this.ValidadorFechas('fechaInicio', 'fechaFin') }
  );
  public data: ExclusionesDto;
  public areas: AreaDto[] = [];
  public cargos: CargoDto[] = [];
  public motivos: MotivoBloqueo[] = [];

  constructor(
    private fb: FormBuilder,
    private svc: ExclusionesService,
    private svcAreas: AreasService,
    private svcCargos: CargosService,
    private svcMotivos: MotivosBloqueoService,
    private router: Router,
    private spinner: NgxSpinnerService,
    private route: ActivatedRoute,
    private rutValidator: RutValidator) {


  }

  ValidadorFechas(from: string, to: string) {
    return (
      group: FormGroup
    ): {
      [key: string]: any;
    } => {
      if (
        this.exclusionForm &&
        this.exclusionForm.controls[from] &&
        this.exclusionForm.controls[from].value !== '' &&
        this.exclusionForm.controls[to] &&
        this.exclusionForm.controls[to].value !== ''
      ) {
        const f = this.exclusionForm.controls[from];
        const t = this.exclusionForm.controls[to];

        if (f.value >= t.value) {
          return {
            dates: 'La fecha inicial deberia ser menor a la fecha final'
          };
        }
      }
      return {};
    };
  }

  parseForm() {
    if (!this.data) {
      this.data = new ExclusionesDto();
    }

    this.data.rut = this.exclusionForm.controls['rut'].value;
    this.data.areaId = this.exclusionForm.controls['areaId'].value;
    this.data.cargoId = this.exclusionForm.controls['cargoId'].value;
    this.data.comentario = this.exclusionForm.controls['comentario'].value;
    this.data.fechaFin = this.exclusionForm.controls['fechaFin'].value;
    this.data.fechaInicio = this.exclusionForm.controls['fechaInicio'].value;
    this.data.motivoBloqueoId = this.exclusionForm.controls['motivoBloqueoId'].value;
  }
  fixDate(data: any) {
    const test = new Date(data);
    const test2 = test.toISOString();
    const test3 = test2.slice(test2.lastIndexOf(':'));
    const result = test2.replace(test3, '');
    return result;
  }
  parseData() {

    if (!this.data) {
      this.data = new ExclusionesDto();
    }

    this.exclusionForm.controls['rut'].setValue(this.data.rut);
    this.exclusionForm.controls['areaId'].setValue(this.data.areaId);
    this.exclusionForm.controls['cargoId'].setValue(this.data.cargoId);
    this.exclusionForm.controls['comentario'].setValue(this.data.comentario);
    this.exclusionForm.controls['fechaFin'].setValue(this.fixDate(this.data.fechaFin));

    this.exclusionForm.controls['fechaInicio'].setValue(this.fixDate(this.data.fechaInicio));
    this.exclusionForm.controls['motivoBloqueoId'].setValue(this.data.motivoBloqueoId);
  }

  ngOnInit() {
    this.edit = false;
    this.route.params.subscribe(params => {
      const id: string = params['id'];


      const result = this.svc.EditarExclusionesLoad(Number(id));
      this.data = result.exclusion;
      this.areas = result.areas;
      this.cargos = result.cargos;
      this.motivos = result.motivos;
      if (result.exclusion) {
        this.data = result.exclusion;
        this.parseData();
        this.edit = true;
      }


    });

   /* this.spinner.show();
    this.svcAreas
      .getAll()
      .subscribe(res => (this.areas = res), error => console.log(error), () => this.spinner.hide());

    this.spinner.show();
    this.svcCargos
      .getAll()
      .subscribe(
        res => (this.cargos = res),
        error => console.log(error),
        () => this.spinner.hide()
      );

    this.spinner.show();
    this.svcMotivos
      .getAll()
      .subscribe(
        res => (this.motivos = res),
        error => console.log(error),
        () => this.spinner.hide()
      );*/
  }

  onSubmit() {
    this.exclusionForm.updateValueAndValidity();
    if (!this.exclusionForm.valid) {
      return;
    }


      this.spinner.show();
      this.parseForm();
      if (this.edit) {
        this.svc.edit(this.data).subscribe(
          res => {
            console.log(res);
            this.router.navigateByUrl('/exclusiones');
          },
          error => console.warn(error),
          () => this.spinner.hide()
        );
      } else {
        this.svc.add(this.data).subscribe(
          res => {
            console.log(res);
            this.router.navigateByUrl('/exclusiones');
          },
          error => console.warn(error),
          () => this.spinner.hide()
        );
      }


  }

  get rut() {
    return this.exclusionForm.get('rut');
  }

  get areaId() {
    return this.exclusionForm.get('areaId');
  }

  get cargoId() {
    return this.exclusionForm.get('cargoId');
  }

  get comentario() {
    return this.exclusionForm.get('comentario');
  }

  get fechaFin() {
    return this.exclusionForm.get('fechaFin');
  }

  get fechaInicio() {
    return this.exclusionForm.get('fechaInicio');
  }

  get motivoBloqueoId() {
    return this.exclusionForm.get('motivoBloqueoId');
  }
}
