import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import {ProtectedComponent} from './components';
import {AuthGuardService} from './../authentication/services';

const routes: Routes = [
  
  {
      path: 'protected',
      component: ProtectedComponent,      
      canActivate: [AuthGuardService]   
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class CoreRoutingModule { }
