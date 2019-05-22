import { EstadoFiltroDto } from './../../shared/models/estado-filtro-dto';
import { FiltroDto } from './../../shared/models/filtro-dto';
import { CodigoFiltroOcupadoValidator } from '../../shared/directives/codigo-filtro-ocupado.directive';
import { OrdenFiltroOcupadoValidator } from '../../shared/directives/orden-filtro-ocupado.directive';
import { UniversoDto } from '../../shared/models/universo-dto';
import { Router, ActivatedRoute } from '@angular/router';
import { FiltrosService } from '../../shared/services/filtros.service';
import { Component, OnInit, Optional } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { NgxSpinnerService } from 'ngx-spinner';
import { PerfilDto } from '../../shared/models/perfil-dto';

@Component({
  selector: 'app-editar-filtros',
  templateUrl: './editar-filtros.component.html',
  styleUrls: ['./editar-filtros.component.css']
})
export class EditarFiltrosComponent implements OnInit {
  public data: FiltroDto;

  public universos: UniversoDto[] = [];
  public estados: EstadoFiltroDto[] = [];
  public perfiles: PerfilDto[] = [];
  private edit: boolean;
  public filtroForm: FormGroup;

  constructor(
    private fb: FormBuilder,
    private svcFiltros: FiltrosService,
    private router: Router,
    private spinner: NgxSpinnerService,
    private route: ActivatedRoute,
    private ordenValidator: OrdenFiltroOcupadoValidator,
    private codigoValidator: CodigoFiltroOcupadoValidator
  ) {

    this.filtroForm = this.fb.group({
      codigo: [
        ' ',
        [
          Validators.required,
          Validators.pattern('[0-9]+'),
          Validators.min(1),
          Validators.maxLength(9)
        ],
        [this.codigoValidator.validate.bind(this.codigoValidator)],
        { updateOn: 'blur' }
      ],
      descripcion: ['', [Validators.maxLength(100), Validators.required]],
      universoId: ['', Validators.required],
      estadoFiltroId: ['', Validators.required],
      perfilId: ['', Validators.required],
      orden: [
        '',
        [
          Validators.required,
          Validators.pattern('[0-9]+'),
          Validators.min(1),
          Validators.maxLength(9)
        ],
        [this.ordenValidator.validate.bind(this.ordenValidator)],
        { updateOn: 'blur' }
      ],

      corte1: [
        '',
        [
          Validators.min(1),
          Validators.maxLength(9),
          Validators.pattern('[0-9]+'),
          Validators.min(1)
        ]
      ],
      corte2: ['', [Validators.pattern('[0-9]+'), Validators.min(1), Validators.maxLength(9)]],
      monto1: [
        '',
        [Validators.min(1), Validators.maxLength(9), Validators.pattern('^[0-9]+(.[0-9]{1,2})?$')]
      ],
      monto2: [
        '',
        [Validators.min(1), Validators.maxLength(9), Validators.pattern('^[0-9]+(.[0-9]{1,2})?$')]
      ]
    });
  }

  parseForm() {
    if (!this.data) {
      this.data = {
        id: 0,
        codigo: 0,
        descripcion: '',
        universoId: 0,
        universoDescripcion: '',
        estadoFiltroId: 0,
        estadoFiltroDescripcion: '',
        perfilId: 0,
        perfilDescripcion: '',
        orden: undefined,
        corte1: undefined,
        corte2: undefined,
        monto1: undefined,
        monto2: undefined,
      };
    }

    this.data.codigo = this.filtroForm.controls['codigo'].value;
    this.data.descripcion = this.filtroForm.controls['descripcion'].value;
    this.data.universoId = this.filtroForm.controls['universoId'].value;
    this.data.estadoFiltroId = this.filtroForm.controls['estadoFiltroId'].value;
    this.data.perfilId = this.filtroForm.controls['perfilId'].value;
    this.data.orden = this.filtroForm.controls['orden'].value;
    this.data.corte1 = this.filtroForm.controls['corte1'].value;
    this.data.corte2 = this.filtroForm.controls['corte2'].value;
    this.data.monto1 = this.filtroForm.controls['monto1'].value;
    this.data.monto2 = this.filtroForm.controls['monto2'].value;
  }

  parseData() {
    this.filtroForm.controls['codigo'].setValue(this.data.codigo);
    this.filtroForm.controls['descripcion'].setValue(this.data.descripcion);
    this.filtroForm.controls['universoId'].setValue(this.data.universoId);
    this.filtroForm.controls['estadoFiltroId'].setValue(this.data.estadoFiltroId);
    this.filtroForm.controls['perfilId'].setValue(this.data.perfilId);
    this.filtroForm.controls['orden'].setValue(this.data.orden);
    this.filtroForm.controls['corte1'].setValue(this.data.corte1);
    this.filtroForm.controls['corte2'].setValue(this.data.corte2);
    this.filtroForm.controls['monto1'].setValue(this.data.monto1);
    this.filtroForm.controls['monto2'].setValue(this.data.monto2);
  }

  ngOnInit() {

    this.route.params.subscribe(params => {
      const id: string = params['id'];
      this.edit = false;
      const result = this.svcFiltros.editarLoad(Number(id));
      console.log(result);
      if (result.filtro !== undefined) {
        this.data = result.filtro;
        this.parseData();
        this.edit = true;
      }
      this.data = result.filtro;
      this.estados = result.estados;
      this.universos = result.universos;
      this.perfiles = result.perfiles;

    });

   /* this.spinner.show();
    this.svcEstados
      .getEstados()
      .subscribe(
        res => (this.estados = res),
        error => console.log(error),
        () => this.spinner.hide()
      );
    this.spinner.show();
    this.svcUniveros
      .getAll()
      .subscribe(
        res => (this.universos = res),
        error => console.log(error),
        () => this.spinner.hide()
      );
    this.spinner.show();
    this.svcPerfiles
      .getPerfiles()
      .subscribe(
        res => (this.perfiles = res),
        error => console.log(error),
        () => this.spinner.hide()
      );*/
  }

  get codigo() {
    return this.filtroForm.get('codigo');
  }

  get descripcion() {
    return this.filtroForm.get('descripcion');
  }

  get orden() {
    return this.filtroForm.get('orden');
  }
  get universoId() {
    return this.filtroForm.get('universoId');
  }
  get perfilId() {
    return this.filtroForm.get('perfilId');
  }
  get estadoFiltroId() {
    return this.filtroForm.get('estadoFiltroId');
  }

  get corte1() {
    return this.filtroForm.get('corte1');
  }

  get corte2() {
    return this.filtroForm.get('corte2');
  }
  get monto1() {
    return this.filtroForm.get('monto1');
  }
  get monto2() {
    return this.filtroForm.get('monto2');
  }

  onSubmit() {
    this.filtroForm.updateValueAndValidity();
    if (!this.filtroForm.valid) {
      return;
    }

    this.spinner.show();
    console.log(this.data);
    this.parseForm();

    if (this.edit) {
      this.svcFiltros.edit(this.data).subscribe(
        res => {
          console.log(res);
          this.router.navigateByUrl('/filtros');
        },
        error => console.warn(error),
        () => this.spinner.hide()
      );
    } else {
      this.svcFiltros.add(this.data).subscribe(
        res => {
          console.log(res);
          this.router.navigateByUrl('/filtros');
        },
        error => console.warn(error),
        () => this.spinner.hide()
      );
    }
  }
}
