import { AccountComponent     } from '@account/account.component'
import { AccountRoutingModule } from '@account/account-routing.module'
import { CommonModule         } from '@angular/common'
import { LoginComponent       } from '@account/login/login.component'
import { NgModule             } from '@angular/core'
import { RegisterComponent    } from '@account/register/register.component'
import { ReactiveFormsModule } from '@angular/forms'

const components = [AccountComponent, LoginComponent, RegisterComponent];

@NgModule({
  imports: [
    CommonModule,
    AccountRoutingModule,
    ReactiveFormsModule
  ],
  declarations: [components],
  exports: [components]
})
export class AccountModule { }
