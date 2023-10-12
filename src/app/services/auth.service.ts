import { Injectable } from '@angular/core';
import { User } from '../models/users.model';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { JwtHelperService, JWT_OPTIONS } from '@auth0/angular-jwt';

@Injectable({
  providedIn: 'root'
})


export class AuthService {
  apiUrl: string = 'https://localhost:7023';

  constructor(private http: HttpClient) { }

  registerUser(newUser: User) : Observable<User>
  {
    newUser.id = '';
    return this.http.post<User>(this.apiUrl + '/api/User/register', newUser);
  }
  loginUser(username: string, password: string): Observable<any> {
    return this.http.post(this.apiUrl + '/api/User/login', { username, password });
  }
  public isAuthenticated() : boolean {
    const token = localStorage.getItem('authToken');
    const helper = new JwtHelperService();
    const isExpired = helper.isTokenExpired(token);
    return !isExpired;
  }
}
