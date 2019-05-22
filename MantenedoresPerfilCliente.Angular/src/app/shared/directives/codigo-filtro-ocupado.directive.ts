import { FiltrosService } from './../services/filtros.service';
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
export class CodigoFiltroOcupadoValidator implements AsyncValidator {
  constructor(private svc: FiltrosService) {}

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
  selector: '[appCodigoFiltroOcupadoValidator]',
  providers: [
    {
      provide: NG_ASYNC_VALIDATORS,
      useExisting: forwardRef(() => CodigoFiltroOcupadoValidator),
      multi: true
    }
  ]
})
export class CodigoFiltroOcupadoValidatorDirective {
  constructor(private validator: CodigoFiltroOcupadoValidator) {}

  validate(control: AbstractControl) {
    this.validator.validate(control);
  }
}
