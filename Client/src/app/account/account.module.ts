import { InputTextModule } from 'primeng/inputtext'
import { TabMenuModule } from 'primeng/tabmenu'
import { AccountRoutingModule } from '@account/account-routing.module'
import { AccountComponent } from '@account/account.component'
import { LoginComponent } from '@account/login/login.component'
import { RegisterComponent } from '@account/register/register.component'
import { CommonModule } from '@angular/common'
import { NgModule } from '@angular/core'
import { ReactiveFormsModule } from '@angular/forms'

const components = [AccountComponent, LoginComponent, RegisterComponent];

@NgModule({
  imports: [
    CommonModule,
    AccountRoutingModule,
    InputTextModule,
    ReactiveFormsModule,
    TabMenuModule
  ],
  declarations: [components],
  exports: [components]
})
export class AccountModule { }
