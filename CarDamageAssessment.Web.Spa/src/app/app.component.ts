import { Component, OnInit } from '@angular/core';
import { CorporateService } from './corporate/services/corporate.service';
import { AuthService } from './authentication/services';

@Component({

  selector: 'app-root',
  templateUrl: './app.component.html'
})
export class AppComponent  implements OnInit {
  ngOnInit(): void {
    this.getCars();
  }
 

  

  constructor(private httpService:CorporateService,private authService:AuthService) {


  }
 
 getCars():any{

    //this.httpService.getAll().subscribe();
    this.httpService.add(Object).subscribe();
    //this.httpService.get(41).subscribe(res=> this.car = res);

    //this.httpService.update(41,this.car).subscribe();


  }

  logOut():any{
    this.authService.signOut();
  }
  getClaims():any{
   let item= this.authService.getClaims();
   console.log(item);

  }


  
}
