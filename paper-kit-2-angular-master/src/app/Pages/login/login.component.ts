import { Component, OnInit } from "@angular/core";
import { FormBuilder, FormGroup, Validators } from "@angular/forms";
import { Router } from "@angular/router";
import { UserService } from "../../services/user.service";
import { HttpClient, HttpClientModule } from "@angular/common/http";
import * as _ from "lodash";
@Component({
  selector: "login",
  templateUrl: "./login.component.html",
  styleUrls: ["./login.component.scss"],
})
export class LoginComponent implements OnInit {
  form: FormGroup;
  submitted = false;
  errorMessage: string = '';
  successMessage: string = '';

  constructor(
    private formBuilder: FormBuilder,
    private router: Router,
    private http: HttpClient,
    private userService: UserService
  ) {
    this.form = this.formBuilder.group({
      email: ["", [Validators.email, Validators.required]],
      password: ["", [Validators.required]],
    });
  }

  ngOnInit() {}

  get f() {
    return this.form.controls;
  }

  onLoginSubmit() {
    this.submitted = true;

    if (this.form.invalid) {
      return;
    }

   const request = _.clone(this.form.value);

    this.userService.login(request).subscribe(
      (response) => {
        this.successMessage = "Login successful!";
        console.log('Login successful:', response);

        localStorage.setItem('token', response.token);
        this.router.navigate(['/dashboard']);
      },
      (error) => {
        this.errorMessage = "Invalid email or password. Please try again.";
        console.error('Login failed:', error);
      }
    );
  }
}
