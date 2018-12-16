import { Injectable } from '@angular/core';
import {
  HttpEvent, HttpInterceptor, HttpHandler, HttpRequest, HttpResponse, HttpErrorResponse
} from '@angular/common/http';

import { AuthService } from './auth.service';
import { Observable } from 'rxjs';
import 'rxjs/add/operator/do';



@Injectable()
export class AuthInterceptor implements HttpInterceptor {

  private authToken:string ='-';
  constructor(private auth: AuthService) {}

  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> { {
    // Get the auth token from the service.

    if(this.auth.isLoggedIn()){
      this.authToken = this.auth.getAuthorizationHeaderValue();
    }


      
    //const authToken ='Bearer '+sessionStorage.getItem("accessToken");

    /*
    * The verbose way:
    // Clone the request and replace the original headers with
    // cloned headers, updated with the authorization.
    const authReq = req.clone({
      headers: req.headers.set('Authorization', authToken)
    });
    */
    // Clone the request and set the new header in one step.
    const authReq = req.clone({ setHeaders: { Authorization: this.authToken } });

    // send cloned request with header to the next handler.
    //return next.handle(authReq);

    return next.handle(authReq).do((event: HttpEvent<any>) => {
      if (event instanceof HttpResponse) {

        alert("dastari ok");

          // do stuff with response if you want
      }
  }, (err: any) => {
      if (err instanceof HttpErrorResponse) {
          if (err.status === 401) {
              // redirect to the login route
              // or show a modal

              alert("dastari mahdud");
              //this.auth.collectFailedRequest(request);
          }
      }
  });
  }


  }}



/*
Copyright 2017-2018 Google Inc. All Rights Reserved.
Use of this source code is governed by an MIT-style license that
can be found in the LICENSE file at http://angular.io/license
*/