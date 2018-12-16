import { Component, OnInit } from '@angular/core';

@Component({

  selector: 'logout-selector',

  templateUrl: './logout.component.html',
  styleUrls: ['./logout.component.css']
})
export class LogoutComponent  implements OnInit {
    ngOnInit(): void {
       alert("logout")
    }
  
}
