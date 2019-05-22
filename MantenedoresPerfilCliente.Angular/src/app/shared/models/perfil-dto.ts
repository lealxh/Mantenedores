export class PerfilDto {
  id: number;
  codigo: number;
  descripcion: string;
  piMax: number;
  estadoPerfilId: number;
  estadoPerfilDescripcion: string;
  tipoPerfilId: number;
  tipoPerfilDescripcion: string;
}

export class PerfilDtoEdit {
  id: number;
  codigo: number;
  descripcion: string;
  piMax: number;
  estadoPerfilId: number;
  tipoPerfilId: number;
}

