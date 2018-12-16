import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { NgModule,APP_INITIALIZER  } from '@angular/core';
import { AppRouteModule } from './app.routes';
import {AuthService} from './authentication/services/auth.service'
import { SharedModule } from './shared/shared.module';
import { AppComponent } from './app.component';
import { CoreServiceModule } from './core/services';
import { AuthServiceModule } from './authentication/services/auth-service.module';
import { CorporateServiceModule } from './corporate/services';
import { UserService } from './user/services';
import { UserModule } from './user/user.module';

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule ,
    AppRouteModule,
    HttpClientModule,
    RouterModule,
    SharedModule,
    CoreServiceModule ,
    AuthServiceModule,
    CorporateServiceModule,
    UserModule
  ]
  
,
  providers: [
    CoreServiceModule,
    AuthServiceModule,
   { provide: APP_INITIALIZER, useFactory: get_settings, deps: [AuthService,UserService], multi: true }
  ],
  bootstrap: [AppComponent],
})
export class AppModule { }


export function get_settings(authService: AuthService,userService:UserService) {

   
  if(window.location.href.startsWith("http://localhost:4300/auth-callback")) {
  return () =>    authService.completeAuthentication();

  }
  else{
    return () => authService.getUser();
  }
  return ()=> true;
}
