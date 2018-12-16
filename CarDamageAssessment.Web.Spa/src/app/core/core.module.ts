import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { CoreRoutingModule } from './core-routing.module';

import { ProtectedComponent } from './components/protected/protected.component';
import { CoreServiceModule } from './services/core-service.module';



@NgModule({
  imports: [
    CommonModule,
    CoreRoutingModule,
    CoreServiceModule,
    
  ],
  declarations: [ ProtectedComponent],
  exports:[ ProtectedComponent],
  providers:[]
})
export class CoreModule { 

constructor(){
  console.log("--------------------------------CoreModule-------------------------------")
}

}
