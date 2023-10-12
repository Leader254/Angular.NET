import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { AuthService } from '../../services/auth.service';
import { Router } from '@angular/router';
import { NotificationService } from 'src/app/services/notification.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {
  loginForm: FormGroup;

  constructor(private formBuilder: FormBuilder, private authService: AuthService, private router: Router, private notifyService: NotificationService) {
    this.loginForm = this.formBuilder.group({
      username: ['', [Validators.required]],
      password: ['', Validators.required]
    });
  }

  onSubmit() {
    if (this.loginForm.valid) {
      const username = this.loginForm.get('username').value;
      const password = this.loginForm.get('password').value;

      // Call the login service function
      this.authService.loginUser(username, password)
        .subscribe({
          next: (response) => {
            localStorage.setItem('authToken', response.data.token);
            this.router.navigate(["/products"]);
          },
          error: (err) => {
            console.log(err);
          }
        });
    }
  }
}
