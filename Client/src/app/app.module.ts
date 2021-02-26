import { ToastrModule                          } from 'ngx-toastr'
import { HTTP_INTERCEPTORS  , HttpClientModule } from '@angular/common/http'
import { NgModule                              } from '@angular/core'
import { BrowserModule                         } from '@angular/platform-browser'
import { AppRoutingModule                      } from '@client/app-routing.module'
import { AppComponent                          } from '@client/app.component'
import { RequestInterceptor                    } from '@services/request.interceptor'
import { ResponseInterceptor                   } from '@services/response.interceptor'

@NgModule({
  declarations: [AppComponent],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    ToastrModule.forRoot(),
  ],
  bootstrap: [AppComponent],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: RequestInterceptor, multi: true },
    { provide: HTTP_INTERCEPTORS, useClass: ResponseInterceptor, multi: true },
  ],
})
export class AppModule { }
