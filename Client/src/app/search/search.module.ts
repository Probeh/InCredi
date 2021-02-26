import { CommonModule        } from '@angular/common'
import { HttpClientModule    } from '@angular/common/http'
import { NgModule            } from '@angular/core'
import { SearchRoutingModule } from '@search/search-routing.module'
import { SearchComponent     } from '@search/search.component'

const components = [SearchComponent];

@NgModule({
  imports: [
    CommonModule,
    SearchRoutingModule,
    HttpClientModule
  ],
  declarations: [components],
  exports: [components]
})
export class SearchModule { }
