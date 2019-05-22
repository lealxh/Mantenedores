
/**
 * Estructura básica de respuesta de la operación Get Autenticación.
 */

interface PayloadGet {
  publicKey: string;
  idKey: string;
}
export interface ResponseGET {

    codigo?: number;
    mensaje?: string;
    payload?: PayloadGet;

}


