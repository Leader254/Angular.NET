import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/services/auth.service';
import { NotificationService } from 'src/app/services/notification.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  reactiveForm: FormGroup;

  constructor(private authService: AuthService, private router: Router, private notifyService: NotificationService) { }

  ngOnInit(): void {
    this.reactiveForm = new FormGroup({
      name: new FormControl(null, Validators.required),
      email: new FormControl(null, [Validators.required, Validators.email]),
      password: new FormControl(null, [Validators.required, Validators.minLength(6)]),
      phoneNumber: new FormControl(null, [Validators.required, Validators.pattern('[0-9]{10}')])
    });
  }

  onRegister() {
      this.authService.registerUser(this.reactiveForm.value)
        .subscribe({
          next: (response) => {
            if (response) {
              this.notifyService.showSuccess("User registered successfully !!", "Notification")
            }
            this.router.navigate(["login"])
          },
          error: (err) => {
            console.log(err);
          }
        });
    }
}
