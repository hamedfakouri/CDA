import { Component, OnInit } from '@angular/core';
import { AuthService } from './../../../authentication/services/auth.service'
@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {


  authenticated:boolean =false;
  constructor(private authService:AuthService) { }

  ngOnInit() {

    if(this.authService.isLoggedIn()){
      this.authenticated= true;
    }


  }

  login():void{
this.authService.startAuthentication();
  }

  logout():void{
    this.authService.signOut();
  }
}
