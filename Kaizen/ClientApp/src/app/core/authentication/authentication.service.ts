import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { LoginRequest } from '@core/models/login-request';
import { User } from '@core/models/user';
import { AUTH_API_URL } from '@global/endpoints';
import { CookieService } from 'ngx-cookie-service';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AuthenticationService {
  readonly USER_LOCAL_STORAGE_KEY = 'currentUser';

  constructor(private http: HttpClient, private cookieService: CookieService) {}

  registerUser(user: User): Observable<User> {
    return this.http.post<User>(AUTH_API_URL, user);
  }

  loginUser(user: LoginRequest): Observable<User> {
    return this.http.post<User>(`${AUTH_API_URL}/Login`, user);
  }

  logoutUser(): void {
    this.removeUser();
    localStorage.removeItem('current_person');
  }

  removeUser(): void {
    localStorage.removeItem(this.USER_LOCAL_STORAGE_KEY);
    this.cookieService.delete('user_token');
  }

  setCurrentUser(user: User): void {
    this.cookieService.set('user_token', user.token, 365, '/', null, true);
    user.token = undefined;
    const user_str = JSON.stringify(user);
    localStorage.setItem(this.USER_LOCAL_STORAGE_KEY, user_str);
  }

  getToken(): string {
    return this.cookieService.get('user_token');
  }

  getCurrentUser(): User {
    const user_str = localStorage.getItem(this.USER_LOCAL_STORAGE_KEY);
    if (user_str === null || user_str === undefined) {
      return null;
    } else {
      const user: User = JSON.parse(user_str);
      return user;
    }
  }

  getUserRole(): string {
    const payload = JSON.parse(window.atob(this.getToken().split('.')[1]));
    return payload.role;
  }

  userLoggedIn(): boolean {
    return this.getCurrentUser() != null;
  }
}
