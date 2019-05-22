
import { Router } from '@angular/router';
import { ResponsePOST } from './../shared/models/responsePOST';
import { ResponseGET } from './../shared/models/responseGET';
import { Login } from './../shared/models/login';
import { RsaService } from '../shared/services/rsa.service';
import { UsuariosService } from '../shared/services/usuarios.service';
import { FormGroup, Validators, FormBuilder } from '@angular/forms';
import { Payload } from '../shared/models/payload';
import { Component, OnInit } from '@angular/core';
import { NgxSpinnerService } from 'ngx-spinner';
import { environment } from '../../environments/environment';
@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  private responseGET: ResponseGET;
  private responsePOST: ResponsePOST;
  private payload: Payload;
  private login: Login;
  private Key: string;
  public loginForm: FormGroup = this.fb.group(
    {
      usuario: ['', [Validators.required, Validators.minLength(3)]],
      password: ['', [Validators.required, Validators.minLength(3)]]
    },

  );

  constructor(private fb: FormBuilder,
    private usuariosSVC: UsuariosService,
    private rsaSVC: RsaService,
    private spinnerSVC: NgxSpinnerService,
    private router: Router) {

  }


  ngOnInit() {
  }

  processLogin() {
    if (this.responsePOST.codigo === 200) {
      environment.jwt = this.responsePOST.payload.jwt;
      this.router.navigateByUrl('/filtros');
    } else {
      console.log(this.responsePOST);
     }
  }

  encriptAndLogin() {

    this.payload = {
      username: this.usuario.value,
      password: this.password.value
    };
    const localpayload = this.rsaSVC.encriptPayload(this.payload, this.responseGET.payload.publicKey);
    // console.log(localpayload);
    this.login = {
      aplicativo: environment.appName,
      domain: environment.domain,
      keyID: this.responseGET.payload.idKey,
      payloadEnc: localpayload,
    };

    this.usuariosSVC.autenticar(this.login).subscribe(resp => {
      this.responsePOST = resp as ResponsePOST;
      this.processLogin();
      // console.log(resp);

      this.usuariosSVC.getPerfil(this.usuario.value)
          .subscribe(respPerf => { console.log(respPerf); });
    },
    error => (console.log(error))
    );
  }

  onSubmit() {


    this.spinnerSVC.show();
    this.usuariosSVC.getPublicKey().subscribe(res => {
      this.responseGET = res;
      console.log(res);
      if (res.codigo === 200) {
        this.encriptAndLogin();
      }
      this.spinnerSVC.hide();
    },
      error => (
      console.log(error)),
      () => this.spinnerSVC.hide());

  }

  get usuario() {
    return this.loginForm.get('usuario');
  }

  get password() {
    return this.loginForm.get('password');
  }




}
