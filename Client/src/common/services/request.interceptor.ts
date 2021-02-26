import { Injectable } from '@angular/core';
import { HttpEvent, HttpInterceptor, HttpHandler, HttpRequest } from '@angular/common/http';
import { Observable } from 'rxjs';
import { IdentityService } from '@services/identity.service';

@Injectable()
export class RequestInterceptor implements HttpInterceptor {
  constructor(private identity: IdentityService) { }

  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    const headers = req.headers
      .set('Content-Type', 'application/json');
    const authReq = req.clone({ headers });
    return next.handle(authReq);
  }
}