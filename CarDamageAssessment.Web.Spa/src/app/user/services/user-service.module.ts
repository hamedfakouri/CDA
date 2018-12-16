import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { UserService } from './user.service';
import { HttpService } from 'src/app/core/services';

@NgModule({
  imports: [
    CommonModule,
    

  ],
  declarations: [],
  providers:[UserService]
})
export class UserServiceModule { }
