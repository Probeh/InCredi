import { Observable } from 'rxjs'
import { tap } from 'rxjs/operators'
import { HttpEvent, HttpHandler, HttpInterceptor, HttpRequest, HttpResponse } from '@angular/common/http'
import { Injectable } from '@angular/core'
import { Identity } from '@models/identity.model'
import { IdentityService } from '@services/identity.service'

@Injectable()
export class ResponseInterceptor implements HttpInterceptor {
  constructor(private identity: IdentityService) { }

  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    return next.handle(req).pipe(
      tap(event => {
        if (event instanceof HttpResponse) {
          if (event.headers.has("authorization")) {
            this.identity.setIdentity(new Identity({ token: event.headers.get("authorization").replace('Bearer ', '') }));
          }
        }
      })
    );
  }
}