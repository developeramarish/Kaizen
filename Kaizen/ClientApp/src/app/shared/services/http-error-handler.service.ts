import { HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { NotificationsService } from '@shared/services/notifications.service';
import { Observable, of } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class HttpErrorHandlerService {
  constructor(private notificationsService: NotificationsService, private router: Router) {}

  handleError<T>(operation = 'operation', result?: T) {
    return (error: HttpErrorResponse): Observable<T> => {
      console.log(error.url);
      console.log(error);
      this.notificationsService.addMessage(`Error en: ${operation}`, 'Ok');
      return of(result as T);
    };
  }

  handleHttpError(error: HttpErrorResponse, action?: () => void): void {
    console.log(error);
    if (typeof error.error === 'string') {
      this.notificationsService.showErrorMessage(error.error, () => {
        this.afterCloseErrorPanel(action);
      });
    } else if (error.error.Message !== undefined && error.error.Message !== null) {
      this.notificationsService.showErrorMessage(error.error.Message, () => {
        this.afterCloseErrorPanel(action);
      });
    } else if (error.error.errors) {
      let errorMessage = 'Se presentaron los siguientes errores: <br/>';
      for (const prop of Object.keys(error.error.errors)) {
        error.error.errors[prop].forEach((element: string) => {
          errorMessage += `- ${element} <br/>`;
        });
      }
      this.notificationsService.showErrorMessage(errorMessage, () => {
        this.afterCloseErrorPanel(action);
      });
    }
  }

  afterCloseErrorPanel(action: () => void): void {
    if (action !== null && action !== undefined) {
      action();
    } else {
      this.redirectToProfile();
    }
  }

  redirectToProfile(): void {
    this.router.navigateByUrl('/user/profile');
  }
}
