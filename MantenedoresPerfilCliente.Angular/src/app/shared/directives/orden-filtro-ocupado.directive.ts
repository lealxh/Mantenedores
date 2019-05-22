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
export class OrdenFiltroOcupadoValidator implements AsyncValidator {
  constructor(private svc: FiltrosService) {}

  validate(
    ctrl: AbstractControl
  ): Promise<ValidationErrors | null> | Observable<ValidationErrors | null> {
    return this.svc.esOrdenOcupado(ctrl.value).pipe(
      map(estaOcupado => (estaOcupado ? { OrdenFiltroOcupado: true } : null)),
      catchError(() => null)
    );
  }
}

@Directive({
  selector: '[appOrdenFiltroOcupadoValidator]',
  providers: [
    {
      provide: NG_ASYNC_VALIDATORS,
      useExisting: forwardRef(() => OrdenFiltroOcupadoValidator),
      multi: true
    }
  ]
})
export class OrdenFiltroOcupadoValidatorDirective {
  constructor(private validator: OrdenFiltroOcupadoValidator) {}

  validate(control: AbstractControl) {
    this.validator.validate(control);
  }
}
