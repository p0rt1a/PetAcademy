import {
  HttpErrorResponse,
  HttpEvent,
  HttpHandler,
  HttpInterceptor,
  HttpRequest,
} from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, catchError, throwError } from 'rxjs';

declare let alertify: any;

@Injectable({
  providedIn: 'root',
})
export class TokenIntercaptor implements HttpInterceptor {
  constructor() {}

  intercept(
    req: HttpRequest<any>,
    next: HttpHandler
  ): Observable<HttpEvent<any>> {
    req = req.clone({
      setHeaders: {
        Authorization: `Bearer ${localStorage.getItem('token')}`,
      },
    });

    return next.handle(req).pipe(
      catchError((error: HttpErrorResponse) => {
        alertify.error(error.error.error);

        return throwError('Error occured');
      })
    );
  }
}
