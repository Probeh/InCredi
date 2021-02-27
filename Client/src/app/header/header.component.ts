import { Component, OnInit } from '@angular/core';
import { IdentityService } from '@services/identity.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss']
})
export class HeaderComponent implements OnInit {
  public authenticated: boolean = false;
  constructor(private identity: IdentityService) { this.authenticated = this.identity.authState; }
  ngOnInit() {
    this.identity.identity$.subscribe({ next: value => this.authenticated = this.identity.authState });
  }
  public logout() {
    this.identity.userLogout()
  }
}
