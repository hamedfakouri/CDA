import { RouterModule, Routes } from '@angular/router';
import {ProtectedComponent} from './core/components';
import { NgModule } from '@angular/core';
import { AuthGuardService } from './authentication/services/auth-guard.service';
import {AppComponent} from './app.component'
const appRoutes: Routes = [
 
   
    {
      path: 'home',
      component: AppComponent,
      data: { title: 'Heroes List' }
    }
    ,
    {
        path: 'core',
        loadChildren:'./core/core.module#CoreModule'
 
    }
    ,
    {
      path:'auth-callback',
      loadChildren:'./authentication/authentication.module#AuthenticationModule'
    }
    ,
    {
      path:'logout',
      loadChildren:'./authentication/authentication.module#AuthenticationModule'
    }
  ];
  
  @NgModule({
    imports: [
      RouterModule.forRoot(
        appRoutes,
        { enableTracing: true } // <-- debugging purposes only
      )
      // other imports here
    ]
  })
  export class AppRouteModule { }
