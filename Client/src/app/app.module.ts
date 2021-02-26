import { ToastrModule                              } from 'ngx-toastr'
import { HTTP_INTERCEPTORS      , HttpClientModule } from '@angular/common/http'
import { NgModule                                  } from '@angular/core'
import { BrowserModule                             } from '@angular/platform-browser'
import { BrowserAnimationsModule                   } from '@angular/platform-browser/animations'
import { AppRoutingModule                          } from '@client/app-routing.module'
import { AppComponent                              } from '@client/app.component'
import { AuthGuard                                 } from '@services/auth.guard'
import { RequestInterceptor                        } from '@services/request.interceptor'
import { ResponseInterceptor                       } from '@services/response.interceptor'

@NgModule({
  declarations: [AppComponent],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    AppRoutingModule,
    HttpClientModule,
    ToastrModule.forRoot(),
  ],
  bootstrap: [AppComponent],
  providers: [
    AuthGuard,
    { provide: HTTP_INTERCEPTORS, useClass: RequestInterceptor, multi: true },
    { provide: HTTP_INTERCEPTORS, useClass: ResponseInterceptor, multi: true },
  ],
})
export class AppModule { }
