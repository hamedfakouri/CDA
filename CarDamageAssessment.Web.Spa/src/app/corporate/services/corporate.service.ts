import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { Corporate } from '../models/corporate';
import { HttpService  } from '../../core/services/http.service'


@Injectable()
export class CorporateService extends HttpService<Corporate> {
  
  constructor(private httpClient :HttpClient){
       super(httpClient);
       this.endpoint = "/api/corporates/";
  } 
  
}