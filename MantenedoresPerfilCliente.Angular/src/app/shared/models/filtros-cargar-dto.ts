import { UniversoDto } from './universo-dto';
import { PerfilDto } from './perfil-dto';
import { FiltroDto } from './filtro-dto';
import { EstadoFiltroDto } from './estado-filtro-dto';
export class FiltrosCargarDto {

  public filtros: FiltroDto[];
  public universos: UniversoDto[];
  public estados: EstadoFiltroDto[];
  public perfiles: PerfilDto[];

}
