import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor,
  HttpErrorResponse
} from '@angular/common/http';
import { Observable } from 'rxjs';
import { AuthenticationService } from '../authentication/authentication.service';
import { tap } from 'rxjs/operators';
import { Router } from '@angular/router';

@Injectable()
export class AuthInterceptor implements HttpInterceptor {

  constructor(
    private authService: AuthenticationService,
    private router: Router
  ) {}

  intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    if (this.authService.userLoggedIn()) {
      request = request.clone({
        setHeaders: {
          Authorization: `Bearer ${this.authService.getToken()}`
        }
      });
    }

    return next.handle(request)
      .pipe(
        tap(
          succ => { },
          err => {
            if (err instanceof HttpErrorResponse && err.status == 401) {
              this.authService.removeUser();
              this.router.navigateByUrl('/user/login');
            }
          }
        )
      )
  }
}