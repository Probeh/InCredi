import { Component, OnInit } from '@angular/core';
import { MenuItem } from 'primeng/api';

@Component({
  selector: 'app-account',
  templateUrl: './account.component.html',
  styleUrls: ['./account.component.scss']
})
export class AccountComponent implements OnInit {
  public items: MenuItem[];
  constructor() { }
  ngOnInit() {
    this.items = [
      { label: 'Login'   , icon: 'fa fa-user'     , routerLink: 'login' },
      { label: 'Register', icon: 'fa fa-user-plus', routerLink: 'register' },
    ];
  }
}
