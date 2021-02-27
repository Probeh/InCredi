import { Observable } from 'rxjs'
import { HttpEvent, HttpHandler, HttpInterceptor, HttpRequest } from '@angular/common/http'
import { Injectable } from '@angular/core'
import { server } from '@env/environment'
import { IdentityService } from '@services/identity.service'

@Injectable()
export class RequestInterceptor implements HttpInterceptor {
  constructor(private identity: IdentityService) { }

  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {

    const headers = this.identity.authState ?
      req.headers
        .append("Authorization", `Bearer ${this.identity.identity.token}`)
        .append('Content-Type', 'application/json') :
      req.headers.append('Content-Type', 'application/json');

    const authReq = req.clone({ headers, url: server + '/' + req.url });
    return next.handle(authReq);
  }
}