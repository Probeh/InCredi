import { CommonModule         } from '@angular/common'
import { NgModule             } from '@angular/core'
import { ProfileRoutingModule } from '@profile/profile-routing.module'
import { ProfileComponent     } from '@profile/profile.component'

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
