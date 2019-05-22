import { Payload } from '../models/payload';
import { ResponseGetProfile } from '../models/responseGetProfile';
import { ResponsePUT } from '../models/responsePUT';
import { Login } from '../models/login';
import { ResponsePOST } from '../models/responsePOST';
import { ResponseGET } from '../models/responseGET';
import { environment } from '../../../environments/environment';
import { Observable } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable, Type } from '@angular/core';

import JSEncrypt from 'jsencrypt';
import { Base64 } from 'js-base64';

@Injectable({
  providedIn: 'root'
})
export class RsaService {
  private encrypt: any;
  private encrypted: any;
  constructor() {
  }

   b64EncodeUnicode(str: any) {
    // first we use encodeURIComponent to get percent-encoded UTF-8,
    // then we convert the percent encodings into raw bytes which
    // can be fed into btoa.
      return btoa(encodeURIComponent(str).replace(/%([0-9A-F]{2})/g,
        // function toSolidBytes(match, p1) {
        (match, p1) => {
          // console.debug('match: ' + match);
          return String.fromCharCode(('0x' + p1) as any);
        }));
    }

   b64DecodeUnicode(str) {
    // Going backwards: from bytestream, to percent-encoding, to original string.
     return decodeURIComponent(
       atob(str).
       split('').
      map(function (c) {
        return '%' + ('00' + c.charCodeAt(0).toString(16)).slice(-2);
      }).join(''));
    }

  encriptPayload(payload: Payload, publickey: string): string {

    this.encrypt = new JSEncrypt();
    this.encrypt.setPublicKey(this.b64DecodeUnicode(publickey));
    this.encrypted = this.encrypt.encrypt(JSON.stringify(payload));
    return this.encrypted;
  }

}
