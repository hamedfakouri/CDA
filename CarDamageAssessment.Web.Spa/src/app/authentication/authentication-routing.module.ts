import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import {AuthCallbackComponent,LogoutComponent} from './components'
const routes: Routes = [
  { path:'', component: AuthCallbackComponent , data:{title:'بررسی وضعیت کاربر'} }, 
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AuthenticationRoutingModule { }
