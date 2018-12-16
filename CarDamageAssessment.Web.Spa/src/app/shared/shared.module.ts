import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { SharedRoutingModule } from './shared-routing.module';
import { FooterComponent } from './component/footer/footer.component';
import { HeaderComponent } from './component/header/header.component';
import { LoginComponent } from './component/login/login.component';


@NgModule({
  imports: [
    CommonModule,
    SharedRoutingModule
  ],
  declarations: [FooterComponent, HeaderComponent, LoginComponent]
  ,exports:[
    FooterComponent,HeaderComponent
  ],
  providers:[]
})
export class SharedModule { }
