import { MotivoBloqueo } from './motivo-bloqueo';
import { AreaDto } from './area-dto';
import { CargoDto } from './cargo-dto';
import { ExclusionesDto } from './exclusiones-dto';

export class ExclusionesEditarDto {
  public exclusion: ExclusionesDto;
  public cargos: CargoDto[];
  public areas: AreaDto[];
  public motivos: MotivoBloqueo[];
}
