import { NgModule, forwardRef } from '@angular/core';
import { CommonModule } from '@angular/common';

import {AuthService,AuthGuardService,AuthInterceptor,AuthInterceptorProviderService,AuthResolve} from './index'
import { HttpService } from 'src/app/core/services/http.service';
import { UserService } from 'src/app/user/services/user.service';

@NgModule({
  imports: [
    CommonModule
  ],
  declarations: [],
  providers:[HttpService,AuthService,AuthGuardService,AuthInterceptor,AuthInterceptorProviderService,AuthResolve,UserService
  ]
})
export class AuthServiceModule {
  constructor(){
    console.log("------------------------AuthServiceModule-------------")
  }
 }
