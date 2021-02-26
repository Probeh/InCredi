import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { Account } from '@models/account.model';
import { IdentityService } from '@services/identity.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {
  public loginForm: FormGroup = this.generateForm();
  constructor(private identity: IdentityService, private router: Router) { }
  ngOnInit() { }
  public generateForm() {
    return new FormGroup({
      'userName': new FormControl('', Validators.required),
      'password': new FormControl('', Validators.required)
    });
  }
  public onSubmit() {
    this.identity
      .userLogin(new Account(this.loginForm.value['userName'], this.loginForm.value['password']))
      .catch(error => this.generateForm());
  }
}
