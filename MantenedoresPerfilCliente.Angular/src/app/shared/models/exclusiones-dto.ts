export class ExclusionesDto {
  id: number;
  rut: String;
  comentario: string;
  areaId: number;
  areDescripcion: string;
  cargoId: number;
  cargoDescripcion: string;
  motivoBloqueoId: number;
  motivoBloqueoDescripcion: string;
  tipoBloqueo: string;
  fechaInicio: Date;
  fechaFin: Date;
}
