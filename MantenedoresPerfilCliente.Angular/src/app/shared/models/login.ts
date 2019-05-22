/**
 * Microservicios
 * Esta es la documentación de la API de los microservicios de  usuario,
 * monitoreo, en donde dentro de cada uno de los dominios y sus operaciones
 * se disponibiliza de una descripción de su funcionalidad y dependencias que
 * estas utilizan, detallando su uso y motivo de implementación.
 *
 * OpenAPI spec version: 1.0.0
 * Contact: i.salazar.williams@accenture.com
 *
 * NOTE: This class is auto generated by the swagger code generator program.
 * https://github.com/swagger-api/swagger-codegen.git
 * Do not edit the class manually.
 */






/**
 * Estructura básica del payload de request para efectos de Login.
 */

export interface Login {

    /**
     * Payload encriptado con llave pública que contiene user, password e información adicional-
     */

    payloadEnc?: string;


    /**
     * ID de la llave pública para la desencriptación del payload.
     */

    keyID?: string;


    /**
     * Aplicativo que esta realizando sesión para perfilar JWT.
     */

    aplicativo?: string;


    /**
     * Dominio al que pertenece el usuario que esta realizando sesión para perfilar JWT.
     */

    domain?: string;

}

