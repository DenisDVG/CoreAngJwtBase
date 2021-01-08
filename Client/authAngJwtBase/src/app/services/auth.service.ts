import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Token } from '../components/models/token';

export const ACCESS_TOKEN_KEY = 'bookstore_access_token';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor() { }
login(email: string, password: string): Observable<Token> {

}

isAuthenticated(): boolean {

}

logout(): void {

}
