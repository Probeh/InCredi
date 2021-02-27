import { AccountComponent          } from '@account/account.component'
import { LoginComponent            } from '@account/login/login.component'
import { RegisterComponent         } from '@account/register/register.component'
import { NgModule                  } from '@angular/core'
import { RouterModule     , Routes } from '@angular/router'

const routes: Routes = [
  {
    path: '', component: AccountComponent, children: [
      { path: 'login'   , component: LoginComponent    },
      { path: 'register', component: RegisterComponent },
      { path: '**', pathMatch: 'full', redirectTo: 'login' },
    ]
  }
];
@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AccountRoutingModule { }
