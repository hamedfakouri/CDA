import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { CorporateRoutingModule } from './corporate-routing.module';
import { CorporateComponent } from './component/corporate.component';
import { CorporateServiceModule } from './services/corporate-service.module';



@NgModule({
  imports: [
    CommonModule,
    CorporateRoutingModule,
    CorporateServiceModule
  ],
  declarations: [CorporateComponent]
})
export class CorporateModule { }
