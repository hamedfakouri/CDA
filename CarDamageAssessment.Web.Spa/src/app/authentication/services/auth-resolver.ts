import { Injectable } from '@angular/core';
import { Resolve, ActivatedRouteSnapshot } from '@angular/router';
import { AuthService } from './auth.service';
import { User } from 'oidc-client';

@Injectable()
export class AuthResolve implements Resolve<User> {

  constructor(private auth: AuthService) {}

  resolve(route: ActivatedRouteSnapshot) {
    return this.auth.user;
  }
}