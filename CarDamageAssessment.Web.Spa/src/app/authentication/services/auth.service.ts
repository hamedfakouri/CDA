import { Injectable, OnInit } from '@angular/core';
import { UserManager, UserManagerSettings, User } from 'oidc-client';
import {UserInfo} from './../../user/models/User'
import { UserService } from './../../user/services/user.service';


@Injectable()
export class AuthService  {

  private manager: UserManager = new UserManager(getClientSettings());
  public user: User = null;
  public userInfo:UserInfo = new UserInfo();
  constructor(private userService:UserService) { 
   // this.manager.getUser().then(user=> this.user = user); 
  }

  getUser(){
    this.manager.getUser().then(user=> this.user = user);
  }

  isLoggedIn(): boolean {
    return this.user != null && !this.user.expired;
  }

  getClaims(): any {
    return this.user.profile;
}

  getAuthorizationHeaderValue(): string {
    return `${this.user.token_type} ${this.user.access_token}`;
  }

  startAuthentication(): Promise<void> {
    return this.manager.signinRedirect();
  }

  completeAuthentication(): Promise<void> {
    return this.manager.signinRedirectCallback().then(user => {
      this.user = user;

      return this.saveUser(this.getClaims());

    });
  }


  signOut():any{
    return this.manager.signoutRedirect();

  }


  saveUser(user:any):Promise<void>{

 
    let userdata = user;
    this.userInfo = new UserInfo(userdata.sub,userdata.given_name);

     return  this.userService.add(this.userInfo).toPromise().then(src=> {
      console.log("save user asdasdasdasd")
    })

  }
}

export function getClientSettings(): UserManagerSettings {
  return {
    authority: 'http://localhost:5000/',
    client_id: 'angular_spa',
    redirect_uri: 'http://localhost:4300/auth-callback',
    post_logout_redirect_uri: 'http://localhost:4300/logout',
    response_type: "id_token token",
    scope: "openid profile api1",
    filterProtocolClaims: true,
    loadUserInfo: false,
    automaticSilentRenew: false,
    silent_redirect_uri: 'http://localhost:4300/silent-refresh.html'
  };
}
