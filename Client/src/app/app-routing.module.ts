import { AuthGuard } from '@services/auth.guard';
import { NgModule } from '@angular/core'
import { RouterModule, Routes } from '@angular/router'

const routes: Routes = [
  { path: 'account', loadChildren: () => import('./account/account.module').then(m => m.AccountModule)                           },
  { path: 'profile', loadChildren: () => import('./profile/profile.module').then(m => m.ProfileModule), canActivate: [AuthGuard] },
  { path: 'search' , loadChildren: () => import('./search/search.module'  ).then(m => m.SearchModule ), canActivate: [AuthGuard] },
  { path: '**', pathMatch: 'full', redirectTo: 'search' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
