import { EstadoPerfiles } from './estado-perfiles';
import { TipoPerfilDto } from './tipo-perfil-dto';
import { PerfilDto } from './perfil-dto';

export class PerfilesCargarDto {
  perfiles: PerfilDto[];
  tiposPerfil: TipoPerfilDto[];
  estadosPerfil: EstadoPerfiles[];
}
