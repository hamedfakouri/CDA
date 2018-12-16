import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { HttpService  } from '../../core/services/http.service'

import { UserInfo } from '../models/User';


@Injectable()
export class UserService extends HttpService<UserInfo> {
  
  constructor(private httpClient :HttpClient){
       super(httpClient);
       this.endpoint = "/api/users/";
       
  } 
  
}