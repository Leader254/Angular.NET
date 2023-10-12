import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'ShopIt';
  get isLoggedIn() {
    return localStorage.getItem('authToken') ? true : false;
  }

  // handle logout
  logout() {
    localStorage.removeItem('authToken');
    // redirect to login page
    window.location.href = '/login';
  }
}
