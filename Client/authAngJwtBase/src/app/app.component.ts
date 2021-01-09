import { Component } from '@angular/core';
import { AuthService } from './services/auth.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {

  constructor(private as: AuthService) {

  }

  login(email: string, password: string): void {
    this.as.login(email, password)
      .subscribe(res => {

      }, error => {
        alert('Wrong login');
      }

      );
  }

  logout(): void {
    this.as.logout();
  }

  public get isLoggedIn(): boolean {
    return this.as.isAuthenticated();
  }
}
