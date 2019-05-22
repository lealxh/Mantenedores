/**
 * Estructura básica de respuesta de la operación Post Autenticación.
 */
interface PayLoadPost {
  jwt: string;
}
export interface ResponsePOST {


    codigo?: number;
    mensaje?: string;
    payload?: PayLoadPost;

}


