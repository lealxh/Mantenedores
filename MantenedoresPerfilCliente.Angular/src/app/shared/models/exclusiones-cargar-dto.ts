import { MotivoBloqueo } from './motivo-bloqueo';
import { PerfilDto } from './perfil-dto';
import { AreaDto } from './area-dto';
import { CargoDto } from './cargo-dto';
import { ExclusionesDto } from './exclusiones-dto';
export class ExclusionesCargarDto {

  public exclusiones: ExclusionesDto[];
  public cargos: CargoDto[];
  public areas: AreaDto[];
  public motivos: MotivoBloqueo[];


}
