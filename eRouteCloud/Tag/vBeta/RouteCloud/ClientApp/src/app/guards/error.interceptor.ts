import { HttpRequest, HttpHandler, HttpEvent, HttpInterceptor } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { AuthenticationService } from '../services/index.service';
import { Injectable } from '@angular/core';

@Injectable()
export class ErrorInterceptor implements HttpInterceptor {
    constructor(private authenticationService: AuthenticationService) { }

    intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        return next.handle(request).pipe(
            catchError(
                err => {
                    if (err.status === 401) {
                        // Auto logout if 401 response returned from api
                        this.authenticationService.logout();
                        location.reload(true);
                    }

                    const ERROR = err.error.message || err.statusText;
                    return throwError(ERROR);
                }
            )
        );
    }
}
