import { PerfilesService } from './../services/perfiles.service';
import { Directive, forwardRef, Injectable } from '@angular/core';
import {
  AsyncValidator,
  AbstractControl,
  NG_ASYNC_VALIDATORS,
  ValidationErrors
} from '@angular/forms';
import { catchError, map } from 'rxjs/operators';
import { Observable } from 'rxjs';

@Injectable({ providedIn: 'root' })
export class CodigoPerfilOcupadoValidator implements AsyncValidator {
  constructor(private svc: PerfilesService) {}

  validate(
    ctrl: AbstractControl
  ): Promise<ValidationErrors | null> | Observable<ValidationErrors | null> {
    return this.svc.esCodigoOcupado(ctrl.value).pipe(
      map(estaOcupado => {
        return estaOcupado ? { CodigoFiltroOcupado: true } : null;
      }),
      catchError(() => null)
    );
  }
}

@Directive({
  selector: '[appCodigoPerfilOcupadoValidator]',
  providers: [
    {
      provide: NG_ASYNC_VALIDATORS,
      useExisting: forwardRef(() => CodigoPerfilOcupadoValidator),
      multi: true
    }
  ]
})
export class CodigoPerfilOcupadoValidatorDirective {
  constructor(private validator: CodigoPerfilOcupadoValidator) {}

  validate(control: AbstractControl) {
    this.validator.validate(control);
  }
}
