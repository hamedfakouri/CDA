import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { UserRoutingModule } from './user-routing.module';
import { UserServiceModule } from './services';

@NgModule({
  imports: [
    CommonModule,
    UserRoutingModule,
    UserServiceModule,
  ],
  providers:[]
})
export class UserModule { }
