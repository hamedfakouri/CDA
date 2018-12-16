import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CorporateService } from './corporate.service';

@NgModule({
  imports: [
    CommonModule
  ],
  declarations: [],
  providers:[CorporateService]
})
export class CorporateServiceModule { }
