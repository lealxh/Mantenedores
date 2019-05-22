import { EstadoPerfiles } from './../../shared/models/estado-perfiles';
import { PerfilDto } from './../../shared/models/perfil-dto';
import { TipoPerfilDto } from '../../shared/models/tipo-perfil-dto';

import { CodigoPerfilOcupadoValidator } from '../../shared/directives/codigo-perfil-ocupado.directive';
import { PerfilesService } from '../../shared/services/perfiles.service';
import { Router, ActivatedRoute } from '@angular/router';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { Validators } from '@angular/forms';
import { NgxSpinnerService } from 'ngx-spinner';
import { PerfilesEditarDto } from '../../shared/models/perfiles-editar-dto';

@Component({
  selector: 'app-editar-perfiles',
  templateUrl: './editar-perfiles.component.html',
  styleUrls: ['./editar-perfiles.component.css']
})
export class EditarPerfilesComponent implements OnInit {
  public perfil: PerfilDto;
  public estadosPerfil: EstadoPerfiles[];
  public tiposPerfil: TipoPerfilDto[];
  public perfilform: FormGroup;
  private edit: boolean;

  constructor(
    private fb: FormBuilder,
    private svc: PerfilesService,
    private router: Router,
    private route: ActivatedRoute,
    private spinner: NgxSpinnerService,
    private codigoValidator: CodigoPerfilOcupadoValidator
  ) {

    this.perfilform = this.fb.group({
      codigo: [
        '',
        [
          Validators.required,
          Validators.pattern('[0-9]+'),
          Validators.min(1),
          Validators.maxLength(9)
        ],
       [this.codigoValidator.validate.bind(this.codigoValidator)],
        { updateOn: 'blur' }
      ],
      descripcion: ['', [Validators.maxLength(3), Validators.required]],
      piMax: ['', [Validators.min(1), Validators.maxLength(5), Validators.pattern('^[0-9]+(.[0-9]{1,2})?$')]],
      estadoPerfilId: ['', Validators.required],
      tipoPerfilId: ['', Validators.required]
    });
  }
  get codigo() {
    return this.perfilform.get('codigo');
  }
  get descripcion() {
    return this.perfilform.get('descripcion');
  }
  get piMax() {
    return this.perfilform.get('piMax');
  }
  get estadoPerfilId() {
    return this.perfilform.get('estadoPerfilId');
  }
  get tipoPerfilId() {
    return this.perfilform.get('tipoPerfilId');
  }

  parseData() {
    this.perfilform.controls['codigo'].setValue(this.perfil.codigo);
    this.perfilform.controls['descripcion'].setValue(this.perfil.descripcion);
    this.perfilform.controls['piMax'].setValue(this.perfil.piMax);
    this.perfilform.controls['estadoPerfilId'].setValue(this.perfil.estadoPerfilId);
    this.perfilform.controls['tipoPerfilId'].setValue(this.perfil.tipoPerfilId);
  }
  makeDescription(codigo: any) {
    const desc = 'R' + this.codigo.value;
    console.log(desc);
    this.perfilform.controls['descripcion'].setValue(desc);
  }
  ngOnInit() {
    this.edit = false;
    this.route.params.subscribe(params => {

      const id: string = params['id'];
      this.spinner.show();

      const resp: PerfilesEditarDto = this.svc.EditarPerfilesLoad(Number(id));
      console.log(resp);
       if (resp.perfil) {
              this.perfil = resp.perfil;
              this.parseData();
              this.edit = true;
      }
      this.tiposPerfil = resp.tiposPerfil;
      this.estadosPerfil = resp.estadosPerfil;
      this.spinner.hide();
    });

  }
  parseForm() {
    if (!this.perfil) {
      this.perfil = {
        id: 0,
        codigo: 1,
        descripcion: '',
        piMax: 1,
        estadoPerfilId: 1,
        estadoPerfilDescripcion: '',
        tipoPerfilId: 1,
        tipoPerfilDescripcion: ''
      };
    }

      this.perfil.codigo = this.perfilform.controls['codigo'].value;
      this.perfil.descripcion = this.perfilform.controls['descripcion'].value;
      this.perfil.piMax = this.perfilform.controls['piMax'].value;
      this.perfil.estadoPerfilId = this.perfilform.controls['estadoPerfilId'].value;
      this.perfil.tipoPerfilId = this.perfilform.controls['tipoPerfilId'].value;
  }
  onSubmit() {
    this.perfilform.updateValueAndValidity();
    if (!this.perfilform.valid) {
      console.log('Invalid Form cannot submit!!!');
      return false;
    }
    this.parseForm();

    this.spinner.show();
    if (this.edit) {
      console.log('Im going to Edit!! Watch out!!');

      this.svc.editPerfil(this.perfil).subscribe(
        res => {
          console.log(res);
          this.router.navigateByUrl('/perfiles');
        },
        error => console.error(error),
        () => this.spinner.hide()
      );
    } else {
      this.svc.addPerfil(this.perfil).subscribe(
        res => {
          console.log(res);
          this.router.navigateByUrl('/perfiles');
        },
        error => console.error(error),
        () => this.spinner.hide()
      );
    }
  }
}
