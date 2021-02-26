import { CommonModule         } from '@angular/common'
import { NgModule             } from '@angular/core'
import { ProfileComponent     } from '@profile/profile.component'
import { ProfileRoutingModule } from '@profile/profile-routing.module'

const components = [ProfileComponent];
@NgModule({
  imports: [
    CommonModule,
    ProfileRoutingModule
  ],
  declarations: [components],
  exports: [components]
})
export class ProfileModule { }
