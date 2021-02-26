import { CommonModule        } from '@angular/common'
import { HttpClientModule    } from '@angular/common/http'
import { NgModule            } from '@angular/core'
import { SearchComponent     } from '@search/search.component'
import { SearchRoutingModule } from '@search/search-routing.module'

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
